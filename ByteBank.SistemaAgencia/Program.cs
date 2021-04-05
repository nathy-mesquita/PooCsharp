using ByteBank.Models;
using ByteBank.Models.Contas;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia 
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente conntaNathaly = new ContaCorrente(1234, 123411);

            lista.Adicionar(conntaNathaly);

            lista.Adicionar( new ContaCorrente(1234, 12340)); 
            lista.Adicionar( new ContaCorrente(1234, 12341)); 
            lista.Adicionar( new ContaCorrente(1234, 123432));
            lista.Adicionar( new ContaCorrente(1234, 123433));
            lista.Adicionar( new ContaCorrente(1234, 123434));
            lista.Adicionar( new ContaCorrente(1234, 123435));
            lista.Adicionar( new ContaCorrente(1234, 123436));
            lista.Adicionar( new ContaCorrente(1234, 123437));
            lista.Adicionar( new ContaCorrente(1234, 123438));
            lista.Adicionar( new ContaCorrente(1234, 123439));
            lista.Adicionar( new ContaCorrente(1234, 1234310));



            Console.ReadLine();
        }

        public static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(0001, 1000),
                new ContaCorrente(0001, 1001),
                new ContaCorrente(0001, 1002)

            };


            for (int i = 0; i < contas.Length; i++)
            {
                Console.WriteLine($"Conta Corrente {i}: {contas[i].Numero}");
            }
        }

        public static void MediaDeIdadesComArray()
        {
            /*-------ARRAY de Inteiros com 5 posições---------*/
            //Criando um objeto de array
            int[] idades = new int[5];
            //Populando o Array
            idades[0] = 14;
            idades[1] = 45;
            idades[2] = 16;
            idades[3] = 22;
            idades[4] = 28;

            int somatorioIdades = 0;
            for (int i = 0; i < idades.Length; i++)
            {
                int idade = idades[i];
                Console.WriteLine($"Accessando o array idades no índice {i} = {idade}");
                somatorioIdades += idade;
            }
            int media = somatorioIdades / idades.Length;
            Console.WriteLine($"Média das idades: {media}");

        }

        public static void MetodoEquals()
        {
            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            ContaCorrente conta = new ContaCorrente(1212, 12121);

            if (carlos_1.Equals(conta))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            Console.ReadLine();
        }

        public static void ExpressaoRegular()
        {
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoteste = "Meu nome é Nathaly me ligue em (21)97938-79765";

            Match resultado = Regex.Match(textoteste, padrao);

            Console.WriteLine(Regex.IsMatch(textoteste, padrao));
            Console.WriteLine(resultado.Value);
            Console.ReadLine();
        }

        public static void DateCountdown()
        {
            DateTime dataFim = new DateTime(2021, 2, 28);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = TimeSpan.FromMinutes(40); //dataFim - DateTime.Now;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);
            Console.ReadLine();
        }
    }
}