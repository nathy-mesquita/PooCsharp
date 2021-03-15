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
        }
    }
}
