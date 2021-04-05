using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia
{
    //T de Tipo, Classe de Lista de Tipopo genérico
    public class Lista<T>
    {

        private T[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get { return _proximaPosicao; }
        }

        /// <summary>
        /// Obtem um <see cref="T"/> por meio do indice
        /// </summary>
        /// <param name="indice">Indice que do array que deseja acessar</param>
        /// <returns>Retona o <see cref="T"/> no indice desejado</returns>
        public T this[int indice]
        {
            get { return GetItemNoIndice(indice); }
        }

        /// <summary>
        /// Obtem uma lista de <see cref="T"/> por meio do indice
        /// </summary>
        /// <param name="indices">Indices da conta</param>
        /// <returns>Retorna uma lista de <see cref="T"/> nos indices desejados</returns>
        public T[] this[params int[] indices]
        {
            get
            {
                T[] resultado = new T[indices.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    int indiceDaLista = indices[i];
                    resultado[i] = GetItemNoIndice(indiceDaLista);
                }
                return resultado;
            }
        }

        /// <summary>
        /// Construtor de <see cref="ListaDeT"/>
        /// </summary>
        /// <param name="capacidadeInicial">Argumento inicial opicinal que se refere-se ao tamanho inicial da lista de <see cref="T"/></param>
        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        /// <summary>
        /// Cria uma novo <see cref="T"/> na lista
        /// </summary>
        /// <param name="item">Novao <see cref="T"/></param>
        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        /// <summary>
        /// Cria varios <see cref="T"/> na lista
        /// </summary>
        /// <param name="itens">Lista novas <see cref="T"/></param>
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }

        /// <summary>
        /// Obtem um <see cref="T"/> pelo índice
        /// </summary>
        /// <param name="indice">Indice do <see cref="T"/></param>
        /// <returns><see cref="T"/> no indice informado</returns>
        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        /// <summary>
        /// Verifica a capacidade de leitura da lista de <see cref="T"/> 
        /// </summary>
        /// <param name="tamanhoNecessario">tamanho necessário da lista de <see cref="T"/></param>
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

            T[] novoArray = new T[novoTamanho];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
                //Console.WriteLine(".");
            }
            _itens = novoArray;
        }

        /// <summary>
        /// Remove um <see cref="T"/> da lista
        /// </summary>
        /// <param name="item"><see cref="T"/> da lista a ser removido</param>
        public void Remover(T item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                T itemAtual = _itens[i];
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
            //_itens[_proximaPosicao] = null;

        }
    }
}
