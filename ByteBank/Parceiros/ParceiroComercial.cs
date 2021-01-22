using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Parceiros
{
    /// <summary>
    /// Parceiro comercial que assina o contrato de autenticar
    /// </summary>
    public class ParceiroComercial : IAutenticavel
    {
        /// <summary>
        /// Propiedade da senha
        /// </summary>
        public string Senha { get; set; }
        /// <summary>
        /// Método de autenticação
        /// </summary>
        /// <param name="senha">Senha do parceiro comercial</param>
        /// <returns></returns>
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}
