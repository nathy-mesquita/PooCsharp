using ByteBank.Models.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Funcionarios
{
    /// <summary>
    /// Classe abstrata (pois não implementa os métodos da classe base Funcionário) e obtêm a interface Autenticavel
    /// </summary>
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        /// <summary>
        /// Propriedade do método Autenticar
        /// </summary>
        public string Senha { get;  set; }
        private AutenticacaoHelper _autenticacaoHelper = new AutenticacaoHelper();
        /// <summary>
        /// Construtor da classe, que passa os parâmetros para a classe base Funcionario
        /// </summary>
        /// <param name="salario">Salário do Funcioário</param>
        /// <param name="cpf">CPF do Funcioário</param>
        public  FuncionarioAutenticavel(double salario, string cpf) 
            : base(salario, cpf)
        {
        }
        /// <summary>
        /// Implementação do método Autenticar
        /// </summary>
        /// <param name="senha">Senha do Funcionário</param>
        /// <returns></returns>
        public bool Autenticar(string senha)
        {
            return _autenticacaoHelper.CompararSenha(Senha, senha);
        }

    }


}
