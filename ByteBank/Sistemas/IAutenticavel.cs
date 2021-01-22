using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Sistemas
{
    /// <summary>
    /// Interface (contrato) para autenticação de usuário
    /// </summary>
    public interface IAutenticavel
    {

        /// <summary>
        /// Assinatura do método autenticável
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        bool Autenticar(string senha);
    }
}
