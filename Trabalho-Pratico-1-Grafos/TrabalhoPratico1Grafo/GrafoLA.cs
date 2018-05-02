using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico1Grafo
{
    class GrafoLA
    {

        //Exercício 2
        private List<Vertice> LA;
        private int NomeVertice;

        //Construtora: Inicializa a matriz de adjacência pelo tamanho nxn, onde n é a quantidade de vértices passada como parâmetro
        public GrafoLA()
        {
            LA = new List<Vertice>();
            NomeVertice = 1;
        }


        //Retorna a quantidade de vértices do Grafo
        public int Ordem()
        {
            return LA.Count;
        }

        //InserirVertice(Vertice vertice)
        public bool InserirVertice(int nome)
        {
            if (!LA.Contains(GetVertice(nome)))
            {
                LA.Add(new Vertice(nome));
                NomeVertice++;
                return true;
            }
            
            return false;
        }

        //RemoverVertice(Vertice vertice)
        public bool RemoverVertice(Vertice vertice)
        {
            if (LA.Contains(GetVertice(vertice.Nome)))
            {
                LA.Remove(GetVertice(vertice.Nome));
                NomeVertice--;
                return true;
            }
            return false;
        }

        //Insere aresta entre os vértices passados como parâmetro
        public bool InserirAresta(Vertice v1, Vertice v2)
        {
            /*CUIDADOS AO INSERIR UMA ARESTA:
            1 - Verificar se os dois vértices do parâmetro estão presentes no grafo
            2 - Verificar se não há nenhuma aresta já inserida entre esses vértices
            */

            //Verifica se os dois vértices estão presentes no grafo
            if (LA.Contains(v1) && LA.Contains(v2))
            {
                //Verifica se não há adjacência entre os vértices
                if (!(v1.ListaAdjacencia.Contains(v2)) && !(v2.ListaAdjacencia.Contains(v1)))
                {

                    if (v1 != v2)
                    {
                        v1.ListaAdjacencia.Add(v2);
                        v1.Grau++;

                        v2.ListaAdjacencia.Add(v1);
                        v2.Grau++;
                      
                        return true;
                    }
                    else
                    {
                        Console.Write("Não é permitido inserir loops em um grafo não direcionado.");
                    }

                }
                else
                {
                    Console.Write("Já existe uma aresta nesses dois vértices.");
                }

            }

            return false;
        }

        //Remove aresta entre os vértices passados como parâmetro
        public bool RemoverAresta(Vertice v1, Vertice v2)
        {

            //Verifica se os dois vértices estão presentes no grafo
            if (LA.Contains(v1) && LA.Contains(v2))
            {
                //Verifica se há adjacência entre os vértices
                if ((v1.ListaAdjacencia.Contains(v2)) && (v2.ListaAdjacencia.Contains(v1)))
                {

                    if (v1 != v2)
                    {
                        v1.ListaAdjacencia.Remove(v2);
                        v1.Grau--;

                        v2.ListaAdjacencia.Remove(v1);
                        v2.Grau--;                        

                        return true;
                    }
                    else
                    {
                        Console.Write("Não há arestas em loops.");
                    }


                }
                else
                {
                    Console.Write("Não há aresta entre esses dois vértices");
                }

            }

            return false;
        }

        //Retorna a quantidade de graus presente no vértice passado como parâmetro
        public int Grau(Vertice vertice)
        {

            return vertice.Grau;

        }

        //Verifica se o Grafo está com sua ligação máxima de vertices
        public bool Completo()
        {
            //Repensar esse aqui

            int maxArestas = (LA.Count * (LA.Count - 1)) / 2;
            int conjuntoGrauVertices = 0;

            foreach (Vertice item in LA)
                conjuntoGrauVertices += item.Grau;

            if (maxArestas == conjuntoGrauVertices)
                return true;

            return false;

        }

        //Verifica se todos os vértices possuem a mesma quantidade de graus
        public bool Regular()
        {
            List<int> auxGrau = new List<int>();
            /*Pegar o grau do primeiro vértice, percorrer a lista verificando se todos os vértices possuem o grau igual ao 1º*/
            foreach (Vertice item in LA)
                auxGrau.Add(item.Grau);

            int compVar = auxGrau.First<int>();

            foreach (int i in auxGrau)
            {
                if (compVar != i)
                {
                    return false;
                }
            }
            return true;
        }
   

        //Mostra a Lista de Adjacências do Grafo
        public void ShowLA()
        {
            Console.WriteLine("Lista de Adjacência\n\n");

            foreach (Vertice item in LA)
            {
                if (item.ListaAdjacencia.Count != 0)
                {
                    Console.Write(item.Nome + ": ");
                    foreach (Vertice adjacencia in item.ListaAdjacencia)
                        Console.Write(adjacencia.Nome + ", ");

                    Console.WriteLine();
                }


            }

        }

        //Mostra a sequência de graus
        public void SequenciaGraus()
        {
            List<int> auxGrau = new List<int>();
            /*Pega o grau de cada vertice, atribui a uma lista e em seguida ajusta
             * de forma decrescente para apresentar na tela*/
            foreach (Vertice item in LA)
                auxGrau.Add(item.Grau);

            auxGrau.Sort();
            auxGrau.Reverse();

            foreach (int valor in auxGrau)
                Console.Write(valor + ", ");

        }

        //Mostra os vértices adjacentes do vértice passado como parâmetro
        public void VerticesAdjacentes(Vertice vertice)
        {
            Console.WriteLine(vertice.Nome + ": ");
            foreach (Vertice item in vertice.ListaAdjacencia)
            {
                Console.WriteLine(item.Nome + ", ");
            }
        }

        //Verifica se o vértice é isolado
        public bool Isolado(Vertice vertice)
        {
            if (vertice.Grau == 0)
            {
                return true;
            }
            return false;
        }

        //TODO: Verificar o que quer dizer com Par/Impar
        public bool Impar(Vertice vertice)
        {
            if (vertice.Nome % 2 == 0)

            {
                return false;
            }
            return true;
        }


        //TODO: Verificar o que quer dizer com Par/Impar
        public bool Par(Vertice vertice)
        {
            if (vertice.Nome % 2 == 1)

            {
                return false;
            }
            return true;
        }

        //Verifica se há adjacência entre os vértices passados como parâmetro
        public bool Adjacentes(Vertice v1, Vertice v2)
        {            
       
            if (v1 != v2)
            {
                if(v1.ListaAdjacencia.Contains(v2) && v2.ListaAdjacencia.Contains(v1))
                {
                    return true;
                }
            }
            return false;
        }

        //UTILS
        public void NomesVertices()
        {

            foreach (Vertice vertice in LA)
                Console.Write(vertice.Nome + " ");

            Console.WriteLine();

        }

        public Vertice GetVertice(int nome)
        {

            foreach (Vertice item in LA)
            {
                if (item.Nome == nome)
                    return item;
            }

            return null;
        }

        public int GetNome()
        {
            return NomeVertice;
        }

    }
}
