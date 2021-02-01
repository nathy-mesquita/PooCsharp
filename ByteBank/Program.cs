using ByteBank.Contas;
using ByteBank.Exceptions;
using ByteBank.Funcionarios;
using ByteBank.Parceiros;
using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContasWithUsing();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO METODO MAIN");
            }

            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();
        }
        public static void CarregarContasWithUsing()
        {
            using(LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt"))
            {
                leitor.LerProximaLinha();
            }
        }
        public static void CarregarContas()
        {
            LeitorDeArquivo leitor = null;
            try
            {
                leitor = new LeitorDeArquivo("contasl.txt");
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            catch (IOException)
            {
                Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
            }
            finally
            {
                if (leitor != null)
                { 
                    leitor.Dispose();
                } 
            }
            
        }
        public static void TestaInnerException()
        {

            try
            {
                ContaCorrente conta = new ContaCorrente(123, 2345);
                ContaCorrente conta2 = new ContaCorrente(123, 2346);

                conta2.Sacar(100000);
            }
            catch (OperaçãoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da INNER EXECEPTION (exceção interna):");

                Console.WriteLine(e.InnerException);
            }
           
        }
        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir
        private static void Metodo()
        {
            TestaDivisao(0);
        }
        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }
        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
                throw;
                Console.WriteLine("Código depois do throw");
            }
        }
        public static void TestaSaldoInsuficiente()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(123, 2345);
                ContaCorrente conta2 = new ContaCorrente(123, 2346);

                conta2.Transferir(100000, conta);
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Saldo);
                Console.WriteLine(ex.ValorSaque);

                Console.WriteLine(ex.StackTrace);

                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteExcepition");
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "numero")
                {

                }
                Console.WriteLine("Argumentos com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu um Exceção do tipo ArgumentoException");
                Console.WriteLine(ex.Message);
            }
        }
        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();


            GerenteDeConta maria = new GerenteDeConta("765.098.345-77");
            maria.Nome = "Maria";
            maria.Senha = "abcd";

            Diretor joao = new Diretor("123.432.324-88");
            joao.Nome = "João";
            joao.Senha = "1234";

            ParceiroComercial parceiro = new ParceiroComercial();
            parceiro.Senha = "131313";


            sistemaInterno.Logar(maria, "abcd");
            sistemaInterno.Logar(joao, "1234");
            sistemaInterno.Logar(parceiro, "131313");
        }
        public static void CalcularBonificacao()
        {
            GerenciadorDeBonificacao gerenciadorDeBonificacao = new GerenciadorDeBonificacao();

            Funcionario joao = new Auxiliar("789.098.102-88");
            joao.Nome = "João";

            Funcionario heloisa = new Designer("764.987.123.88");
            heloisa.Nome = "Heloisa";

            Funcionario julia = new Diretor("604.097.183-77");
            julia.Nome = "Antonia Julia";

            Funcionario maria = new GerenteDeConta("765.098.345-77");
            maria.Nome = "Maria";


            gerenciadorDeBonificacao.Registrar(joao);
            gerenciadorDeBonificacao.Registrar(heloisa);
            gerenciadorDeBonificacao.Registrar(julia);
            gerenciadorDeBonificacao.Registrar(maria);


            Console.WriteLine("Total de bonificação no mês R$" +
                gerenciadorDeBonificacao.GetBonificacao());

        }
    }
}
