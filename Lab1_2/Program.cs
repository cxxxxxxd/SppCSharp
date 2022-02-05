using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Exercise 1");
                    Console.WriteLine("2. Exercise 2");
                    Console.WriteLine("3. Exercise 3");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("Enter: ");

                    string action = Console.ReadLine();
                    switch (action)
                    {
                        case "1":
                            int[] vector1 = InitializeVector();
                            WriteVector(vector1);
                            Console.WriteLine("Exercise 1 run...");
                            Exe1(ref vector1);
                            WriteVector(vector1);
                            break;
                        case "2":
                            int[] vector2;
                            int[,] matrix2 = InitializeMatrix();
                            WriteMatrix(matrix2);
                            Console.WriteLine("Exercise 2 run...");
                            Exe2(matrix2, out vector2);
                            WriteVector(vector2);
                            break;
                        case "3":
                            int[,] matrix3 = InitializeMatrix();
                            WriteMatrix(matrix3);
                            Console.WriteLine("Exercise 3 run...");
                            Exe3(ref matrix3);
                            WriteMatrix(matrix3);
                            break;
                        case "0":
                            return;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static int[] InitializeVector()
        {
            try
            {
                Console.Write("Enter count of vector's elements: ");
                int n = int.Parse(Console.ReadLine());
                int[] vector = new int[n];
                for (int i = 0; i < vector.Length; i++)
                {
                    Console.Write($"Enter element [{i + 1}]:");
                    vector[i] = int.Parse(Console.ReadLine());
                }                
                return vector;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static int[,] InitializeMatrix()
        {
            try
            {
                Console.Write("Enter size of matrix: ");
                int n = int.Parse(Console.ReadLine());
                int[,] matrix = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"Enter element[{i + 1}][{j + 1}]:");
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }               
                return matrix;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void WriteVector(params int[] elems)
        {
            Console.WriteLine("Vector:\n");
            foreach (var elem in elems)
            {
                Console.Write($"{elem}\t");
            }
            Console.WriteLine("\n");
        }

        private static void WriteMatrix(int[,] matrix)
        {
            Console.WriteLine("Matrix:\n");
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write($"{matrix[i, j]}\t");

                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        private static void Exe1(ref int[] vector)
        {
            int min = vector.Min();
            int minI = Array.IndexOf(vector, min);
            int max = vector.Max();
            for (int i = 0; i < minI; i++)
                vector[i] *= max;
        }

        private static void Exe2(int[,] matrix, out int[] vector)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            vector = new int[columns];
            int max = 0;
            for (int i = 0; i < columns; i++)
            {
                max = matrix[0, i];
                for (int j = 1; j < rows; j++)
                {
                    if (matrix[j, i] > max)
                        max = matrix[j, i];
                }
                vector[i] = max;
            }
        }

        private static void Exe3(ref int[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            int min = 0;
            int minJ = 0;
            int max = 0;
            int maxJ = 0;
            for (int i = 0; i < columns; i++)
            {
                min = matrix[0, i];
                max = matrix[0, i];
                minJ = 0;
                maxJ = 0;

                for (int j = 1; j < rows; j++)
                {
                    if (matrix[j, i] < min)
                    {
                        min = matrix[j, i];
                        minJ = j;
                    }

                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        maxJ = j;
                    }
                }

                for (int j = 0; j < rows; j++)
                {
                    if (j != minJ && j != maxJ)
                        matrix[j, i] = 0;
                }
            }
        }
    }
}
