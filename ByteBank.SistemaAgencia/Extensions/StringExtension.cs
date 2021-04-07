using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia.Extensions
{
    public static class StringExtension
    {
        #region ConsoleWriteLine
        public static void Print(this object obj)
        {
            Console.WriteLine(obj);
        }
        #endregion

    }
}
