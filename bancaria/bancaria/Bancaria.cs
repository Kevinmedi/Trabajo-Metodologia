using System;
using System.Collections.Generic;

namespace CuentaBancaria
{
    internal class CuentaBancaria
    {
        public static void Main(string[] args)
        {
            List<Tuple<string, decimal>> transacciones = new List<Tuple<string, decimal>>();
            decimal saldo = 0;
            MostrarMenu(transacciones, ref saldo);
        }

        public static void MostrarMenu(List<Tuple<string, decimal>> transacciones, ref decimal saldo)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("---- Menú de opciones ----");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Ver historial de transacciones");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        ConsultarSaldo(saldo);
                        break;

                    case 2:
                        DepositarDinero(transacciones, ref saldo);
                        break;

                    case 3:
                        RetirarDinero(transacciones, ref saldo);
                        break;

                    case 4:
                        MostrarHistorial(transacciones);
                        break;

                    case 5:
                        Console.WriteLine("Gracias por usar el programa. ¡Adiós!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 5);
        }

        public static void ConsultarSaldo(decimal saldo)
        {
            Console.WriteLine($"Su saldo actual es: ${saldo}");
        }

        public static void DepositarDinero(List<Tuple<string, decimal>> transacciones, ref decimal saldo)
        {
            Console.Write("Ingrese la cantidad a depositar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal deposito) && deposito > 0)
            {
                saldo += deposito;
                transacciones.Add(new Tuple<string, decimal>("Depósito", deposito));
                Console.WriteLine($"Has depositado: ${deposito}. Su nuevo saldo es: ${saldo}");
            }
            else
            {
                Console.WriteLine("Cantidad no válida. Intente de nuevo.");
            }
        }

        public static void RetirarDinero(List<Tuple<string, decimal>> transacciones, ref decimal saldo)
        {
            Console.Write("Ingrese la cantidad a retirar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal retiro) && retiro > 0)
            {
                if (retiro <= saldo)
                {
                    saldo -= retiro;
                    transacciones.Add(new Tuple<string, decimal>("Retiro", retiro));
                    Console.WriteLine($"Has retirado: ${retiro}. Su nuevo saldo es: ${saldo}");
                }
                else
                {
                    Console.WriteLine("Fondos insuficientes.");
                }
            }
            else
            {
                Console.WriteLine("Cantidad no válida. Intente de nuevo.");
            }
        }

        public static void MostrarHistorial(List<Tuple<string, decimal>> transacciones)
        {
            if (transacciones.Count == 0)
            {
                Console.WriteLine("No hay transacciones realizadas.");
            }
            else
            {
                Console.WriteLine("Historial de transacciones:");
                foreach (var transaccion in transacciones)
                {
                    Console.WriteLine($"{transaccion.Item1}: ${transaccion.Item2}");
                }
            }
        }
    }
}