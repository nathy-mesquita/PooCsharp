using ByteBank.Funcionarios;
using ByteBank.Parceiros;
using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //CalcularBonificacao();
            UsarSistema();
            Console.ReadLine();
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
