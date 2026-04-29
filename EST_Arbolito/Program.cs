using EST_Arbolito;
using static System.Runtime.InteropServices.JavaScript.JSType;

ArbolBinario arbol = new ArbolBinario();

void menu()
{
    int op =0;

    Console.WriteLine("ELIGA UNA OPCION"
        + "\n1.insertar valor"
        + "\n2.buscar valor"
        + "\n3.eliminar valor"
        + "\n4.mostrar recorridos"
        + "\n5.mostrar estadisticas del árbol"
        + "\n6.clasificacion estructural del arbol"
        + "\n7.salir"
        );

    do
    {
        Console.WriteLine("ingrese un valor");

        while (!int.TryParse(Console.ReadLine(), out op))
        {
            Console.Write("Entrada inválida. Intente nuevamente: ");
        }

        switch (op)
        {

        }
    }
    while (op == 0);
}

