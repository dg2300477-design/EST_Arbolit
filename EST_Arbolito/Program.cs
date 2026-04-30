using System;

namespace EST_Arbolito
{
    /// <summary>
    /// Clase principal que contiene el punto de entrada de la aplicación en consola.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método principal que ejecuta el menú interactivo para construir, recorrer y clasificar el Árbol Binario.
        /// </summary>
        /// <param name="args">Argumentos de línea de comandos.</param>
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();
            int op = 0;

            do
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("      MENÚ ÁRBOL BINARIO       ");
                Console.WriteLine("===============================");
                Console.WriteLine("1. Insertar un nuevo valor");
                Console.WriteLine("2. Buscar un valor");
                Console.WriteLine("3. Eliminar un valor");
                Console.WriteLine("4. Mostrar recorridos (Pre, In, Post, BFS)");
                Console.WriteLine("5. Mostrar estadísticas del árbol");
                Console.WriteLine("6. Determinar clasificación estructural");
                Console.WriteLine("7. Salir");
                Console.WriteLine("===============================");
                Console.Write("Seleccione una opción: ");

                // Validación para evitar que el programa se caiga si el usuario ingresa letras
                if (!int.TryParse(Console.ReadLine(), out op))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
                    continue;
                }

                switch (op)
                {
                    case 1:
                        Console.Write("Ingrese el valor entero a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int valInsert))
                        {
                            arbol.Insert(valInsert);
                            Console.WriteLine($"Valor {valInsert} insertado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Valor no válido.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valBuscar))
                        {
                            bool encontrado = arbol.Buscar(valBuscar);
                            Console.WriteLine(encontrado ? "Resultado: El valor SÍ existe en el árbol." : "Resultado: El valor NO existe en el árbol.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int valEliminar))
                        {
                            arbol.Eliminar(valEliminar);
                            Console.WriteLine("Proceso de eliminación ejecutado (si el valor existía, ha sido removido).");
                        }
                        break;

                    case 4:
                        Console.WriteLine("\n--- RECORRIDOS ---");
                        Console.Write("Preorden (Raíz, Izq, Der): ");
                        arbol.PreOrder(arbol.root);
                        Console.WriteLine();

                        Console.Write("Inorden (Izq, Raíz, Der):  ");
                        arbol.InOrder(arbol.root);
                        Console.WriteLine();

                        Console.Write("Postorden (Izq, Der, Raíz): ");
                        arbol.PostOrder(arbol.root);
                        Console.WriteLine();

                        Console.Write("Por Niveles (BFS):         ");
                        arbol.BFS();
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine("\n--- ESTADÍSTICAS DEL ÁRBOL ---");
                        Console.WriteLine("Total de nodos:   " + arbol.TotalNodos(arbol.root));
                        Console.WriteLine("Altura del árbol: " + arbol.Altura(arbol.root));
                        Console.WriteLine("Número de hojas:  " + arbol.TotalHojas(arbol.root));
                        Console.WriteLine("Nodos internos:   " + arbol.NodosInternos(arbol.root));

                        Console.Write("\nIngrese un nodo para consultar su nivel de profundidad: ");
                        if (int.TryParse(Console.ReadLine(), out int valNivel))
                        {
                            int nivel = arbol.NivelDeNodo(arbol.root, valNivel, 1);
                            if (nivel > 0)
                                Console.WriteLine($"El nodo {valNivel} se encuentra en el nivel {nivel}.");
                            else
                                Console.WriteLine("El nodo indicado no existe en el árbol.");
                        }
                        break;

                    case 6:
                        Console.WriteLine("\n--- CLASIFICACIÓN ESTRUCTURAL ---");
                        Console.WriteLine("¿Es Lleno (Full Binary Tree)?:       " + (arbol.EsLleno(arbol.root) ? "Sí" : "No"));
                        Console.WriteLine("¿Es Completo (Complete Binary Tree)?: " + (arbol.EsCompleto() ? "Sí" : "No"));
                        Console.WriteLine("¿Es Perfecto (Perfect Binary Tree)?:  " + (arbol.EsPerfecto() ? "Sí" : "No"));
                        Console.WriteLine("¿Es Balanceado (Height-Balanced)?:    " + (arbol.EsBalanceado(arbol.root) ? "Sí" : "No"));
                        Console.WriteLine("¿Es Degenerado (Degenerate Tree)?:    " + (arbol.EsDegenerado(arbol.root) ? "Sí" : "No"));
                        break;

                    case 7:
                        Console.WriteLine("Saliendo de la aplicación");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 7.");
                        break;
                }

            } while (op != 7);
        }
    }
}