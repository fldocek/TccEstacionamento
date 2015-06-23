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
            try
            {
                Console.WriteLine("Iniciando Chamada ao serviço ...\n");

                var servico = new Servico();

                dtoVaga[] ListaVagas = servico.ListarVagasDisponiveis();

                foreach (var vaga in ListaVagas)
                {
                    Console.WriteLine();

                    Console.WriteLine(string.Format("Vaga {0} [ Id={1}, Andar={2}, Bloco={3}, Livre={4} ]",
                                                    vaga.Nome, vaga.Id.ToString(), vaga.Andar, vaga.Bloco, vaga.Disponivel.ToString()));

                }

                Console.WriteLine("\nFim do método!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
