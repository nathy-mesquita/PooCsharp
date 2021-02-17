using ByteBank.Models.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Funcionarios
{
    /// <summary>
    /// Gerente de conta derivado de FuncionárioAutenticavel
    /// </summary>
    public class GerenteDeConta : FuncionarioAutenticavel
    {
        /// <summary>
        /// Intância da classe 
        /// </summary>
        /// <param name="cpf">Cpf do Gerente de Conta</param>
        public GerenteDeConta(string cpf) : base(4000, cpf)
        {
        }

        /// <summary>
        /// Método aumentar salário
        /// </summary>
        public override void AumentarSalario() => Salario *= 1.05;

        /// <summary>
        /// Médoto de bonificação
        /// </summary>
        /// <returns></returns>
        internal protected override double GetBonificacao() => Salario * 0.25;
    }
}
