using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingService
{
    public abstract class Util
    {

        public static string FormatarCPF(string CPF)
        {
            CPF = RetirarFormatacaoCPF(CPF);

            CPF = CPF.Insert(3, ".");
            CPF = CPF.Insert(6, ".");
            CPF = CPF.Insert(9, "-");

            return CPF;
        }

        public static string RetirarFormatacaoCPF(string CPF)
        {
            CPF = CPF.Replace(".", "");
            CPF = CPF.Replace("-", "");

            return CPF;
        }
        
    }
}