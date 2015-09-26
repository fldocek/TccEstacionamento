using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public static class ConfiguracaoSistema
    {

        private static string ConsultarValorConfiguracao(string Chave)
        {

            ParkingDBEntities ct = new ParkingDBEntities();

            string valor = (from C in ct.Configuracao
                            where C.Chave == Chave
                            select C.Valor).SingleOrDefault();

            if (valor == null)
            {
                throw new Exception("Chave não conhecida: " + Chave);
            }

            return valor;
        }

        public static int TempoReserva()
        {
            string Chave = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string Valor = ConsultarValorConfiguracao(Chave);

            return int.Parse(Valor);
        }

    }
}
