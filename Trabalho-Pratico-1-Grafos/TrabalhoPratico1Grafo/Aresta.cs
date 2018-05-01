using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico1Grafo
{
    class Aresta
    {

        Vertice v1;
        Vertice v2;
        bool isLigado;


        //CONSTRUCTOR
        public Aresta(Vertice valor1, Vertice valor2)
        {
            this.v1 = valor1;
            this.v2 = valor2;
            isLigado = true;
        }



        //GETTERS E SETTERS
        public Vertice GetV1()
        {
            return v1;
        }
        public void SetV1(Vertice valor)
        {
            this.v1 = valor;
        }


        public Vertice GetV2()
        {
            return v2;
        }
        public void SetV2(Vertice valor)
        {
            this.v2 = valor;
        }


        public bool IsLigado()
        {
            return isLigado;
        }
        public void SetLigado(bool valor)
        {
            this.isLigado = valor;
        }
    }

}

