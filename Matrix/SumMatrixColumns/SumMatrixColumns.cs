using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadDataToMatrix();

            for (int a = 0; a < matrix[0].Length; a++)
            {
                var sum = 0;
                for (int b = 0; b < matrix.Length; b++)
                {

                    sum += matrix[b][a];
                }
                Console.WriteLine(sum);
            }

        }

        private static int[][] ReadDataToMatrix()
        {
            var matrixDimension = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[matrixDimension[0]][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            return matrix;
        }
    }
}
