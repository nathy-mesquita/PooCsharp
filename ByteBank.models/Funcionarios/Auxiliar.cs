using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Funcionarios
{
    /// <summary>
    /// Auxiliar derivado de Funcionário 
    /// </summary>
    public class Auxiliar : Funcionario
    {
        /// <summary>
        /// Intância da classe 
        /// </summary>
        /// <param name="cpf">Cpf do auxiliar</param>
        public Auxiliar( string cpf) : base(2000, cpf)
        {
        }

        /// <summary>
        /// Método aumentar salário
        /// </summary>
        public override void AumentarSalario() => Salario *= 1.10;
        /// <summary>
        /// Médoto de bonificação
        /// </summary>
        /// <returns></returns>
        internal protected override double GetBonificacao() => Salario * 0.20;
    }
}
