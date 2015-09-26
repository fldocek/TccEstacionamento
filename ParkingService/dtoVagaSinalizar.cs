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
    public class dtoVagaSinalizar
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string EnderecoSensor { get; set; }

        [DataMember]
        public string Situacao { get; set; }

        [DataMember]
        public bool Deficiente { get; set; }

    }
}
