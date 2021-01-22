using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    /// <summary>
    /// Designer derivado de Funcionário
    /// </summary>
    public class Designer : Funcionario
    {
        /// <summary>
        /// Intância da classe 
        /// </summary>
        /// <param name="cpf">Cpf do designer</param>
        public Designer(string cpf) : base(3000, cpf)
        {
        }
        /// <summary>
        /// Método aumentar salário
        /// </summary>
        public override void AumentarSalario() => Salario *= 1.11;
        /// <summary>
        /// Médoto de bonificação
        /// </summary>
        /// <returns></returns>
        public override double GetBonificacao() => Salario * 0.17;
    }
}
