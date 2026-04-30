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

        {
            if (root == null) return;

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(root);

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();
                Console.WriteLine(actual.Value);

                if (actual.left != null)
                    cola.Enqueue(actual.left);

                if (actual.right != null)
                    cola.Enqueue(actual.right);
            }
        }

        public void Insert(string value)
        {
            Nodo nuevo = new Nodo(value);

            // Caso 1: árbol vacío
            if (root == null)
            {
                root = nuevo;
                return;
            }

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(root);

            while (cola.Count > 0)
            {
                Nodo actual = cola.Dequeue();

                // Si falta hijo izquierdo → insertar ahí
                if (actual.left == null)
                {
                    actual.left = nuevo;
                    return;
                }
                else
                {
                    cola.Enqueue(actual.left);
                }

                // Si falta hijo derecho → insertar ahí
                if (actual.right == null)
                {
                    actual.right = nuevo;
                    return;
                }
                else
                {
                    cola.Enqueue(actual.right);
                }
            }

        }
    }
}
