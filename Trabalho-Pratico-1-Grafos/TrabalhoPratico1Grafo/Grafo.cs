using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico1Grafo
{
    class Grafo
    {

        //private int[,] MA;
        private int qtVertices;
        private Aresta[,] MA;        
        private List<Vertice> verticesDoGrafo;

        //Construtora: Inicializa a matriz de adjacência pelo tamanho nxn, onde n é a quantidade de vértices passada como parâmetro
        public Grafo (int qtdeVertices)
        {
            this.qtVertices = qtdeVertices; 

            //colocando os vértices no Grafo
            verticesDoGrafo = new List<Vertice>();            
            for (int indice = 0; indice < qtVertices; indice++)
                verticesDoGrafo.Add(new Vertice(indice+1));        

            MA = new Aresta[qtVertices,qtVertices];

            //Inicializando a MA com os vértices posicionados de forma correta
            for(int indiceY = 0; indiceY < MA.GetLength(1); indiceY++){
                for(int indiceX = 0; indiceY < MA.GetLength(0); indiceY++){

                    Vertice v1 = new Vertice(1);
                    Vertice v2 = new Vertice(1);

                    foreach(Vertice vertice in verticesDoGrafo)
                        if(vertice.Nome == indiceY+ 1)
                            v1 = vertice;
                    
                    foreach(Vertice vertice in verticesDoGrafo)
                        if(vertice.Nome == indiceX+ 1)
                            v2 = vertice;

                    MA[indiceX,indiceY] = new Aresta(v1, v2);

                }

            }           
            
        }


        //Retorna a quantidade de vértices do Grafo
        public int Ordem()
        {
            return qtVertices;
        }

        //Insere aresta entre os vértices passados como parâmetro
        public bool InserirAresta(Vertice v1, Vertice v2)
        {
            /*CUIDADOS AO INSERIR UMA ARESTA:
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

                    MA[(v1.Nome-1),(v2.Nome-1)].SetLigado(true);

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

                    MA[(v1.Nome-1),(v2.Nome-1)].SetLigado(false);

                    return true;
                }

            }

            return false;            
        }

        //Retorna a quantidade de graus presente no vértice passado como parâmetro
        public int Grau(int vertice)
        {

            foreach(Vertice item in verticesDoGrafo)
            {
                if(item.Nome == vertice)
                {
                    return item.Grau; 
                }
            }
            return 0;
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
            List<int> auxGrau = new List<int>();
            /*Pegar o grau do primeiro vértice, percorrer a lista verificando se todos os vértices possuem o grau igual ao 1º*/
            foreach (Vertice item in verticesDoGrafo)
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

        //Mostra a Matriz de Adjacência do Grafo
        public void ShowMA()
        {
            Console.Write("\t");

            for(int i = 0; i < qtVertices; i++){
                Console.Write("v" + i + 1 + "\t");
            }

            for(int indiceY = 0; indiceY < MA.GetLength(1); indiceY++){

                Console.Write("v" + indiceY + 1 + "\t");

                for(int indiceX = 0; indiceY < MA.GetLength(0); indiceY++){
                    if(MA[indiceX,indiceY].IsLigado()){
                        Console.Write("1\t");
                    }
                    else
                    {
                        Console.Write("0\t");
                    }
                }

                Console.WriteLine();
            }
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
            List<int> auxGrau = new List<int>();
            /*Pega o grau de cada vertice, atribui a uma lista e em seguida ajusta
             * de forma decrescente para apresentar na tela*/
            foreach (Vertice item in verticesDoGrafo)
                auxGrau.Add(item.Grau);

            auxGrau.Sort();
            auxGrau.Reverse();

            Console.WriteLine(auxGrau);
        }

        //Mostra os vértices adjacentes do vértice passado como parâmetro
        public void VerticesAdjacentes(Vertice vertice)
        {
            Console.WriteLine(vertice.Nome + ": ");
            foreach(Vertice item in vertice.ListaAdjacencia)
            {
                Console.WriteLine(item.Nome + ", ");
            }
        }

        //Verifica se o vértice é isolado
        public bool Isolado(Vertice vertice)
        {
            if (vertice.Grau != 0)
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
                return (MA[v1.Nome - 1, v2.Nome - 1].IsLigado());
            }
                return false;
        }

        //UTILS
        public void NomesVertices()
        {

            foreach (Vertice vertice in verticesDoGrafo)
                Console.Write(vertice.Nome + " ");

            Console.WriteLine();

        }

        public Vertice GetVertice(int nome){

            foreach (Vertice item in verticesDoGrafo)
            {
                if (item.Nome == nome)
                    return item;
            }

            return null;
        }

    }
}
