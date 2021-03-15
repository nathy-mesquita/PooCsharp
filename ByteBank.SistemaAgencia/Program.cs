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
