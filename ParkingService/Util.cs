using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dados;

namespace ParkingService
{
    public abstract class Util
    {

        public static Cliente ConsultarCliente(string CPF, ParkingDBEntities ct)
        {
            CPF = Util.RetirarFormatacaoCPF(CPF);

            Cliente cliente = (from C in ct.Cliente where C.CPF == CPF select C).SingleOrDefault();

            if (cliente == null)
            {
                throw new exClienteNaoEncontrado(CPF);
            }

            return cliente;
        }

        public static Vaga ConsultarVaga(int Id_Vaga, ParkingDBEntities ct)
        {
            Vaga vaga = (from V in ct.Vaga where V.Id == Id_Vaga select V).SingleOrDefault();

            if (vaga == null)
            {
                throw new exVagaNaoEncontrada(Id_Vaga);
            }

            return vaga;
        }

        public static Carro ConsultarCarroPorTag(string Tag, ParkingDBEntities ct)
        {
            Carro carro = (from C in ct.Carro where C.Tag == Tag select C).SingleOrDefault();

            if (carro == null)
            {
                throw new exCarroNaoEncontrado(Tag);
            }

            return carro;
        }


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