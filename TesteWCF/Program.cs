using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            var servico = new com.somee.smartparking.Service1();

            string teste = servico.GetData(10, true);

            Console.WriteLine("Teste: " + teste);

            Console.ReadLine();
        }
    }
}
