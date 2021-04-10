using System;
using System.Text;
using System.Linq;
using ByteBank.Models.Contas;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x == y)
                return 0;

            if (x.Agencia == null)
                return -1;

            if (y.Agencia == null)
                return -1;

            return x.Agencia.CompareTo(y.Agencia);

        }
    }
}
