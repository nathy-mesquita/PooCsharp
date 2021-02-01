using ByteBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Contas
{
    public class ContaCorrente
    {

        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public int ContadorSaquesNaoPermitidos {get; private set;}
        public int ContadorTransferenciaNaoPermitidos { get; private set; }

        /// <summary>
        /// Pripriedade apenas de Leitura "readonly", pois não tem o set. 
        /// Poderá ser usado apenas no construtor.
        /// </summary>
        public int Numero { get;}
        /// <summary>
        /// Propriedade apenas de Leitura "readonly", pois não tem o set.
        /// Poderá ser usada apenas no construtor.
        /// </summary>
        public int Agencia { get; }
        private double _saldo = 100;
        ///<inheritdoc>
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                ArgumentException excecao = new ArgumentException("O argumento agencia tem que ser maior que 0.",nameof(agencia));
                throw excecao;
            }
            if (numero <= 0)
            {
                ArgumentException excecao = new ArgumentException("O argumento numero tem que ser maior que 0.", "numero");
                throw excecao;
            }
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        /// <summary>
        /// Informa o saldo na conta do cliente
        /// </summary>
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }
        /// <summary>
        /// Saca o valor da connta do cliente
        /// </summary>
        /// <param name="valor">valor para saque</param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                //Mensagem personalizada de exceção passada pelo contrutor da classe
                //throw new SaldoInsuficienteException("Saldo Insuficiente para o saque no valor de " + valor);
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            _saldo -= valor;
        }
        /// <summary>
        /// Deposita um valor na conta do cliente
        /// </summary>
        /// <param name="valor">valor para depósito</param>
        public void Depositar(double valor)
        {
            _saldo += valor;
        }
        /// <summary>
        /// Transfere um valor entre contas
        /// </summary>
        /// <param name="valor">valor para transferência</param>
        /// <param name="contaDestino">conta de destino para tranferência</param>
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }
            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciaNaoPermitidos++;
                throw new OperaçãoFinanceiraException ("Operação não realizada.", ex);
            }
            contaDestino.Depositar(valor);
        }
    }
}
