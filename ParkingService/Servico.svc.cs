using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParkingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Servico : IServico
    {
        //TODO: Retirar após testes
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        //TODO: Retirar após testes
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {

            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public List<dtoVaga> ListarVagasDisponiveis()
        {
            throw new NotImplementedException();
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
