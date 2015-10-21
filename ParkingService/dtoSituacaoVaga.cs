﻿using System;
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
    public class dtoSituacaoVaga
    {

        [DataMember]
        public string ReservaConcluidaComSucesso { get; set; }

        [DataMember]
        public string VagaAindaReservada { get; set; }

    }
}