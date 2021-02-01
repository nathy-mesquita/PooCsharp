using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Exceptions
{
    ///<inheritdoc>
    public class OperaçãoFinanceiraException : Exception
    {
        ///<inheritdoc>
        public OperaçãoFinanceiraException()
        {

        }
        ///<inheritdoc>
        public OperaçãoFinanceiraException(string mensagem)
            : base(mensagem)
        {

        }
        ///<inheritdoc>
        public OperaçãoFinanceiraException(string mensagem, Exception excecaoInterna)
            :base(mensagem, excecaoInterna)
        {

        }

    }
}
