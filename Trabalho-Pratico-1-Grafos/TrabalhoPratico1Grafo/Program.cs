using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico1Grafo
{
    class Program
    {
        static void Main(string[] args)
        {

            Grafo grafo;
            int executar = 1;

            Console.Write("Digite a quantidade de vértices: ");
            
            grafo = new Grafo(int.Parse(Console.ReadLine()));

            while(executar == 1)
            {

                int escolha = EscolhaMenu();
                ExecutaOpcao(ref grafo, escolha);

                Console.Write("Deseja fazer mais alguma coisa? \n1 - Sim \n2 - Não \nEscolha:")
                executar = int.Parse(Console.ReadLine());

            }
           
        }

        public static int EscolhaMenu()
        {
            int escolha = 0;
            Console.WriteLine("O que deseja fazer com o grafo:");
            Console.WriteLine("1 - Ordem do Grafo");
            Console.WriteLine("2 - Inserir Aresta");
            Console.WriteLine("3 - Remover Aresta");
            Console.WriteLine("4 - Grau de um vértice");
            Console.WriteLine("5 - Verificar se o Grafo está completo");
            Console.WriteLine("6 - Verificar se o Grafo é regular");
            Console.WriteLine("7 - Mostrar Matriz de Adjacência");
            Console.WriteLine("8 - Mostrar Lista de Adjacência");
            Console.WriteLine("9 - Mostrar a sequência de graus do Grafo");
            Console.WriteLine("10 - Mostrar vértices adjacentes de um determinado vértice");
            Console.WriteLine("11 - Verificar se um determinado vértice é isolado");
            Console.WriteLine("12 - ImpSar?");
            Console.WriteLine("13 - Par?");
            Console.WriteLine("14 - Verificar se há adjacência entre 2 vértices");
            Console.Write("Escolha: ");
            escolha = int.Parse(Console.ReadLine());

        }

        public static void ExecutaOpcao(ref Grafo grafo, int escolha)
        {

            Console.Clear();

            switch(escolha)
            {
                case 1: //Ordem
                    Console.Write("A ordem desse grafo é: "+grafo.Ordem());
                break;

                case 2: //Insere Aresta
                    Console.WriteLine("Escolha quais vértices deseja inserir uma aresta: ");
                    grafo.NomesVertices();
                    Console.Write("Vértice 1: ");
                    int v1 = int.Parse(Console.ReadLine());
                    Console.Write("Vértice 2: ");
                    int v2 = int.Parse(Console.ReadLine());

                    if(v1 != v2){
                        grafo.InsereAresta(v1,v2);
                    }else
                    {
                        Console.Write("Nesse grafo, não pode inserir arestas tipo loop.");
                    }
                    
                break;

                case 3: //Remove Aresta
                    Console.WriteLine("Escolha quais vértices deseja remover uma aresta: ");
                    grafo.NomesVertices();
                    Console.Write("Vértice 1: ");
                    int v1 = int.Parse(Console.ReadLine());
                    Console.Write("Vértice 2: ");
                    int v2 = int.Parse(Console.ReadLine());

                    if(v1 != v2){
                        grafo.RemoveAresta(v1,v2);
                    }else
                    {
                        Console.Write("Nesse grafo, não há arestas em loop.");
                    }
                break;

                case 4: //Grau do vértice
                    Console.WriteLine("Escolha quais vértices deseja remover uma aresta: ");
                    grafo.NomesVertices();
                    Console.Write("Vértice: ");
                    int vertice = int.Parse(Console.ReadLine());
                    
                    grafo.Grau(vertice);
                break;

                case 5: //Grafo Completo
                    if(grafo.Completo())
                    {
                        Console.Write("O grafo está completo.");
                    }
                    else
                    {
                        Console.Write("O grafo está incompleto.");
                    }
                    
                break;

                case 6: //Grafo Regular
                    if(grafo.Regular())
                    {
                        Console.Write("O grafo está completo.");
                    }
                    else
                    {
                        Console.Write("O grafo está incompleto.");
                    }
                break;

                case 7: //Matriz de Adjacência
                    grafo.ShowMA();
                break;

                case 8: //Lista de Adjacência
                    grafo.ShowLA();
                break;

                case 9: //Sequência de Graus
                    grafo.SequenciaGraus();
                break;

                case 10: //Vértices adjacentes de um vértice
                    grafo.VerticesAdjacentes();
                break;

                case 11: //Vertice isolado
                    grafo.Isolado();
                break;

                case 12: //Impar
                    grafo.Par();
                break;

                case 13: //Par
                    grafo.Impar();
                break;

                case 14: //Adjacência entre 2 vértices
                    grafo.Adjacentes();
                break;

                default:
                    Console.Write("Nenhuma opção válida escolhida.")
                break;

            }
        }
    }
}
