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

            Console.Write("Digite a quantidade de vértices que terá o Grafo: ");
            
            grafo = new Grafo(int.Parse(Console.ReadLine()));

            while(executar == 1)
            {

                int escolha = EscolhaMenu();
                ExecutaOpcao(ref grafo, escolha);

                Console.Write("\n\n\nDeseja fazer mais alguma coisa? \n1 - Sim \n2 - Não \nEscolha:");
                executar = int.Parse(Console.ReadLine());

            }
           
        }

        public static int EscolhaMenu()
        {
            Console.Clear();

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
            Console.WriteLine("12 - Verificar se o vértice é par");
            Console.WriteLine("13 - Verificar se o vértice é impar");
            Console.WriteLine("14 - Verificar se há adjacência entre 2 vértices");
            Console.Write("Escolha: ");
            return escolha = int.Parse(Console.ReadLine());


        }

        public static void ExecutaOpcao(ref Grafo grafo, int escolha)
        {

            Console.Clear();

            switch (escolha)
            {
                
                case 1: //Ordem
                    Console.Write("A ordem desse grafo é: "+grafo.Ordem());
                break;

                case 2: //Insere Aresta
                    Console.WriteLine("Escolha quais vértices deseja inserir uma aresta: ");
                    grafo.NomesVertices();
                    Console.Write("Vértice 1: ");
                    Vertice v1 = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    Console.Write("Vértice 2: ");
                    Vertice v2 = grafo.GetVertice(int.Parse(Console.ReadLine()));                    
                    grafo.InserirAresta(v1,v2);                    
                    
                break;

                case 3: //Remove Aresta
                    Console.WriteLine("Escolha quais vértices deseja remover uma aresta: ");
                    grafo.NomesVertices();
                    Console.Write("Vértice 1: ");
                    v1 = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    Console.Write("Vértice 2: ");
                    v2 = grafo.GetVertice(int.Parse(Console.ReadLine()));                    
                    grafo.RemoverAresta(v1,v2);
                    
                break;

                case 4: //Grau do vértice
                    Console.WriteLine("Escolha qual vértice deseja saber o grau: ");
                    grafo.NomesVertices();
                    Console.Write("Vértice: ");
                    Vertice vertice = grafo.GetVertice(int.Parse(Console.ReadLine()));

                    Console.Write("O grau do vértice v" + vertice.Nome + " é: " + grafo.Grau(vertice));
                                       
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
                        Console.Write("O grafo é regular.");
                    }
                    else
                    {
                        Console.Write("O grafo é irregular.");
                    }
                break;

                case 7: //Matriz de Adjacência
                    grafo.ShowMA();
                break;

                case 8: //Lista de Adjacência
                    grafo.ShowLA();
                break;

                case 9: //Sequência de Graus
                    Console.WriteLine("Sequência de graus do Grafo:");
                    grafo.SequenciaGraus();
                break;

                case 10: //Vértices adjacentes de um vértice
                    Console.WriteLine("Escolha qual vértice deseja ver os vértices adjcentes: ");
                    grafo.NomesVertices();
                    vertice = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    grafo.VerticesAdjacentes(vertice);
                break;

                case 11: //Vertice isolado
                    Console.WriteLine("Escolha qual vértice deseja verificar se é isolado: ");
                    grafo.NomesVertices();
                    vertice = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    if (grafo.Isolado(vertice))
                    {
                        Console.WriteLine("Esse vertice é Isolado.");
                    }
                    else
                    {
                        Console.WriteLine("Esse vertice não é Isolado.");
                    }
                    break;

                case 12: //Par
                    Console.WriteLine("Escolha qual vértice deseja verificar se é par: ");
                    grafo.NomesVertices();
                    vertice = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    if (grafo.Par(vertice))
                    {
                        Console.WriteLine("O vertice informado é Par.");
                    }
                    else
                    {
                        Console.WriteLine("O vertice informado não é Par.");
                    }
                    break;

                case 13: //Impar
                    Console.WriteLine("Escolha qual vértice deseja verificar se é impar: ");
                    grafo.NomesVertices();
                    Console.WriteLine("Informe o vertice para verificação: ");
                    vertice = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    if (grafo.Impar(vertice))
                    {
                        Console.WriteLine("O vertice informado é Impar.");
                    }
                    else
                    {
                        Console.WriteLine("O vertice informado não é Impar.");
                    }
                break;

                case 14: //Adjacência entre 2 vértices
                    Console.WriteLine("Escolha quais vértices deseja verificar se há adjacência entre eles: ");
                    grafo.NomesVertices();
                    Console.WriteLine("Vertice 1:");
                    v1 = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Vertice 2:");
                    v2 = grafo.GetVertice(int.Parse(Console.ReadLine()));
                    if (grafo.Adjacentes(v1, v2))
                    {
                        Console.WriteLine("Os vertices informados são adjacentes!");
                    }
                    else
                    {
                        Console.WriteLine("Os vertices informados não são adjacentes.");
                    }
                break;

                default:
                    Console.Write("Nenhuma opção válida escolhida.");
                break;

            }
        }
    }
}
