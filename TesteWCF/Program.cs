using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteWCF.smartparking;

namespace TesteWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            var servico = new Servico();

            string teste = servico.GetData(10, true);

            Console.WriteLine("Teste: " + teste);

            Console.ReadLine();
        }
    }
}
