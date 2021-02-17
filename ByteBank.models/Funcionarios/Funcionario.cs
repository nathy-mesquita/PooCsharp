using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Funcionarios
{
    /// <summary>
    /// Classe abstrata de Funcionário
    /// </summary>
    public abstract class Funcionario
    {   
        /// <summary>
        /// Propriedade que contabiliza a quantidade total de funcionários
        /// </summary>
        public static int TotalDeFuncionarios { get; private set; }
        /// <summary>
        /// Propriedade Nome
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Propriedade CPF
        /// </summary>
        public string CPF { get; private set; }
        /// <summary>
        /// Propriedade Salario
        /// </summary>
        public double Salario { get; protected set; }
        

        /// <summary>
        /// Construtor da classe Base Funcionario
        /// </summary>
        /// <param name="salario">Salário do Funcionário</param>
        /// <param name="cpf">CPF do Funcionário</param>
        public Funcionario(double salario, string cpf)
        {
            Salario = salario;
            CPF = cpf;
            TotalDeFuncionarios++;
        }

       /// <summary>
       /// Método abstrato de Aumentar o Salário do Funcionário
       /// </summary>
        public abstract void AumentarSalario();
        /// <summary>
        /// Método abstrato que obtêm a bonificação do Funcionário
        /// </summary>
        /// <returns></returns>
        internal protected abstract double GetBonificacao();

    }
}
