using System;
using System.ComponentModel.Design;
using System.Runtime.Serialization.Formatters;

public class Inventario 
{
    static void Main(String[] args) 
    {
        List<Tuple<int, string, int, double>> productos = crearInventario();
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("----- Menú de Gestión de Inventario -----");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Eliminar Producto");
            Console.WriteLine("3. Modificar Producto");
            Console.WriteLine("4. Consultar Producto");
            Console.WriteLine("5. Mostrar Todos los Productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto(ref productos);
                    break;
                case 2:
                    EliminarProducto(ref productos);
                    break;
                case 3:
                    ModificarProducto(ref productos);
                    break;
                case 4:
                    ConsultarProducto(productos);
                    break;
                case 5:
                    MostrarTodosProductos(productos);
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

            if (opcion != 6)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }

    public static List<Tuple<int, string, int, double>> CrearInventario() 
    {
        List<Tuple<int, string, int, double>> productos = new List<Tuple<int, string, int, double>>();

        return (productos);
    
    }
    public static void AgregarProducto(ref List<Tuple<int, string, int, double>> productos)
    {
        Console.WriteLine("\n--- Agregar Producto ---");
        Console.Write("Ingrese el código: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el precio: ");
        double precio = double.Parse(Console.ReadLine());

        
        productos.Add(new Tuple<int, string, int, double>(codigo, nombre, cantidad, precio));
        Console.WriteLine("Producto agregado exitosamente.");
    }

    public static void EliminarProducto(ref List<Tuple<int, string, int, double>> productos)
    {
        Console.Write("\nIngrese el código del producto a eliminar: ");
        int codigo = int.Parse(Console.ReadLine());

        
        for (int i = 0; i < productos.Count; i++)
        {
            if (productos[i].Item1 == codigo)
            {
                productos.RemoveAt(i); 
                Console.WriteLine("Producto eliminado exitosamente.");
                return;
            }
        }

        Console.WriteLine("Producto no encontrado.");
    }

    public static void ModificarProducto(ref List<Tuple<int, string, int, double>> productos)
    {
        Console.Write("\nIngrese el código del producto a modificar: ");
        int codigo = int.Parse(Console.ReadLine());

       
        for (int i = 0; i < productos.Count; i++)
        {
            if (productos[i].Item1 == codigo)
            {
                Console.Write("Ingrese el nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese la nueva cantidad: ");
                int nuevaCantidad = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el nuevo precio: ");
                double nuevoPrecio = double.Parse(Console.ReadLine());

                
                productos[i] = new Tuple<int, string, int, double>(codigo, nuevoNombre, nuevaCantidad, nuevoPrecio);
                Console.WriteLine("Producto modificado exitosamente.");
                return;
            }
        }

        Console.WriteLine("Producto no encontrado.");
    }

    public static void ConsultarProducto(List<Tuple<int, string, int, double>> productos)
    {
        Console.Write("\nIngrese el código del producto a consultar: ");
        int codigo = int.Parse(Console.ReadLine());

      
        for (int i = 0; i < productos.Count; i++)
        {
            if (productos[i].Item1 == codigo)
            {
                MostrarProducto(productos[i]);
                return;
            }
        }

        Console.WriteLine("Producto no encontrado.");
    }

    public static void MostrarTodosProductos(List<Tuple<int, string, int, double>> productos)
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("\nNo hay productos en el inventario.");
            return;
        }

        Console.WriteLine("\n----- Inventario -----");
        foreach (var producto in productos)
        {
            MostrarProducto(producto);
        }
    }

    public static void MostrarProducto(Tuple<int, string, int, double> producto)
    {
        Console.WriteLine($"Código: {producto.Item1}");
        Console.WriteLine($"Nombre: {producto.Item2}");
        Console.WriteLine($"Cantidad: {producto.Item3}");
        Console.WriteLine($"Precio: {producto.Item4:C}");
        Console.WriteLine("---------------------");
    }
}


