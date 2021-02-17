using ByteBank.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Sistemas
{   
    /// <summary>
    /// Calcula a bonificação de acordo com cada funcionário
    /// </summary>
    public class GerenciadorDeBonificacao
    {
        private double _totalBonificacao;
        ///<inheritdoc>
        public void Registrar(Funcionario funcionario) => _totalBonificacao += funcionario.GetBonificacao();
        ///<inheritdoc>
        internal protected double GetBonificacao() => _totalBonificacao;
    }
}
