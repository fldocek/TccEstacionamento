using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dados;

namespace ParkingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Servico : IServico
    {
        ParkingDBEntities ct = new ParkingDBEntities();

        public IEnumerable<dtoVaga> ListarVagasDisponiveis()
        {
            string situacao = eSituacaoVaga.Livre.ToString();

            var lista = (from Vaga V in ct.Vaga
                         where V.ReservaDisponivel
                         select new dtoVaga
                         {
                             Andar = V.Bloco.Andar.Nome,
                             Bloco = V.Bloco.Nome,
                             Id = V.Id,
                             Nome = V.Nome,
                             Disponivel = (V.Situacao == situacao)
                         });

            return lista;
        }

        public bool ReservarVaga(int Id_Vaga, int Id_Carro)
        {
            throw new NotImplementedException();
        }

        public dtoSituacaoVaga ConsultaSituacaoVaga(int Id_Vaga)
        {
            throw new NotImplementedException();
        }

        public dtoCaminho LocalizarCarro(int Id_QRCode, int Id_Carro)
        {
            throw new NotImplementedException();
        }
    }
}
