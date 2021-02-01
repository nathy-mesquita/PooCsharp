using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Exceptions
{
    /// <summary>
    /// Criação de uma própria exceção do tipo SaldoInsuficienteException que deriva de Exception
    /// </summary>
    public class SaldoInsuficienteException
        : OperaçãoFinanceiraException
    {
        public double Saldo { get; }
        public double ValorSaque { get; }

        /// <summary>
        /// Construtor sem parâmetros.
        /// </summary>
        public SaldoInsuficienteException()
        {

        }
        /// <summary>
        /// Contrutor com verificação do saldo disponível e valor de saque
        /// </summary>
        /// <param name="saldo">Saldo disponível na conta</param>
        /// <param name="valorSaque">Valor solicitado para saque</param>
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentativa de saque no valor de R$" + valorSaque + " em uma conta com saldo de R$" + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
        /// <summary>
        /// Construtor com parâmetro de mensagem.
        /// </summary>
        /// <param name="mensagem">passa um informação personalizada da excação tratada</param>
        public SaldoInsuficienteException(string mensagem)
            : base(mensagem)
        {

        }
        ///<inheritdoc>
        public SaldoInsuficienteException(string mensagem, RankException execaoInterna)
            :base(mensagem, execaoInterna)
        {

        }
    }
}
