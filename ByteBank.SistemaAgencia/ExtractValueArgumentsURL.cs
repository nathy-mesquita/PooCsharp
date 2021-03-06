using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtractValueArgumentsURL
    {
        private readonly string _argumentos;
        public string URL { get; }
        
        public ExtractValueArgumentsURL(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento não pode ser nulo ou vazio", nameof(url));
            }

            URL = url;

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);
        }

        public string GetValor(string nomeParametro)
        {
            string nomePametroNormalizado = nomeParametro.ToUpper();
            string argumentoNormalizado = _argumentos.ToUpper();

            string termo = nomePametroNormalizado + "=";
            int indiceTermo = argumentoNormalizado.IndexOf(termo);

            string result = _argumentos.Substring(indiceTermo + termo.Length);
            int indiceEComercial = result.IndexOf('&');

            if (indiceEComercial == -1)
            {
                return result;
            }
            return result.Remove(indiceEComercial);

        }


    }
}
