using System;
using System.Linq;

namespace TestSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = GetValueOfMatrix();
            var sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);

            Console.WriteLine(row);
            Console.WriteLine(col);
            Console.WriteLine(sum);

        }

        private static int[,] GetValueOfMatrix()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                var rowValues = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            return matrix;
        }
    }
}
