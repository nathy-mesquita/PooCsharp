using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtractValueArgumentsURL
    {
        private readonly string _argumentos; //privado, somente leitura
        public string URL { get; }//Sem o set, somente leitura 
        // Quando a propriedade é apenas leitura, conseguimos editar apenas em dois campos, no construtor e na propria declaração da propriedade. 
    
        
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

        //string url ="https://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
        //_argumento ="moedaOrigem=real&moedaDestino=dolar&valor=1500";

        public string GetValor(string nomeParametro)
        {
            string termo = nomeParametro + "=";
            int indiceTermo = _argumentos.IndexOf(termo);

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
