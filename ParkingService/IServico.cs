﻿using System;
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

        //Fluxo Reservar Vaga
        //===================

        [OperationContract]
        [WebInvoke(Method=  "GET",
            ResponseFormat= WebMessageFormat.Json,
            BodyStyle= WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<dtoAndar> ListarAndares();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<dtoBloco> ListarBlocos(int Id_Andar);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<dtoVaga> ListarVagas(int Id_Bloco);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool ReservarVaga(int Id_Vaga, int Id_Carro);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<dtoCarro> ListarCarros(string CPF);

        //Fluxo Manter Vaga Reservada
        //===========================

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        dtoSituacaoVaga ConsultaSituacaoVaga(int Id_Vaga, int Id_Carro);

        //Fluxo Localizar Carro
        //=====================

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        dtoCaminho LocalizarCarro(int Id_QRCode, int Id_Carro);

    }

}
