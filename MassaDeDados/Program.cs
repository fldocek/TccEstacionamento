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
        static int indexRandom = 0;

        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Iniciando Programa...");

                ParkingDBEntities ct = new ParkingDBEntities();

                //GerarVagas(ct);
                //GerarClientes(ct);
                AjustarCPF(ct);

                Console.WriteLine("Salvando no Banco de Dados...");

                ct.SaveChanges();

                Console.WriteLine("Programa concluído!");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                Console.WriteLine("\nPilha: " + ex.StackTrace);
                Console.ReadLine();
            }

        }

        private static void GerarVagas(ParkingDBEntities ct)
        {

            Console.WriteLine("Apagando Registros Antigos...");

            foreach (var E in ct.Vaga.ToList())
            {
                ct.Vaga.Remove(E);
            }

            foreach (var E in ct.Bloco.ToList())
            {
                ct.Bloco.Remove(E);
            }

            foreach (var E in ct.Andar.ToList())
            {
                ct.Andar.Remove(E);
            }

            Console.WriteLine("Criando Registros Novos...");

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

        }

        private static void GerarClientes(ParkingDBEntities ct)
        {

            Console.WriteLine("Apagando Registros Antigos...");


            foreach (var E in ct.Carro.ToList())
            {
                ct.Carro.Remove(E);
            }

            foreach (var E in ct.Cliente.ToList())
            {
                ct.Cliente.Remove(E);
            }

            Console.WriteLine("Criando Registros Novos...");


            Random rnd = new Random();

            int NumPessoas = 100;

            List<string> Nomes = new List<String>();
            List<string> SobreNomes = new List<String>();
            List<string> Marcas = new List<String>();

            Nomes.Add("Agatha");
            Nomes.Add("Alana");
            Nomes.Add("Alexandre");
            Nomes.Add("Alice");
            Nomes.Add("Alícia");
            Nomes.Add("Amanda");
            Nomes.Add("Ana");
            Nomes.Add("Ana Beatriz");
            Nomes.Add("Ana Carolina");
            Nomes.Add("Ana Clara");
            Nomes.Add("Ana Julia");
            Nomes.Add("Ana Laura");
            Nomes.Add("Ana Lívia");
            Nomes.Add("Ana Luiza");
            Nomes.Add("Ana Sophia");
            Nomes.Add("André");
            Nomes.Add("Anthony");
            Nomes.Add("Antonella");
            Nomes.Add("Antonio");
            Nomes.Add("Arthur");
            Nomes.Add("Augusto");
            Nomes.Add("Bárbara");
            Nomes.Add("Beatriz");
            Nomes.Add("Benício");
            Nomes.Add("Benjamin");
            Nomes.Add("Bernardo");
            Nomes.Add("Betina");
            Nomes.Add("Bianca");
            Nomes.Add("Brenda");
            Nomes.Add("Breno");
            Nomes.Add("Bruna");
            Nomes.Add("Bruno");
            Nomes.Add("Bryan");
            Nomes.Add("Caio");
            Nomes.Add("Calebe");
            Nomes.Add("Camila");
            Nomes.Add("Carlos Eduardo");
            Nomes.Add("Carolina");
            Nomes.Add("Caroline");
            Nomes.Add("Catarina");
            Nomes.Add("Cauã");
            Nomes.Add("Cauê");
            Nomes.Add("Cecília");
            Nomes.Add("Clara");
            Nomes.Add("Daniel");
            Nomes.Add("Danilo");
            Nomes.Add("Davi");
            Nomes.Add("Débora");
            Nomes.Add("Diego");
            Nomes.Add("Diogo");
            Nomes.Add("Eduarda");
            Nomes.Add("Eduardo");
            Nomes.Add("Elisa");
            Nomes.Add("Eloá");
            Nomes.Add("Emanuel");
            Nomes.Add("Emanuelly");
            Nomes.Add("Emily");
            Nomes.Add("Enrico");
            Nomes.Add("Enzo");
            Nomes.Add("Enzo Gabriel");
            Nomes.Add("Erick");
            Nomes.Add("Ester");
            Nomes.Add("Evelyn");
            Nomes.Add("Felipe");
            Nomes.Add("Fernanda");
            Nomes.Add("Fernando");
            Nomes.Add("Francisco");
            Nomes.Add("Gabriel");
            Nomes.Add("Gabriela");
            Nomes.Add("Gabrielly");
            Nomes.Add("Giovanna");
            Nomes.Add("Giovanni");
            Nomes.Add("Guilherme");
            Nomes.Add("Gustavo");
            Nomes.Add("Hadassa");
            Nomes.Add("Heitor");
            Nomes.Add("Helena");
            Nomes.Add("Heloisa");
            Nomes.Add("Henrique");
            Nomes.Add("Henry");
            Nomes.Add("Hugo");
            Nomes.Add("Iago");
            Nomes.Add("Ian");
            Nomes.Add("Igor");
            Nomes.Add("Isaac");
            Nomes.Add("Isabel");
            Nomes.Add("Isabella");
            Nomes.Add("Isabelle");
            Nomes.Add("Isadora");
            Nomes.Add("Jennifer");
            Nomes.Add("Joana");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João");
            Nomes.Add("João Gabriel");
            Nomes.Add("João Guilherme");
            Nomes.Add("João Lucas");
            Nomes.Add("João Miguel");
            Nomes.Add("João Paulo");
            Nomes.Add("João Pedro");
            Nomes.Add("João Vitor");
            Nomes.Add("Joaquim");
            Nomes.Add("Juan");
            Nomes.Add("Julia");
            Nomes.Add("Juliana");
            Nomes.Add("Julio César");
            Nomes.Add("Kaique");
            Nomes.Add("Kamilly");
            Nomes.Add("Kevin");
            Nomes.Add("Laís");
            Nomes.Add("Lara");
            Nomes.Add("Larissa");
            Nomes.Add("Laura");
            Nomes.Add("Lavínia");
            Nomes.Add("Leonardo");
            Nomes.Add("Letícia");
            Nomes.Add("Levi");
            Nomes.Add("Lívia");
            Nomes.Add("Lorena");
            Nomes.Add("Lorenzo");
            Nomes.Add("Luan");
            Nomes.Add("Luana");
            Nomes.Add("Lucas");
            Nomes.Add("Lucas Gabriel");
            Nomes.Add("Lucca");
            Nomes.Add("Luiz Felipe");
            Nomes.Add("Luiz Fernando");
            Nomes.Add("Luiz Guilherme");
            Nomes.Add("Luiz Gustavo");
            Nomes.Add("Luiz Henrique");
            Nomes.Add("Luiz Miguel");
            Nomes.Add("Luiz Otávio");
            Nomes.Add("Luiza");
            Nomes.Add("Luna");
            Nomes.Add("Maitê");
            Nomes.Add("Manuela");
            Nomes.Add("Marcela");
            Nomes.Add("Marcelo");
            Nomes.Add("Marcos Vinicius");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria");
            Nomes.Add("Maria Alice");
            Nomes.Add("Maria Cecília");
            Nomes.Add("Maria Clara");
            Nomes.Add("Maria Eduarda");
            Nomes.Add("Maria Fernanda");
            Nomes.Add("Maria Júlia");
            Nomes.Add("Maria Luiza");
            Nomes.Add("Maria Sophia");
            Nomes.Add("Maria Vitória");
            Nomes.Add("Mariah");
            Nomes.Add("Mariana");
            Nomes.Add("Mariane");
            Nomes.Add("Marina");
            Nomes.Add("Matheus");
            Nomes.Add("Matheus Henrique");
            Nomes.Add("Melissa");
            Nomes.Add("Miguel");
            Nomes.Add("Milena");
            Nomes.Add("Mirella");
            Nomes.Add("Murilo");
            Nomes.Add("Natália");
            Nomes.Add("Nathan");
            Nomes.Add("Nicolas");
            Nomes.Add("Nicole");
            Nomes.Add("Nina");
            Nomes.Add("Olivia");
            Nomes.Add("Otávio");
            Nomes.Add("Pedro");
            Nomes.Add("Pedro Henrique");
            Nomes.Add("Pedro Lucas");
            Nomes.Add("Pietra");
            Nomes.Add("Pietro");
            Nomes.Add("Rafael");
            Nomes.Add("Rafaela");
            Nomes.Add("Raquel");
            Nomes.Add("Raul");
            Nomes.Add("Rayssa");
            Nomes.Add("Rebeca");
            Nomes.Add("Renan");
            Nomes.Add("Renato");
            Nomes.Add("Ricardo");
            Nomes.Add("Rodrigo");
            Nomes.Add("Ryan");
            Nomes.Add("Sabrina");
            Nomes.Add("Samuel");
            Nomes.Add("Sarah");
            Nomes.Add("Sophia");
            Nomes.Add("Sophie");
            Nomes.Add("Stefany");
            Nomes.Add("Stella");
            Nomes.Add("Thales");
            Nomes.Add("Theo");
            Nomes.Add("Thiago");
            Nomes.Add("Tomás");
            Nomes.Add("Valentina");
            Nomes.Add("Vinicius");
            Nomes.Add("Vitor");
            Nomes.Add("Vitor Gabriel");
            Nomes.Add("Vitor Hugo");
            Nomes.Add("Vitória");
            Nomes.Add("Yasmin");
            Nomes.Add("Yuri");

            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("da Silva");
            SobreNomes.Add("dos Santos");
            SobreNomes.Add("dos Santos");
            SobreNomes.Add("dos Santos");
            SobreNomes.Add("dos Santos");
            SobreNomes.Add("dos Santos");
            SobreNomes.Add("Oliveira");
            SobreNomes.Add("de Souza");
            SobreNomes.Add("Pereira");
            SobreNomes.Add("Costela");
            SobreNomes.Add("de Carvalho");
            SobreNomes.Add("de Almeida");
            SobreNomes.Add("Ferreira");
            SobreNomes.Add("Ribeiro");
            SobreNomes.Add("Rodrigues");
            SobreNomes.Add("Gomes");
            SobreNomes.Add("Lima");
            SobreNomes.Add("Martins");
            SobreNomes.Add("da Rocha");
            SobreNomes.Add("Alves");
            SobreNomes.Add("de Araújo");
            SobreNomes.Add("Pinto");
            SobreNomes.Add("Barbosa");
            SobreNomes.Add("de Castro");
            SobreNomes.Add("Fernandes");
            SobreNomes.Add("de Melo");
            SobreNomes.Add("de Azevedo");
            SobreNomes.Add("de Barros");
            SobreNomes.Add("Cardoso");
            SobreNomes.Add("Correia");
            SobreNomes.Add("da Cunha");
            SobreNomes.Add("Dias");

            Marcas.Add("Chevrolet - Agile");
            Marcas.Add("Chevrolet - Astra Hatch");
            Marcas.Add("Chevrolet - Astra Sedan");
            Marcas.Add("Chevrolet - Blazer");
            Marcas.Add("Chevrolet - Camaro");
            Marcas.Add("Chevrolet - Captiva");
            Marcas.Add("Chevrolet - Celta");
            Marcas.Add("Chevrolet - Classic");
            Marcas.Add("Chevrolet - Cobalt");
            Marcas.Add("Chevrolet - Corsa Hatch");
            Marcas.Add("Chevrolet - Corsa Sedã");
            Marcas.Add("Chevrolet - Cruze");
            Marcas.Add("Chevrolet - Cruze Sport6");
            Marcas.Add("Chevrolet - Malibu");
            Marcas.Add("Chevrolet - Meriva");
            Marcas.Add("Chevrolet - Montana");
            Marcas.Add("Chevrolet - Omega");
            Marcas.Add("Chevrolet - Onix");
            Marcas.Add("Chevrolet - Prisma");
            Marcas.Add("Chevrolet - S10");
            Marcas.Add("Chevrolet - Sonic");
            Marcas.Add("Chevrolet - Spin");
            Marcas.Add("Chevrolet - Tracker");
            Marcas.Add("Chevrolet - Trailblazer");
            Marcas.Add("Chevrolet - Vectra");
            Marcas.Add("Chevrolet - Vectra GT");
            Marcas.Add("Chevrolet - Zafira");

            Marcas.Add("Audi - A1");
            Marcas.Add("Audi - A3 Sedan");
            Marcas.Add("Audi - A4 Avant");
            Marcas.Add("Audi - R8 GT");
            Marcas.Add("Audi - RS 3 Sportback");
            Marcas.Add("Audi - RS 5");
            Marcas.Add("Audi - RS6 Avant");
            Marcas.Add("Audi - TT Coupé");
            Marcas.Add("Audi - TT Roadster");

            Marcas.Add("Fiat - 500");
            Marcas.Add("Fiat - 500 Abarth");
            Marcas.Add("Fiat - Bravo");
            Marcas.Add("Fiat - Doblò");
            Marcas.Add("Fiat - Doblò Cargo");
            Marcas.Add("Fiat - Ducato");
            Marcas.Add("Fiat - Fiorino");
            Marcas.Add("Fiat - Freemont");
            Marcas.Add("Fiat - Grand Siena");
            Marcas.Add("Fiat - Idea");
            Marcas.Add("Fiat - Linea");
            Marcas.Add("Fiat - Mille");
            Marcas.Add("Fiat - Palio");
            Marcas.Add("Fiat - Palio Adventure");
            Marcas.Add("Fiat - Palio Weekend");
            Marcas.Add("Fiat - Punto");
            Marcas.Add("Fiat - Siena EL");
            Marcas.Add("Fiat - Strada");
            Marcas.Add("Fiat - Uno");

            Marcas.Add("Ford - Courier");
            Marcas.Add("Ford - EcoSport");
            Marcas.Add("Ford - Edge");
            Marcas.Add("Ford - F-250");
            Marcas.Add("Ford - Fiesta Rocam Hatch");
            Marcas.Add("Ford - Fiesta Rocam Sedan");
            Marcas.Add("Ford - Focus Hatch");
            Marcas.Add("Ford - Focus Sedan");
            Marcas.Add("Ford - Fusion");
            Marcas.Add("Ford - Ka");
            Marcas.Add("Ford - New Fiesta");
            Marcas.Add("Ford - New Fiesta Hatch");
            Marcas.Add("Ford - Ranger");
            Marcas.Add("Ford - Transit");

            Marcas.Add("Renault - Clio");
            Marcas.Add("Renault - Duster");
            Marcas.Add("Renault - Fluence");
            Marcas.Add("Renault - Grand Tour");
            Marcas.Add("Renault - Kangoo Express");
            Marcas.Add("Renault - Logan");
            Marcas.Add("Renault - Master");
            Marcas.Add("Renault - Sandero");
            Marcas.Add("Renault - Sandero Stepway");
            Marcas.Add("Renault - Symbol");

            Marcas.Add("Volkswagen - Amarok");
            Marcas.Add("Volkswagen - Crossfox");
            Marcas.Add("Volkswagen - Fox");
            Marcas.Add("Volkswagen - Fusca");
            Marcas.Add("Volkswagen - Gol");
            Marcas.Add("Volkswagen - Gol G4");
            Marcas.Add("Volkswagen - Golf");
            Marcas.Add("Volkswagen - Jetta");
            Marcas.Add("Volkswagen - Jetta Variant");
            Marcas.Add("Volkswagen - Kombi");
            Marcas.Add("Volkswagen - Parati");
            Marcas.Add("Volkswagen - Passat");
            Marcas.Add("Volkswagen - Passat Variant");
            Marcas.Add("Volkswagen - Polo");
            Marcas.Add("Volkswagen - Polo Sedan");
            Marcas.Add("Volkswagen - Saveiro");
            Marcas.Add("Volkswagen - Space Cross");
            Marcas.Add("Volkswagen - SpaceFox");
            Marcas.Add("Volkswagen - Tiguan");
            Marcas.Add("Volkswagen - Touareg");
            Marcas.Add("Volkswagen - Up!");
            Marcas.Add("Volkswagen - Voyage");


            Cliente cliente;
            Carro carro;

            int N, SN, M, diaCadastro, diaNascimento, anoNascimento, qtdCarros;

            rnd = new Random(indexRandom);
            indexRandom++;

            for (int i = 0; i < NumPessoas; i++)
            {

                N = rnd.Next(Nomes.Count);
                SN = rnd.Next(SobreNomes.Count);
                
                diaCadastro = rnd.Next(NumPessoas);
                diaNascimento = rnd.Next(NumPessoas);
                anoNascimento = rnd.Next(19, 60);

                cliente = new Cliente();
                cliente.Nome = Nomes[N] + " " + SobreNomes[SN];
                cliente.Sexo = ((i % 2) == 0)? "M" : "F";

                cliente.Data_Cadastrado = DateTime.Now.AddDays((-1) * diaCadastro);
                cliente.Data_Nascimento = DateTime.Now.AddDays((-1) * diaNascimento).AddYears((-1) * anoNascimento);

                qtdCarros = rnd.Next(1, 4);

                for (int j = 0; j < qtdCarros; j++)
                {
                    M = rnd.Next(Marcas.Count);                    

                    carro = new Carro();

                    carro.Placa = GerarPlaca();
                    carro.Marca = Marcas[M];

                    cliente.Carro.Add(carro);

                }

                ct.Cliente.Add(cliente);
            }
            
        }

        private static void AjustarCPF(ParkingDBEntities ct)
        {

            Console.WriteLine("Ajustando registros ...");

            string CpfNovo = "";

            List<string> listaCPF = new List<string>();

            foreach (var cliente in ct.Cliente)
            {
                CpfNovo = GerarCpf();
                
                while (listaCPF.Contains(CpfNovo))
                {
                    CpfNovo = GerarCpf();
                }

                listaCPF.Add(CpfNovo);

                cliente.CPF = CpfNovo;
            }

        }

        private static string GerarPlaca()
        {
            string Placa = "";

            Random random = new Random(indexRandom);

            indexRandom++;

            int size = 3;

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            Placa = builder.ToString().ToUpper();

            Placa += "-";

            Placa += random.Next(10).ToString();
            Placa += random.Next(10).ToString();
            Placa += random.Next(10).ToString();
            Placa += random.Next(10).ToString();

            return Placa;
        }
        
        public static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random(indexRandom);
            indexRandom++;

            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

    }

}
