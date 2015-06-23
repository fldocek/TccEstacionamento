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
    public class dtoVaga
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String Bloco { get; set; }

        [DataMember]
        public String Andar { get; set; }

        [DataMember]
        public String Nome { get; set; }

        [DataMember]
        public bool Disponivel { get; set; }

    }
}