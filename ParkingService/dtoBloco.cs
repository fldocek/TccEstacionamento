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
    public class dtoBloco
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public int QtdVagas { get; set; }

        [DataMember]
        public int QtdLivre { get; set; }

    }
}