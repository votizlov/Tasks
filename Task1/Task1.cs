using System;

namespace Tasks
{
    internal class Task1
    {
        public static void Main(string[] args)
        {
            PrintArr2d(solveTask(read2dArrFromConsole()));
        }
        public void test(){}

        public static float[,] solveTask(int[,] arr)
        {
            int maxLineSum = 0;
            for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
            {
                maxLineSum += arr[0, j];
            }

            int maxLineIndex = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int currentLineSum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    currentLineSum += arr[i, j];
                }

                if (currentLineSum > maxLineSum)
                {
                    maxLineIndex = i;
                }
            }

            float[,] answer = new float[arr.GetLength(0), arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    answer[i, j] = arr[i, j] / (float)arr[maxLineIndex, j];
                }
            }

            return answer;
        }

        public static void PrintArr2d(float[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] read2dArrFromConsole()
        {
            int width;
            int height;
            string input;
            do
            {
                Console.WriteLine("Please input first dimension: ");
            } while (!int.TryParse(input = Console.ReadLine(), out width));

            do
            {
                Console.WriteLine("Please input second dimension: ");
            } while (!int.TryParse(input = Console.ReadLine(), out height));

            int[,] items = new int[width, height];

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    int inputValue;
                    do
                    {
                        Console.WriteLine("Please input value for ({x},{y}): ");
                    } while (!int.TryParse(input = Console.ReadLine(), out inputValue));

                    items[x, y] = inputValue;
                }
            }

            return items;
        }
    }
}