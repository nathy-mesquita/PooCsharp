using System;
using Humanizer;
using System.Text;
using System.Linq;
using ByteBank.Models;
using ByteBank.Models.Contas;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia 
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> idades = new List<int>();
            
            idades.AdicionarVarios(6, 7, 8, 9);

            for (int i = 0; i < idades.Count; i++)
            {
                idades[i].Print();
            }

            ListExtensions.AdicionarVarios(idades, 1, 2, 3, 4, 5);

            Console.ReadLine();
        }

        #region [Métodos Estáticos Auxiliares]

        public static void TestaLista()
        {
            Lista<int> idades = new Lista<int>();

            idades.AdicionarVarios(2, 3, 4, 5, 34);
        }

        public static void TestaListaDeIdadesObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.AdicionarVarios(2, 34, 23, 16, 17, 54);
            listaDeIdades.Adicionar("Adicionando texto qualquer");

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"{idade} no indice {i}");
            }
        }

        public static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ContaCorrente contaNathaly = new ContaCorrente(9999, 99999);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaNathaly,
                new ContaCorrente(1234, 12340),
                new ContaCorrente(1234, 12341),
                new ContaCorrente(1234, 12342)
            };

            lista.AdicionarVarios(contas);
            lista.AdicionarVarios(
                contaNathaly,
                new ContaCorrente(1234, 12340),
                new ContaCorrente(1234, 12341),
                new ContaCorrente(1234, 12342)
                );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista.GetItemNoIndice(i);
                Console.WriteLine($"Item na posição:{i} - conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }

        }

        /// <summary>
        /// Soma de vários inteiros
        /// </summary>
        /// <param name="numeros">Números que deseja somar</param>
        /// <example>SomarVarios(1, 2, 4, 5, 6)</example>
        /// <returns>Soma</returns>
        public static int SomarVarios(params int[] numeros)
        {
            int soma = 0;
            foreach (int numero in numeros)
            {
               soma += numero;
            }
            return soma;
        }

        /// <summary>
        /// Soma de pares. Caso a lista seja impar é ignorado o último item da lista.
        /// </summary>
        /// <param name="numeros">Números que deseja somar</param>
        /// <example>SomarNumeros(new int[] {1,2,3,4,5,6,7});</example>
        public static void SomarNumeros (int[] numeros)
        {
            for (int i = 0; i < numeros.Length-1; i+=2)
            {
                int primeiroNumero = numeros[i];
                int segundoNumero = numeros[i + 1];
                int soma = primeiroNumero + segundoNumero;
                Console.WriteLine($"{primeiroNumero} + {segundoNumero} = {soma}");
            }
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
        #endregion
    }

}