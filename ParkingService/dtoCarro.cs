using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParkingService
{
    [DataContract]
    public class dtoCarro
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Placa { get; set; }

    }
}