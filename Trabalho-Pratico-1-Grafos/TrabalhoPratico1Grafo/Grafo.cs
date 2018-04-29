using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico1Grafo
{
    class Grafo
    {

        private int[,] MA;
        private int qtVertices;
        private List<Vertice> verticesDoGrafo;


        //Construtora: Inicializa a matriz de adjacência pelo tamanho nxn, onde n é a quantidade de vértices passada como parâmetro
        public Grafo (int qtVertices)
        {

            this.qtVertices = qtVertices;

            MA = new int[qtVertices, qtVertices];            
            

            //colocando os vértices no Grafo
            verticesDoGrafo = new List<Vertice>();            
            for (int indice = 0; indice < qtVertices; indice++)
                verticesDoGrafo.Add(new Vertice(indice+1));
        }


        //Retorna a quantidade de vértices do Grafo
        public int Ordem()
        {
            return qtVertices;
        }

        //Insere aresta entre os vértices passados como parâmetro
        public bool InserirAresta(Vertice v1, Vertice v2)
        {
            /*CUIADOS AO INSERIR UMA ARESTA:
            1 - Verificar se os dois vértices do parâmetro estão presentes no grafo
            2 - Verificar se não há nenhuma aresta já inserida entre esses vértices
            */

            //Verifica se os dois vértices estão presentes no grafo
            if (verticesDoGrafo.Contains(v1) && verticesDoGrafo.Contains(v2)) 
            {
                //Verifica se não há adjacência entre os vértices
                if (!(v1.ListaAdjacencia.Contains(v2) && !(v2.ListaAdjacencia.Contains(v1)))) 
                {
                    v1.ListaAdjacencia.Add(v2);
                    v1.Grau++;

                    v2.ListaAdjacencia.Add(v1);
                    v2.Grau++;

                    return true;
                }

            }

            return false;
        }

        //Remove aresta entre os vértices passados como parâmetro
        public bool RemoverAresta(Vertice v1, Vertice v2)
        {

            //Verifica se os dois vértices estão presentes no grafo
            if (verticesDoGrafo.Contains(v1) && verticesDoGrafo.Contains(v2))
            {
                //Verifica se há adjacência entre os vértices
                if ((v1.ListaAdjacencia.Contains(v2) && (v2.ListaAdjacencia.Contains(v1))))
                {
                    v1.ListaAdjacencia.Remove(v2);
                    v1.Grau--;

                    v2.ListaAdjacencia.Remove(v1);
                    v2.Grau--;

                    return true;
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
            int maxArestas = (qtVertices * (qtVertices - 1)) / 2;
            int conjuntoGrauVertices = 0;

            foreach (Vertice item in verticesDoGrafo)
                conjuntoGrauVertices += item.Grau;

            if(maxArestas == conjuntoGrauVertices)
                return true;

            return false;


        }
        
        //Verifica se todos os vértices possuem a mesma quantidade de graus
        public bool Regular()
        {
            /*Pegar o grau do primeiro vértice, percorrer a lista verificando se todos os vértices possuem o grau igual ao 1º*/

            return true;
        }

        //Mostra a Matriz de Adjacência do Grafo
        public void ShowMA()
        {
            Console.WriteLine(MA);
        }

        //Mostra a Lista de Adjacências do Grafo
        public void ShowLA()
        {
            foreach (Vertice item in verticesDoGrafo)
                Console.Write(item.Nome + ": "+item.ListaAdjacencia);

        }

        //Mostra a sequência de graus
        public void SequenciaGraus()
        {
            /**/
        }

        //Mostra os vértices adjacentes do vértice passado como parâmetro
        public void VerticesAdjacentes(Vertice vertice)
        {
            /**/
        }

        //Verifica se o vértice é isolado
        public bool Isolado(Vertice vertice)
        {
            return true;
        }

        //TODO: Verificar o que quer dizer com Par/Impar
        public bool Impar(Vertice vertice)
        {
            return true;
        }


        //TODO: Verificar o que quer dizer com Par/Impar
        public bool Par(Vertice vertice)
        {
            return true;
        }

        //Verifica se há adjacência entre os vértices passados como parâmetro
        public bool Adjacentes(Vertice v1, Vertice v2)
        {
            return true;
        }

    }
}
