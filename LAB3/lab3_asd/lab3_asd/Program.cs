using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int N;
        Console.Write("input N for array: = "); N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = rnd.Next(0, 200);
        }

        Console.WriteLine();

        for (int i = 0; i < N; i++)
        {
            if (IsThreeDigitValue(array[i]))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(array[i].ToString() + " ");
                Console.ResetColor();
            }
            else if (array[i] / 100 == 0 && array[i] / 10 > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(array[i].ToString() + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write(array[i].ToString() + " ");
            }
        }

        for (int i = 0; i < N; i++)
        {
            if (IsTwoDigitValue(array[i]))
            {
                int maxValueIndex = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (IsThreeDigitValue(array[j]) && array[j] > array[maxValueIndex])
                    {
                        maxValueIndex = j;
                    }
                }
                int temp = array[i];
                array[i] = array[maxValueIndex];
                array[maxValueIndex] = temp;
            }
            else if (IsTwoDigitValue(array[i]))
            {
                int minValueIndex = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (IsTwoDigitValue(array[j]) && array[j] < array[minValueIndex])
                    {
                        minValueIndex = j;
                    }
                }
                int temp = array[i];
                array[i] = array[minValueIndex];
                array[minValueIndex] = temp;
            }
        }

        Console.WriteLine();
        
    }

    
    static bool IsThreeDigitValue(int value)
    {
        return value / 100 > 0 && value / 1000 == 0;
    }

    static bool IsTwoDigitValue(int value)
    {
        return value / 100 == 0 && value / 10 > 0;
    }
}