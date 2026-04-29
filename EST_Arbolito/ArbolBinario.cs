using System;
using System.Collections.Generic;
using System.Text;

namespace EST_Arbolito
{
    class ArbolBinario
    {
        public Nodo root;

        public ArbolBinario()
        {
            root = null;
        }

        public void PreOrder(Nodo nodo) //Raiz->Izquierda->Derecha
        {
            if (nodo == null) return;
            Console.WriteLine(nodo.Value);
            PreOrder(nodo.left);
            PreOrder(nodo.right);
        }

        public void InOrder(Nodo nodo) //Izquierda->Raiz->Derecha
        {
            if (nodo == null) return;
            InOrder(nodo.left);
            Console.WriteLine(nodo.Value);
            InOrder(nodo.right);
        }

        public void PostOrder(Nodo nodo)
        {
            if (nodo == null) return;
            PostOrder(nodo.left);
            PostOrder(nodo.right);
            Console.WriteLine(nodo.Value);
        }
    }
}
