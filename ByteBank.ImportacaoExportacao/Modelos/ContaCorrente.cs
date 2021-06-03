using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteBank.ImportacaoExportacao.Modelos
{
    public class ContaCorrente
    {
        public int Numero { get; set; }
        public int Agencia { get; set; }
        public double Saldo { get; set; }
        public Cliente Titular { get; set; }

        public ContaCorrente(int numero, int agencia)
        {
            Numero = numero;
            Agencia = agencia;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de deposito deve ser maior que zero.", nameof(valor));
            }

            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de saque deve ser maior que zero.", nameof(valor));
            }

            if (valor > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }

            Saldo += valor;
        }

    }
}
