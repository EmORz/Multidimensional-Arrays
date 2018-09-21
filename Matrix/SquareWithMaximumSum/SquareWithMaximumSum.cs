using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            var matrix = ReadDataToMatrix();
            if (matrix == null)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);
                return;
            }
            PrintMatrixWithBiggestSum(matrix);
        }

        private static void PrintMatrixWithBiggestSum(int[][] matrix)
        {
            var biggestSum = int.MinValue;
            var takeResultFromMatrix = new int[2];

            for (int a = 0; a < matrix.Length-1; a++)
            {
                for (int b = 0; b < matrix[0].Length-1; b++)
                {
                    var temp = matrix[a][b] + matrix[a][b + 1]+matrix[a+1][b]+matrix[a+1][b+1];
                    if (temp > biggestSum)
                    {
                        biggestSum = temp;
                        takeResultFromMatrix[0] = a;
                        takeResultFromMatrix[1] = b;
                    }
                }
            }
            var first = matrix[takeResultFromMatrix[0]][takeResultFromMatrix[1]]+" "+ matrix[takeResultFromMatrix[0]][takeResultFromMatrix[1]+1];
            var second = matrix[takeResultFromMatrix[0]+1][takeResultFromMatrix[1]] + " " + matrix[takeResultFromMatrix[0]+1][takeResultFromMatrix[1] + 1];
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(biggestSum);
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
