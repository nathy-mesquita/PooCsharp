using ByteBank.Models.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Funcionarios
{
    /// <summary>
    /// Diretor derivado de FuncionárioAutenticavel
    /// </summary>
    public class Diretor : FuncionarioAutenticavel
    {
        /// <summary>
        /// Intância da classe 
        /// </summary>
        /// <param name="cpf">Cpf do Diretor</param>
        public Diretor(string cpf) : base (5000, cpf)
        {
        }
        /// <summary>
        /// Médoto de bonificação
        /// </summary>
        /// <returns></returns>
        internal protected override double GetBonificacao() => Salario * 0.5;
        /// <summary>
        /// Método aumentar salário
        /// </summary>
        public override void AumentarSalario() => Salario *= 1.15;

        
    }
}
