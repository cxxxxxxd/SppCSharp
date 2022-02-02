using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    internal class Program
    {
        const int MinX = -6;
        const int MaxX = 6;

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Xn = ");
                double xn = double.Parse(Console.ReadLine());
                Console.Write("Xk = ");
                double xk = double.Parse(Console.ReadLine());

                if(xn > xk)
                {
                    throw new Exception("Inccorect interval");
                }

                Console.Write("h = ");
                double h = double.Parse(Console.ReadLine());

                double f = default;

                WriteHeader();
                for (double x = xn; x <= xk; x += h)
                {
                    if (x >= MinX && x <= MaxX)
                    {
                        f = CalculateExpression(x);
                        WriteResult(x, f);
                    }
                    else
                    {
                        WriteResult(x);
                    }
                }
                WriteFooter();                
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

        static double CalculateExpression(double x)
        {
            if(x >= -6 && x <= -4)
            {
                return -1;
            }
            else if(x > -4 && x <= 0)
            {
                return x / 4;
            }
            else if(x > 0 && x <= 2)
            {
                return 0.00138783 * Math.Pow(Math.E, 3.63651 * x);
            }
            else
            {
                return 3 - x / 2;
            }
        }

        static void WriteHeader()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("|x\t|f\t\t|");
            Console.WriteLine("-------------------------");
        }

        static void WriteFooter()
        {
            Console.WriteLine("-------------------------");
        }

        static void WriteResult(double x, double f)
        {            
            Console.WriteLine("|{0:0.00}\t|{1:0.00}\t\t|", x, f);
        }

        static void WriteResult(double x)
        {
            Console.WriteLine("|{0:0.00}\t|undefined\t|", x);
        }
    }
}
