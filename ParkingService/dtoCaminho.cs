using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Drawing;

namespace ParkingService
{
    [DataContract]
    public class dtoCaminho
    {

        [DataMember]
        public List<string> ListaImagens { get; set; }

    }
}