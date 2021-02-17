using ByteBank.Models.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Parceiros
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
        private AutenticacaoHelper _auteticacaoHelper = new AutenticacaoHelper();
        /// <summary>
        /// Método de autenticação
        /// </summary>
        /// <param name="senha">Senha do parceiro comercial</param>
        /// <returns></returns>
        public bool Autenticar(string senha)
        {
            return _auteticacaoHelper.CompararSenha(Senha, senha);
        }
    }
}
