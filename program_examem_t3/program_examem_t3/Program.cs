using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 namespace ejercicio_t3_FunAlgo
    {
        internal class Program
        {
            const double NOTA_MINIMA_APROBATORIA = 11.0;

            // Arreglos 
            static string[] nombresEvaluaciones = { "T1", "T2", "T3", "Evaluación Final" };
            static double[] pesosEvaluaciones = { 0.10, 0.20, 0.30, 0.40 };
            static void Main()
            {
                string continuar;
                do
                {
                    Console.WriteLine("\n=== Sistema de Evaluación ===");

                    Console.Write("Ingrese el nombre del estudiante: ");
                    string nombre = Console.ReadLine();
                    double[] notas = new double[nombresEvaluaciones.Length];
                    for (int i = 0; i < nombresEvaluaciones.Length; i++)
                    {
                        notas[i] = LeerNota(nombresEvaluaciones[i]);
                    }
                    double promedioFinal = CalcularPromedio(notas);
                    string condicion = DeterminarCondicion(promedioFinal);

                    MostrarReporte(nombre, notas, promedioFinal, condicion);
                    Console.Write("\n¿Desea evaluar a otro estudiante? (S/N): ");
                    continuar = Console.ReadLine().ToUpper();
                } while (continuar == "S");
                Console.WriteLine("\nPrograma finalizado.");
            }
            static double LeerNota(string nombreEvaluacion)
            {
                double nota;
                bool valido;
                do
                {
                    Console.Write($"Ingrese la nota de {nombreEvaluacion} (0-20): ");
                    string entrada = Console.ReadLine();
                    valido = double.TryParse(entrada, out nota);

                    if (!valido || nota < 0 || nota > 20)
                    {
                        Console.WriteLine("Error: Ingrese un valor numérico entre 0 y 20.");
                        valido = false;
                    }

                } while (!valido);

                return nota;
            }
            static double CalcularPromedio(double[] notas)
            {
                double promedio = 0;
                for (int i = 0; i < notas.Length; i++)
                {
                    promedio += notas[i] * pesosEvaluaciones[i];
                }
                return promedio;
            }
            static string DeterminarCondicion(double promedio)
            {
                if (promedio >= NOTA_MINIMA_APROBATORIA)
                    return "APROBADO";
                else
                    return "DESAPROBADO";
            }
            static void MostrarReporte(string nombre, double[] notas, double promedio, string condicion)
            {
                Console.WriteLine("\n=== Reporte del Estudiante ===");
                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine("-----------------------------------");

                for (int i = 0; i < nombresEvaluaciones.Length; i++)
                {
                    double aporte = notas[i] * pesosEvaluaciones[i];
                    Console.WriteLine($"{nombresEvaluaciones[i]}: Nota = {notas[i]}, Peso = {pesosEvaluaciones[i] * 100}%, Aporte = {aporte:F2}");
                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Promedio Final: {promedio:F2}");
                Console.WriteLine($"Condición Académica: {condicion}");
            }

        }
 }


