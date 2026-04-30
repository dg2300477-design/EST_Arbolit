using System;

namespace EST_Arbolito
{
    /// <summary>
    /// Clase que gestiona la estructura y operaciones de un Árbol Binario de Búsqueda.
    /// </summary>
    public class ArbolBinario
    {
        public Nodo root;

        public ArbolBinario()
        {
            root = null;
        }

        /// <summary>
        /// Inserta un nuevo valor en el árbol manteniendo las propiedades de un árbol de búsqueda.
        /// </summary>
        /// <param name="value">Valor entero a insertar.</param>
        public void Insert(int value)
        {
            root = InsertarRecursivo(root, value);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int value)
        {
            if (nodo == null) return new Nodo(value);

            if (value < nodo.Value)
                nodo.left = InsertarRecursivo(nodo.left, value);
            else if (value > nodo.Value)
                nodo.right = InsertarRecursivo(nodo.right, value);

            return nodo;
        }

        /// <summary>
        /// Función auxiliar booleana que busca un valor en el árbol.
        /// </summary>
        /// <param name="value">Valor a buscar.</param>
        /// <returns>True si el valor existe, False si no.</returns>
        public bool Buscar(int value)
        {
            return BuscarRecursivo(root, value) != null;
        }

        private Nodo BuscarRecursivo(Nodo nodo, int value)
        {
            if (nodo == null || nodo.Value == value) return nodo;
            if (value < nodo.Value) return BuscarRecursivo(nodo.left, value);
            return BuscarRecursivo(nodo.right, value);
        }

        /// <summary>
        /// Elimina un nodo específico del árbol reestructurando sus ramas.
        /// </summary>
        /// <param name="value">Valor a eliminar.</param>
        public void Eliminar(int value)
        {
            root = EliminarRecursivo(root, value);
        }

        private Nodo EliminarRecursivo(Nodo nodo, int value)
        {
            if (nodo == null) return nodo;

            if (value < nodo.Value) nodo.left = EliminarRecursivo(nodo.left, value);
            else if (value > nodo.Value) nodo.right = EliminarRecursivo(nodo.right, value);
            else
            {
                if (nodo.left == null) return nodo.right;
                else if (nodo.right == null) return nodo.left;

                nodo.Value = MinValue(nodo.right);
                nodo.right = EliminarRecursivo(nodo.right, nodo.Value);
            }
            return nodo;
        }

        private int MinValue(Nodo nodo)
        {
            int minv = nodo.Value;
            while (nodo.left != null)
            {
                minv = nodo.left.Value;
                nodo = nodo.left;
            }
            return minv;
        }

        /// <summary>
        /// Imprime el recorrido Preorden (Raíz, Izquierdo, Derecho).
        /// </summary>
        public void PreOrder(Nodo nodo)
        {
            if (nodo == null) return;
            Console.Write(nodo.Value + " ");
            PreOrder(nodo.left);
            PreOrder(nodo.right);
        }

        /// <summary>
        /// Imprime el recorrido Inorden (Izquierdo, Raíz, Derecho).
        /// </summary>
        public void InOrder(Nodo nodo)
        {
            if (nodo == null) return;
            InOrder(nodo.left);
            Console.Write(nodo.Value + " ");
            InOrder(nodo.right);
        }

        /// <summary>
        /// Imprime el recorrido Postorden (Izquierdo, Derecho, Raíz).
        /// </summary>
        public void PostOrder(Nodo nodo)
        {
            if (nodo == null) return;
            PostOrder(nodo.left);
            PostOrder(nodo.right);
            Console.Write(nodo.Value + " ");
        }

        /// <summary>
        /// Imprime el recorrido por niveles (Breadth-First Search) usando la cola personalizada.
        /// </summary>
        public void BFS()
        {
            if (root == null) return;

            ColaPersonalizada cola = new ColaPersonalizada();
            cola.Enqueue(root);

            while (!cola.EstaVacia())
            {
                Nodo actual = cola.Dequeue();
                Console.Write(actual.Value + " ");

                if (actual.left != null) cola.Enqueue(actual.left);
                if (actual.right != null) cola.Enqueue(actual.right);
            }
        }

