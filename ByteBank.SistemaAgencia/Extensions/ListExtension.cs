using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia.Extensions
{
    public static class ListExtension
    {
        public static void AdicionarVarios <T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }
    }
}
