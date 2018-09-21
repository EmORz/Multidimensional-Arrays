using System;
using System.Linq;

namespace SymbolInMatrix
{
    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            var matrix = ReadDataToMatrix();
            var searchedSymbol = char.Parse(Console.ReadLine());
            //
            int[] temporal = new int[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == searchedSymbol)
                    {
                        temporal[0] = row;
                        temporal[1] = col;
                        Console.WriteLine($"({temporal[0]}, {temporal[1]})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
            
        }
        private static char[][] ReadDataToMatrix()
        {
            var matrixDimension = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixDimension][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            return matrix;
        }
    }
}
