﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParkingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISensorService" in both code and config file together.
    [ServiceContract]
    public interface ISensorService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IEnumerable<dtoVagaSinalizar> ListarVagasParaSinalizar();
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void OcuparVaga(int Id_Vaga, string Tag);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void LiberarVaga(int Id_Vaga);
        
    }
}
