using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia
{
    public static class ListExtensions
    {
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        {
            foreach (int item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }

        #region ConsoleWriteLine
        public static void Print(this object obj)
        {
            Console.WriteLine(obj);
        }
        #endregion

    }
}
