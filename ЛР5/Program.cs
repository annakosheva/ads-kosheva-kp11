using System;

namespace Lab5Var14
{
    class Program
    {
        private const int TestCaseM = 7;
        private const int TestCaseN = 7;

        static void Main(string[] args)
        {
            int N = 0;
            int M = 0;

            Console.WriteLine("Select option:");
            Console.WriteLine("1 - Input matrix size from keyboard");
            Console.WriteLine("2 - Test case");
            Console.WriteLine("Any other button - Quit");
            Int32.TryParse(Console.ReadLine(), out int userInput);

            if(userInput == 1)
            {
                Console.Write("Input N: ");
                string nString = Console.ReadLine();
                int parseResultN = 0;
                if (Int32.TryParse(nString, out parseResultN))
                {
                    N = parseResultN;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }

                Console.Write("Input M: ");
                string mString = Console.ReadLine();
                int parseResultM = 0;
                if (Int32.TryParse(mString, out parseResultM))
                {
                    M = parseResultM;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
            }
            else if (userInput == 2)
            {
                M = TestCaseM;
                N = TestCaseN;
            }
            else
            {
                return;
            }
            
            int[] numbers = GetPseudoRandomSequence(N * M);
            int[][] matrix = GetMatrixWithNumbers(M, N, numbers);
            Console.WriteLine("Generated matrix:");
            OutputMatrix(matrix, M, N);
            Console.WriteLine("Coloured matrix (red - elements to sort):");
            OutputColoredMatrix(matrix, M, N);

            int[] arrayToSort = GetArrayToSort(matrix, M, N);
            Console.WriteLine("Array to be sorted:");
            OutputArray(arrayToSort);

            MergeSortController.MergeWithInternalInsertionSort(arrayToSort);
            Console.WriteLine("Sorted array:");
            OutputArray(arrayToSort);

            ModifyMatrixWithArray(matrix, M, N, arrayToSort);
            Console.WriteLine("Sorted array inserted into matrix:");
            OutputColoredMatrix(matrix, M, N);
        }

        private static int[] GetPseudoRandomSequence(int count)
        {
            int[] result = new int[count];
            Random rand = new Random();
            for(int i = 0; i < count; i++)
            {
                result[i] = i;
            }
            for(int i = 0; i < count; i++)
            {
                int newIndex = rand.Next(count);
                int temp = result[i];
                result[i] = result[newIndex];
                result[newIndex] = temp;
            }
            return result;
        }

        private static int[][] GetMatrixWithNumbers(int m, int n, int[] numbers)
        {
            int[][] resultMatrix = new int[m][];
            
            for(int i = 0; i < m; i++)
            {
                int[] currentRow = new int[n];
                for(int j = 0; j < n; j++)
                {
                    currentRow[j] = numbers[n * i + j];
                }
                resultMatrix[i] = currentRow;
            }
            return resultMatrix;
        }

        private static void OutputMatrix(int[][] matrix, int m, int n)
        {
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void OutputArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        private static void OutputColoredMatrix(int[][] matrix, int m, int n)
        {
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i + j == n - 1 || (i == j && i > m / 2))
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static int[] GetArrayToSort(int[][] matrix, int m, int n)
        {
            int[] result = new int[m + (m - 1) / 2];
            int currentIndex = 0;
            for(int i = m - 1; i >= 0; i--)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i + j == n - 1)
                    {
                        result[currentIndex] = matrix[i][j];
                        currentIndex++;
                    }
                }
            }

            for(int i = m - 1; i >= 0; i--)
            {
                for(int j = n - 1; j >= 0; j--)
                {
                    if(i == j && i > m / 2)
                    {
                        result[currentIndex] = matrix[i][j];
                        currentIndex++;
                    }
                }
            }

            return result;
        }

        private static void ModifyMatrixWithArray(int[][] matrix, int m, int n, int[] arr)
        {
            int currentIndex = 0;
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j == n - 1)
                    {
                        matrix[i][j] = arr[currentIndex];
                        currentIndex++;
                    }
                }
            }

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == j && i > m / 2)
                    {
                        matrix[i][j] = arr[currentIndex];
                        currentIndex++;
                    }
                }
            }
        }
    }
}
