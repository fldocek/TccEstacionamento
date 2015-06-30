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

                Console.WriteLine("Listando Andares...\n");

                dtoAndar[] listaAndares = servico.ListarAndares();

                foreach (var andar in listaAndares)
                {

                    Console.WriteLine(string.Format("Andar: {0} [ Id={1}, Quantidade de Vagas={2}, Vagas Livres={3} ]",
                                                    andar.Nome, andar.Id.ToString(), andar.QtdVagas, andar.QtdLive));

                }

                Console.WriteLine();

                dtoAndar A1 = listaAndares.First();

                Console.WriteLine("Listando Blocos do andar " + A1.Nome + "...\n");

                dtoBloco[] listaBlocos = servico.ListarBlocos(A1.Id, true);

                foreach (var bloco in listaBlocos)
                {

                    Console.WriteLine(string.Format("Bloco: {0} [ Id={1}, Quantidade de Vagas={2}, Vagas Livres={3} ]",
                                                    bloco.Nome, bloco.Id.ToString(), bloco.QtdVagas, bloco.QtdLive));

                }

                Console.WriteLine();

                dtoBloco B1 = listaBlocos.First();

                Console.WriteLine("Listando vagas do bloco " + B1.Nome + "...\n");

                dtoVaga[] listaVagas = servico.ListarVagas(B1.Id, true);

                foreach (var vaga in listaVagas)
                {

                    Console.WriteLine(string.Format("Vaga: {0} [ Id={1}, Livre={2} ]",
                                                    vaga.Nome, vaga.Id.ToString(), vaga.Disponivel.ToString()));

                }

                Console.WriteLine();

                string CPF = "753.618.942-73";

                Console.WriteLine("Listando Carros do cliente de CPF " + CPF + "...\n");

                dtoCarro[] listaCarros = servico.ListarCarros(CPF);

                foreach (var carro in listaCarros)
                {
                    Console.WriteLine(string.Format("Carro: [ Id={0}, Marca={1}, Placa={2} ]",
                                                    carro.Id, carro.Marca, carro.Placa));

                }

                Console.WriteLine();
                
                dtoVaga V1 = listaVagas.First();
                dtoCarro C1 = listaCarros.First();

                Console.WriteLine("Reservando a primeira vaga...\n");

                bool concluidoComSucesso, resultSpecified;

                servico.ReservarVaga(V1.Id, true, C1.Id, true, out concluidoComSucesso, out resultSpecified);

                if (concluidoComSucesso)
                {
                    Console.WriteLine("Reserva feita com sucesso...\n");
                }

                Console.WriteLine("Listando vagas do bloco " + B1.Nome + "...\n");

                listaVagas = servico.ListarVagas(B1.Id, true);

                foreach (var vaga in listaVagas)
                {

                    Console.WriteLine(string.Format("Vaga: {0} [ Id={1}, Livre={2} ]",
                                                    vaga.Nome, vaga.Id.ToString(), vaga.Disponivel.ToString()));

                }

                Console.WriteLine();

                Console.WriteLine("Fim do método!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
