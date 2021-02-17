using ByteBank.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Sistemas
{
    /// <summary>
    /// Sistema interno que verifica a autenticidade dos usuários
    /// </summary>
    public class SistemaInterno
    {
        /// <summary>
        /// Método de fazer login 
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool Logar(IAutenticavel funcionario, string senha)
        {
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if (usuarioAutenticado)
            {
                Console.WriteLine("Bem-vindo ao sistema!");
                return true;
            }
            else
            {
                Console.WriteLine("Senha inválida");
                return false;
            }
        }

    }
}