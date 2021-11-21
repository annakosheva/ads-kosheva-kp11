using System;

namespace asd_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;

            int[,] A = new int[n, n];
            Console.WriteLine("Matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    Random rand = new Random();
                    A[i, j] = rand.Next(-50, 51);
                    
                    Console.Write($"{A[i, j],4}");
                }
                Console.WriteLine();
            }
            {
                int x = 1, y = 0, divx = 1, divy = 0;
                for (int i = 1; i < n - 1; i++)
                {
                    Console.WriteLine(A[y, x] + " " + y + " " + x);
                    x += divx;
                    y += divy;
                }

                divx = 0; divy = 1;

                for (int i = 1; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        Console.WriteLine(A[y, x] + " " + y + " " + x);
                        x += divx;
                        y += divy;
                    }

                    if (divx == 1 && divy == 0)
                    {
                        divx = 0;
                        divy = 1;
                    }
                    else if (divx == 0 && divy == 1)
                    {
                        divx = -1;
                        divy = -1;
                    }
                    else
                    {
                        divx = 1;
                        divy = 0;
                    }


                }


                Console.WriteLine(A[y, x] + " " + y + " " + x);
            }
            Console.WriteLine();
            {
                int x = 0, y = 0, divx = 1, divy = 1;
                for (int i = 0; i < n - 1; i++)
                {
                    Console.WriteLine(A[y, x] + " " + y + " " + x);
                    x += divx;
                    y += divy;

                }

                divx = -1; divy = 0;
                
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j < n - i; j++)
                    {
                        Console.WriteLine(A[y, x] + " " + y + " " + x);
                        x += divx;
                        y += divy;
                    }

                    if (divx == 1 && divy == 1)
                    {
                        divx = -1;
                        divy = 0;
                    }
                    else if (divx == -1 && divy == 0)
                    {
                        divx = 0;
                        divy = -1;
                    }
                    else
                    {
                        divx = 1;
                        divy = 1;
                    }


                }


                Console.WriteLine(A[y, x] + " " + y + " " + x);
            }
            {
                Console.WriteLine(" ");
                double p = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            p += A[i, j] / 2.0;
                        }
                    }
                }
                Console.WriteLine(" Summ = " + p);
                int a = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (A[i, j] > p && i > j)
                        {

                            a = 1;
                            Console.WriteLine($"{ A[i, j],4}");
                        }
                    }
                }
               
                

                if (a == 0)
                {
                    Console.WriteLine("Empty");
                }


                Console.WriteLine(" ");
            }

            int min = A[0, 0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < j && A[i, j] < min)
                    {
                        min = A[i, j];
                    }
                }
            }
            Console.WriteLine("Minimimum is " + min);
        }


    }
}