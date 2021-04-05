using ByteBank.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Contas
{
    /// <summary>
    /// Define uma conta corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente
    {

        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public int ContadorSaquesNaoPermitidos {get; private set;}
        public int ContadorTransferenciaNaoPermitidos { get; private set; }
        public int Numero { get;}
        public int Agencia { get; }

        private double _saldo = 100;
        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero</param>
        /// <param name="numero">Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero</param>
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
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento  <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/>.</exception>
        /// <param name="valor">Representa o valor do saque, deve ser maior que 0 e menor que o <see cref="Saldo"/>.</param>
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
        /// <exception cref="ArgumentException">Exceção lançada quando o <paramref name="valor"/> é maior do que o <see cref="Saldo"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o <paramref name="valor"/> é maior da propriedade <see cref="Saldo"/>.</exception>
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
        /// <summary>
        /// Sobreescrita do método ToString
        /// </summary>
        /// <returns>Número, Agência e Saldo</returns>
        public override string ToString()
        {
            return $"Número:{Numero} Agência:{Agencia} Saldo: R${Saldo}";
            //return "Número:" +  Numero + " Agência:" + Agencia + " Saldo: R$" + Saldo ;
        }
        /// <summary>
        /// Verifica igualdade
        /// </summary>
        /// <param name="obj">Objeto de Conta Corrente</param>
        /// <returns>True se o objeto especificado for igual ao objeto corrente</returns>
        public override bool Equals(object obj)
        {
            ContaCorrente outraConta = obj as ContaCorrente;

            if (outraConta == null)
            {
                return false;
            }

            return Numero == outraConta.Numero && Agencia == outraConta.Agencia;
        }

    }
}
