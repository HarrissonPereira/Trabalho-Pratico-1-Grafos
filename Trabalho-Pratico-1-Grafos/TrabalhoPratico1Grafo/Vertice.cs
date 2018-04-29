using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico1Grafo
{
    class Vertice
    {

        public int Nome { get; set; }
        public int Grau { get; set; }
        public List<Vertice> ListaAdjacencia { get; set; }

        public Vertice(int nome)
        {
            Nome = nome;
            ListaAdjacencia = new List<Vertice>();
            Grau = 0;
        }

        
    }
}
