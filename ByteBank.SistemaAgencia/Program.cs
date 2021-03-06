using ByteBank.Models.Contas;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia 
{
    class Program
    {
        static void Main(string[] args)
        {

            string urlParametros = "https://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtractValueArgumentsURL extrator = new ExtractValueArgumentsURL(urlParametros);

            string valor = extrator.GetValor("MoeDaOriGem");
            Console.WriteLine(valor);
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
