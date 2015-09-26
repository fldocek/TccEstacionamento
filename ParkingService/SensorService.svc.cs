using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dados;
using System.Data.Objects.SqlClient;

namespace ParkingService
{
    public class SensorService : ISensorService
    {

        ParkingDBEntities ct = new ParkingDBEntities();

        private string SITUACAO_RESERVADA
        {
            get { return eSituacaoVaga.Reservada.ToString(); }
        }

        public IEnumerable<dtoVagaSinalizar> ListarVagasParaSinalizar()
        {
            // Consultar vagas que já passam do tempo de reserva 

            int limiteReserva = ConfiguracaoSistema.TempoReserva(); // 2 horas de reserva

            DateTime HoraAtual = DateTime.Now;

            var listaReservadas = (from V in ct.Vaga
                                   where V.Situacao == SITUACAO_RESERVADA &&
                                         SqlFunctions.DateDiff("minute", V.HoraReserva, HoraAtual) >= limiteReserva
                                   select V);

            foreach (var reservada in listaReservadas)
            {
                reservada.Situacao = eSituacaoVaga.Livre.ToString();
                reservada.HoraReserva = null;
                reservada.Carro = null;

                reservada.AguardandoSinalizacao = true;

                //LOG: vagas que já passam do tempo de reserva 
            }
            
            ct.SaveChanges();

            // Consultar vagas para sinalizar

            var listaVagas = (from V in ct.Vaga
                              where V.AguardandoSinalizacao
                              select V);

            List<dtoVagaSinalizar> listaSinalizar = new List<dtoVagaSinalizar>();

            foreach (var vaga in listaVagas)
            {
                dtoVagaSinalizar sinalizar = new dtoVagaSinalizar
                {
                    Id = vaga.Id,
                    Situacao = vaga.Situacao,
                    EnderecoSensor = vaga.EnderecoSensor,
                    Deficiente = vaga.Deficiente
                };

                listaSinalizar.Add(sinalizar);

                vaga.AguardandoSinalizacao = false;
            }

            ct.SaveChanges();

            return listaSinalizar;
        }

        public void OcuparVagar(int Id_Vaga, string Tag)
        {
            Vaga vaga = Util.ConsultarVaga(Id_Vaga, ct);

            vaga.Situacao = eSituacaoVaga.Ocupada.ToString();

            if (!string.IsNullOrEmpty(Tag))
            {
                Carro carro = Util.ConsultarCarroPorTag(Tag, ct);

                vaga.Id_Carro = carro.Id;
            }

            ct.SaveChanges();
        }

    }
}
