using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Models.Contas;
using System.Collections.Generic;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get { return _proximaPosicao; }
        }

        /// <summary>
        /// Obtem uma conta por meio do indice
        /// </summary>
        /// <param name="indice">Indice que do array que deseja acessar</param>
        /// <returns>Retona a conta no indice desejado</returns>
        public ContaCorrente this[int indice]
        {
            get { return GetItemNoIndice(indice); }
        }

        /// <summary>
        /// Obtem uma lista de conta por meio do indice
        /// </summary>
        /// <param name="indices">Indices da conta</param>
        /// <returns>Retorna uma lista de contas nos indices desejados</returns>
        public ContaCorrente[] this[params int[] indices]
        {
            get
            {
                ContaCorrente[] resultado = new ContaCorrente[indices.Length];
                for (int i = 0; i < indices.Length; i++)
                {
                    int indiceDaLista = indices[i];
                    resultado[i] = GetItemNoIndice(indiceDaLista);
                }
                return resultado;
            }
        }

        /// <summary>
        /// Construtor da lista de conta corrente
        /// </summary>
        /// <param name="capacidadeInicial">Argumento inicial opicinal que se refere-se ao tamanho inicial da lista de contas</param>
        public ListaDeContaCorrente( int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        /// <summary>
        /// Cria uma nova conta na lista
        /// </summary>
        /// <param name="item">Nova conta</param>
        public void Adicionar(ContaCorrente item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
            //Console.WriteLine($"Adicionando no índice {_proximaPosicao} a conta {item.Agencia} / {item.Numero}");
        }

        /// <summary>
        /// Cria varias contas na lista
        /// </summary>
        /// <param name="item">Lista novas contas</param>
        public void AdicionarVarios(params ContaCorrente[] item)
        {
            foreach (ContaCorrente conta in item)
            {
                Adicionar(conta);
            }
        }

        /// <summary>
        /// Obtem uma conta pelo índice
        /// </summary>
        /// <param name="indice">Indice da conta</param>
        /// <returns>Conta corrente no indice informado</returns>
        public ContaCorrente GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        /// <summary>
        /// Verifica a capacidade de leitura da lista de conta 
        /// </summary>
        /// <param name="tamanhoNecessario">tamanho necessário da lista de conta</param>
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

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
                //Console.WriteLine(".");
            }
            _itens = novoArray;
        }

        /// <summary>
        /// Remove uma conta corrente da lista
        /// </summary>
        /// <param name="item">Conta corrente da lista a ser removido</param>
        public void Remover (ContaCorrente item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao-1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;

        }
       
    }
}
