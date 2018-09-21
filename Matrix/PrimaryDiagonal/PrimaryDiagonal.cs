using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            var matrix = ReadDataToMatrix();
            var sumOfDiagonal = 0.0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (row == col)
                    {
                        sumOfDiagonal += matrix[row][col];                        
                    }
                }
            }
            Console.WriteLine(sumOfDiagonal);
        }
        private static int[][] ReadDataToMatrix()
        {
            var matrixDimension = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[matrixDimension[0]][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            return matrix;
        }
    }
}
