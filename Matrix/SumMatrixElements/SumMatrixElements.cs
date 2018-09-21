using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadDataToMatrix();
            var rowNumbers = matrix.Length;
            var colNUmbers = matrix[0].Length;
            var sumOfAllNumInMatrix = matrix.Select(x => x.Sum());
            //*************************************************************
            Console.WriteLine(rowNumbers);
            Console.WriteLine(colNUmbers);
            Console.WriteLine(string.Join("", sumOfAllNumInMatrix.Sum()));
            //*************************************************************

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
