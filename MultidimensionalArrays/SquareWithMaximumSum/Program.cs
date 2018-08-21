using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = GetMatrixFromConsole();
            var biggets = int.MinValue;
            var resultStart = new int[2];

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length-1; c++)
                {
                    var sum = matrix[r][c]+matrix[r][c+1]+matrix[r+1][c]+matrix[r+1][c+1];
                    if (sum > biggets)
                    {
                        biggets = sum;
                        resultStart[0] = r;
                        resultStart[1] = c;
                    }
                }
            }
            Console.WriteLine($"{matrix[resultStart[0]][resultStart[1]]} {matrix[resultStart[0]][resultStart[1]+1]}\n" +
                $"{matrix[resultStart[0]+1][resultStart[1]]} {matrix[resultStart[0]+1][resultStart[1] + 1]}");
           
            Console.WriteLine(biggets);

        }
        private static int[][] GetMatrixFromConsole()
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[dimensions[0]][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Take(dimensions[1])
                    .ToArray();
            }
            return matrix;
        }
    }
}
