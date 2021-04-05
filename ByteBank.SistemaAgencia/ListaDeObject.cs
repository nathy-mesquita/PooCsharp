using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeObject
    {
        private object[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get { return _proximaPosicao; }
        }

        /// <summary>
        /// Obtem um <see cref="object"/> por meio do indice
        /// </summary>
        /// <param name="indice">Indice que do array que deseja acessar</param>
        /// <returns>Retona o objeto no indice desejado</returns>
        public object this[int indice]
        {
            get { return GetItemNoIndice(indice); }
        }

        /// <summary>
        /// Obtem uma lista de <see cref="object"/> por meio do indice
        /// </summary>
        /// <param name="indices">Indices da conta</param>
        /// <returns>Retorna uma lista de contas nos indices desejados</returns>
        public object[] this[params int[] indices]
        {
            get
            {
                object[] resultado = new object[indices.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    int indiceDaLista = indices[i];
                    resultado[i] = GetItemNoIndice(indiceDaLista);
                }
                return resultado;
            }
        }

        /// <summary>
        /// Construtor de <see cref="ListaDeObject"/>
        /// </summary>
        /// <param name="capacidadeInicial">Argumento inicial opicinal que se refere-se ao tamanho inicial da lista de contas</param>
        public ListaDeObject(int capacidadeInicial = 5)
        {
            _itens = new object[capacidadeInicial];
            _proximaPosicao = 0;
        }

        /// <summary>
        /// Cria uma novo <see cref="object"/> na lista
        /// </summary>
        /// <param name="item">Nova conta</param>
        public void Adicionar(object item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
            //Console.WriteLine($"Adicionando no índice {_proximaPosicao} a conta {item.Agencia} / {item.Numero}");
        }

        /// <summary>
        /// Cria varios <see cref="object"/> na lista
        /// </summary>
        /// <param name="itens">Lista novas contas</param>
        public void AdicionarVarios(params object[] itens)
        {
            foreach (object item in itens)
            {
                Adicionar(item);
            }
        }

        /// <summary>
        /// Obtem um <see cref="object"/> pelo índice
        /// </summary>
        /// <param name="indice">Indice da conta</param>
        /// <returns>Conta corrente no indice informado</returns>
        public object GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        /// <summary>
        /// Verifica a capacidade de leitura da lista de <see cref="object"/> 
        /// </summary>
        /// <param name="tamanhoNecessario">tamanho necessário da lista de <see cref="object"/></param>
        public void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            //Console.WriteLine("Aumentando a Capacidade da Lista");

            object[] novoArray = new object[novoTamanho];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
                //Console.WriteLine(".");
            }
            _itens = novoArray;
        }

        /// <summary>
        /// Remove um <see cref="object"/> da lista
        /// </summary>
        /// <param name="item"><see cref="object"/> da lista a ser removido</param>
        public void Remover(object item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;

        }

    }
}
