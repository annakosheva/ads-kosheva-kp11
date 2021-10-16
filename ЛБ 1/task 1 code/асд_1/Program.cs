using System;

namespace асд_1
{
    class Program
    {
        static void Main(string[]args)
        {
            double x, y, z, a, b;
            Console.Write("Input x: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Input y: ");
            y = double.Parse(Console.ReadLine());
            Console.Write("Input z: ");
            z = double.Parse(Console.ReadLine());

            if (x * x * x + x == 0 || z == 0 || x - y < 0)
            {
                Console.WriteLine("error");
            }
            else
            {
                a = x + (Math.Pow((Math.Abs(y) + z * z * z), 1.0 / 3.0) / (x * x * x + x));
                Console.WriteLine("a is: " + a.ToString());
                if (a * a == 0)
                {
                    Console.WriteLine("error");
                }
                else
                {
                    b = ((Math.Sqrt(x - y) / z)) + 1 / (a * a);
                    Console.WriteLine("b is: " + b.ToString());
                }
            }

        }
    }
}
