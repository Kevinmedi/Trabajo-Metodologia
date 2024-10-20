using System;
using System.ComponentModel.Design;
using System.Runtime.Serialization.Formatters;


public class Diccionario 
    {
    static void Main(string[] args)
    {
        List<Tuple<string, string>> diccionario = crearDiccionario();
        traducir(diccionario);

    }

    public static List<Tuple<string, string>> crearDiccionario()

    {
        List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Ingrese la palabra {i+1} en ingles");
            string pal1= Console.ReadLine();
            Console.WriteLine($"Ingrese la palabra {i + 1} en español");
            string pal2= Console.ReadLine();
            diccionario.Add(new Tuple<string, string>(pal1, pal2));
        
        }
        return (diccionario);


    }
    public static void traducir (List<Tuple<string, string>> diccionario)
    {
        Console.Write("Ingrese la palabra a traducir");
        string clave= Console.ReadLine();
        bool encontrado=false;
        foreach (var duo in diccionario)
        {
            if (duo.Item1.Equals(clave , StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"La palabra {clave} traducida es: {duo.Item2}");
                break;
                encontrado = true;
            }
            
        }
        if (!encontrado) 
        {
            Console.WriteLine($"La palabra {clave} no se encontro");
        
        
        }

        }
    }
