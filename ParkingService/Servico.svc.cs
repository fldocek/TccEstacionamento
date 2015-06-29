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

        private string SITUACAO_LIVRE
        {
            get { return eSituacaoVaga.Livre.ToString(); }
        }        

        public IEnumerable<dtoAndar> ListarAndares()
        {
            var lista = (from A in ct.Andar
                         select new dtoAndar
                         {
                             Id = A.Id,
                             Nome = A.Nome,
                             QtdVagas = (from B in A.Bloco from V in B.Vaga 
                                         select V).Count(),
                             QtdLive = (from B in A.Bloco from V in B.Vaga 
                                        where V.Situacao == SITUACAO_LIVRE
                                        select V).Count()
                         });

            return lista;
        }

        public IEnumerable<dtoBloco> ListarBlocos(int Id_Andar)
        {
            var lista = (from B in ct.Bloco
                         where B.Id_Andar == Id_Andar
                         select new dtoBloco
                         {
                             Id = B.Id,
                             Nome = B.Nome,
                             QtdVagas = B.Vaga.Count(),
                             QtdLive = (from V in B.Vaga
                                        where V.Situacao == SITUACAO_LIVRE
                                        select V).Count()
                         });

            return lista;
        }

        public IEnumerable<dtoVaga> ListarVagas(int Id_Bloco)
        {            
            var lista = (from V in ct.Vaga
                         where V.Id_Bloco == Id_Bloco
                         select new dtoVaga
                         {
                             Id = V.Id,
                             Nome = V.Nome,
                             Disponivel = (V.Situacao == SITUACAO_LIVRE)
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
