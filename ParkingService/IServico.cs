using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParkingService
{

    [ServiceContract]
    public interface IServico
    {
        //TODO: Retirar após testes
        [OperationContract]
        string GetData(int value);

        //TODO: Retirar após testes
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        

        //Fluxo Reservar Vaga
        //===================

        [OperationContract]
        List<dtoVaga> ListarVagasDisponiveis();

        [OperationContract]
        bool ReservarVaga(int Id_Vaga, int Id_Carro);

        //Fluxo Manter Vaga Reservada
        //===========================

        [OperationContract]
        dtoSituacaoVaga ConsultaSituacaoVaga(int Id_Vaga);

        //Fluxo Localizar Carro
        //=====================

        [OperationContract]
        dtoCaminho LocalizarCarro(int Id_QRCode, int Id_Carro);

    }

    //TODO: Retirar após testes
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
