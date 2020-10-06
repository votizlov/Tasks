using System;

namespace Tasks
{
    internal class Task1
    {
        public static void Main(string[] args)
        {
            solveTask(read2dArrFromConsole());
        }

        public static int[,] solveTask(int[,] arr)
        {
            int maxLineSum = 0;
            for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
            {
                maxLineSum += arr[0, j];
            }
            int maxLineIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentLineSum = 0;
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    currentLineSum += arr[i, j];
                }

                if (currentLineSum > maxLineSum)
                {
                    maxLineIndex = i;
                }
            }
            
            int[,] answer = new int[arr.GetUpperBound(0),arr.GetUpperBound(1)];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    answer[i, j] = arr[i, j] / arr[maxLineIndex, j];
                }
            }

            return answer;
        }
        public static int[,] read2dArrFromConsole()
        {
            int[,] items = new int[2, 2];
            int width = items.GetUpperBound(0) + 1;
            int height = items.GetUpperBound(1) + 1;
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    string input;
                    int inputValue;
                    do
                    {
                        Console.WriteLine($"Please input value for ({x},{y}): ");
                    }
                    while (!int.TryParse(input = Console.ReadLine(), out inputValue));
                    items[x, y] = inputValue;
                }
            }

            return items;
        }
    }
}