using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace MassaDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Iniciando Programa...");

                ParkingDBEntities ct = new ParkingDBEntities();

                Console.WriteLine("Apagando Registros Antigos...");

                foreach (Vaga V in ct.Vaga.ToList())
                {
                    ct.Vaga.Remove(V);
                }

                for (int i = 1; i < 5; i++)
                {

                    Andar andar = new Andar();
                    andar.Nome = string.Format("{0}º Andar", i);

                    Console.WriteLine("Andar: " + andar.Nome);

                    char NomeBloco = 'A';
                    int NomeVaga = 1;

                    for (int j = 0; j < 10; j++)
                    {
                        Bloco bloco = new Bloco();
                        bloco.Nome = NomeBloco.ToString() + i.ToString();

                        andar.Bloco.Add(bloco);

                        NomeBloco++;

                        Console.WriteLine(" Bloco: " + bloco.Nome);

                        for (int k = 1; k < 11; k++)
                        {
                            Vaga vaga = new Vaga();
                            vaga.Nome = NomeVaga.ToString();
                            vaga.Situacao = "Livre";

                            bloco.Vaga.Add(vaga);

                            NomeVaga++;

                            Console.WriteLine("  Vaga: " + vaga.Nome);

                        }

                        Console.WriteLine();

                    }

                    Console.WriteLine();

                    ct.Andar.Add(andar);
                }

                Console.WriteLine("Iniciando transação...");

                ct.SaveChanges();

                Console.WriteLine("Programa concluído!");

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("Erro: " + ex.StackTrace);
                Console.ReadLine();
            }

        }
    }
}
