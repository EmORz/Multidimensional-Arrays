using System;
using System.Linq;

namespace MaximalSum
{
    class MaxSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = arr[0];
            var cols = arr[1];

            int[,] matrixNumbers = new int[rows, cols];

            for (int row = 0; row < matrixNumbers.GetLength(0); row++)
            {
                int[] currentNumbers = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrixNumbers.GetLength(1); col++)
                {
                    matrixNumbers[row, col] = currentNumbers[col];
                }
            }
            var sumMax = int.MinValue;
            var rowPos = 0;
            var colPos = 0;

            for (int row = 0; row < matrixNumbers.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrixNumbers.GetLength(1)-2; col++)
                {
                    int sum = matrixNumbers[row, col] + matrixNumbers[row, col + 1]+matrixNumbers[row, col+2] +
                              matrixNumbers[row+1, col] + matrixNumbers[row+1, col + 1] + matrixNumbers[row+1, col + 2]+
                              matrixNumbers[row+2, col] + matrixNumbers[row+2, col + 1] + matrixNumbers[row+2, col + 2];
                    if (sum>sumMax)
                    {
                        sumMax = sum;
                        rowPos = row;
                        colPos = col;
                  
                    }
                }
            }
            Console.WriteLine("Sum = " + sumMax);
            for (int row = rowPos; row < rowPos+3; row++)
            {
                for (int col = colPos; col < colPos+3; col++)
                {
                    Console.Write(matrixNumbers[row, col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