        // --- ESTADÍSTICAS ---

        /// <summary>
        /// Calcula el número total de nodos en el árbol.
        /// </summary>
        public int TotalNodos(Nodo nodo)
        {
            if (nodo == null) return 0;
            return 1 + TotalNodos(nodo.left) + TotalNodos(nodo.right);
        }

        /// <summary>
        /// Calcula la altura máxima del árbol.
        /// </summary>
        public int Altura(Nodo nodo)
        {
            if (nodo == null) return 0;
            return 1 + Math.Max(Altura(nodo.left), Altura(nodo.right));
        }

        /// <summary>
        /// Cuenta cuántos nodos hoja (sin hijos) existen en el árbol.
        /// </summary>
        public int TotalHojas(Nodo nodo)
        {
            if (nodo == null) return 0;
            if (nodo.EsHoja()) return 1;
            return TotalHojas(nodo.left) + TotalHojas(nodo.right);
        }

        /// <summary>
        /// Cuenta el número de nodos internos (aquellos que tienen al menos un hijo).
        /// </summary>
        public int NodosInternos(Nodo nodo)
        {
            if (nodo == null || nodo.EsHoja()) return 0;
            return 1 + NodosInternos(nodo.left) + NodosInternos(nodo.right);
        }

        /// <summary>
        /// Obtiene el nivel de profundidad de un nodo específico buscando por su valor.
        /// </summary>
        public int NivelDeNodo(Nodo nodo, int value, int nivel)
        {
            if (nodo == null) return 0;
            if (nodo.Value == value) return nivel;

            int nivelIzq = NivelDeNodo(nodo.left, value, nivel + 1);
            if (nivelIzq != 0) return nivelIzq;

            return NivelDeNodo(nodo.right, value, nivel + 1);
        }

        // --- CLASIFICACIÓN ESTRUCTURAL ---

        /// <summary>
        /// Verifica si el árbol es Lleno (Full Binary Tree).
        /// </summary>
        public bool EsLleno(Nodo nodo)
        {
            if (nodo == null) return true;
            if (nodo.left == null && nodo.right == null) return true;
            if (nodo.left != null && nodo.right != null)
                return EsLleno(nodo.left) && EsLleno(nodo.right);
            return false;
        }

        /// <summary>
        /// Verifica si el árbol es Completo.
        /// </summary>
        public bool EsCompleto()
        {
            if (root == null) return true;
            ColaPersonalizada cola = new ColaPersonalizada();
            cola.Enqueue(root);
            bool flag = false;

            while (!cola.EstaVacia())
            {
                Nodo actual = cola.Dequeue();
                if (actual == null)
                {
                    flag = true;
                }
                else
                {
                    if (flag) return false;
                    cola.Enqueue(actual.left);
                    cola.Enqueue(actual.right);
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica si el árbol es Perfecto.
        /// </summary>
        public bool EsPerfecto()
        {
            int d = Altura(root);
            return TotalNodos(root) == (Math.Pow(2, d) - 1);
        }

        /// <summary>
        /// Verifica si el árbol está Balanceado.
        /// </summary>
        public bool EsBalanceado(Nodo nodo)
        {
            if (nodo == null) return true;
            int lh = Altura(nodo.left);
            int rh = Altura(nodo.right);
            if (Math.Abs(lh - rh) <= 1 && EsBalanceado(nodo.left) && EsBalanceado(nodo.right)) return true;
            return false;
        }

        /// <summary>
        /// Verifica si el árbol es Degenerado.
        /// </summary>
        public bool EsDegenerado(Nodo nodo)
        {
            if (nodo == null || nodo.EsHoja()) return true;
            if (nodo.left != null && nodo.right != null) return false;
            if (nodo.left != null) return EsDegenerado(nodo.left);
            return EsDegenerado(nodo.right);
        }
    }
}