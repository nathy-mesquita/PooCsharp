using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Sistemas
{
    ///<inheritdoc>
    internal class AutenticacaoHelper
    {
        public bool CompararSenha(string senhaValida, string senhaTentativa)
        {
            return senhaValida == senhaTentativa;
        }
    }
}
