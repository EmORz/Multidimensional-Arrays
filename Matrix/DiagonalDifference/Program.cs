using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = MakeMatrix(n);
            var first = 0;
            var second = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    first += matrix[row][row];
                    second += matrix[row][matrix.Length-1 - row];
                    break;              
                }
            }
            Console.WriteLine(Math.Abs(first-second));
        }

        private static int[][] MakeMatrix(int n)
        {
            int[][] matrix = new int[n][];

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            return matrix;
        }
    }
}
