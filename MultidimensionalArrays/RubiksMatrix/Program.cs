using System;
using System.Linq;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = InitializeMatrix();
            //ToDo
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    Console.Write(matrix[r][c]);
                }
                Console.WriteLine();
            }

        }
        private static int[][] InitializeMatrix()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new int[dimensions[0]][].Select(r => r = new int[dimensions[1]]).ToArray();

            var cellValue = 1;

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    matrix[r][c] = cellValue;
                    cellValue++;
                }
            }
            return matrix;
        }
    }
}
