using System;
using System.Linq;

namespace SumAllElementsOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = GetMatrixFromConsole();
            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(matrix.Select(r => r.Sum()).Sum());
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
