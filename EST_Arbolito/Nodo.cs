using System;

namespace EST_Arbolito
{
    /// <summary>
    /// Representa un nodo individual dentro del árbol binario.
    /// </summary>
    public class Nodo
    {
        public int Value;
        public Nodo left;
        public Nodo right;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Nodo con un valor específico.
        /// </summary>
        /// <param name="value">El valor entero que almacenará el nodo.</param>
        public Nodo(int value)
        {
            Value = value;
            left = null;
            right = null;
        }

        /// <summary>
        /// Función auxiliar booleana que determina si el nodo actual es una hoja.
        /// </summary>
        /// <returns>Retorna true si el nodo no tiene hijos, de lo contrario false.</returns>
        public bool EsHoja()
        {
            return left == null && right == null;
        }
    }

    /// <summary>
    /// Representa un elemento dentro de la cola personalizada.
    /// </summary>
    public class NodoCola
    {
        public Nodo nodoArbol;
        public NodoCola siguiente;

        public NodoCola(Nodo nodoArbol)
        {
            this.nodoArbol = nodoArbol;
            this.siguiente = null;
        }
    }

    /// <summary>
    /// Cola implementada desde cero para el recorrido BFS.
    /// </summary>
    public class ColaPersonalizada
    {
        private NodoCola frente;
        private NodoCola final;
        public int Count { get; private set; }

        public ColaPersonalizada()
        {
            frente = null;
            final = null;
            Count = 0;
        }

        /// <summary>
        /// Función auxiliar booleana para verificar si la cola no tiene elementos.
        /// </summary>
        /// <returns>True si la cola está vacía, False en caso contrario.</returns>
        public bool EstaVacia()
        {
            return Count == 0;
        }

        /// <summary>
        /// Agrega un nodo del árbol al final de la cola.
        /// </summary>
        /// <param name="nodo">El nodo a encolar.</param>
        public void Enqueue(Nodo nodo)
        {
            NodoCola nuevo = new NodoCola(nodo);
            if (final == null)
            {
                frente = final = nuevo;
            }
            else
            {
                final.siguiente = nuevo;
                final = nuevo;
            }
            Count++;
        }

        /// <summary>
        /// Remueve y devuelve el nodo del árbol que está al frente de la cola.
        /// </summary>
        /// <returns>El nodo extraído o null si la cola está vacía.</returns>
        public Nodo Dequeue()
        {
            if (EstaVacia()) return null;
            Nodo temp = frente.nodoArbol;
            frente = frente.siguiente;
            if (frente == null) final = null;
            Count--;
            return temp;
        }
    }
}