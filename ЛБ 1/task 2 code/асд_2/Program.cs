using System;

namespace асд_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double d, m, a;
            Console.Write("Input d: ");
            d = double.Parse(Console.ReadLine());
            Console.Write("Input m: ");
            m = double.Parse(Console.ReadLine());

            if (m == 1)
            {
                a = d;
            }
            else if (m == 2)
            {
                a = 31 + d;
            }
            else if (m == 3)
            {
                a = 60 + d;
            }
            else if (m == 4)
            {
                a = 91 + d;
            }
            else if (m == 5)
            {
                a = 121 + d;
            }
            else if (m == 6)
            {
                a = 152 + d;
            }
            else if (m == 7)
            {
                a = 182 + d;
            }
            else if (m == 8)
            {
                a = 213 + d;
            }
            else if (m == 9)
            {
                a = 244 + d;

            }
            else if (m == 10)
            {
                a = 274 + d;

            }
            else if (m == 11)
            {
                a = 305 + d;

            }
            else
            {
                a = 335 + d;

            }

            if (a % 7 == 1)
            {
                Console.WriteLine("Wednesday");
            }
            else if (a % 7 == 2)
            {
                Console.WriteLine("Thursday");
            }
            else if (a % 7 == 3)
            {
                Console.WriteLine("Friday");
            }
            else if (a % 7 == 4)
            {
                Console.WriteLine("Saturday");
            }
            else if (a % 7 == 5)
            {
                Console.WriteLine("Sunday");
            }
            else if (a % 7 == 6)
            {
                Console.WriteLine("Monday");
            }
            else if (a % 7 == 7)
            {
                Console.WriteLine("Tuesday");
            }



        }

    }
}
      
