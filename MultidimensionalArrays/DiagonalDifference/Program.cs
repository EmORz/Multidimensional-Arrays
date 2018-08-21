using System;
using System.Dynamic;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadData();
            var primary = SumOfDiagonals(matrix, "primary");
            var seconadary = SumOfDiagonals(matrix, "secondary");
            var diff = Math.Abs(primary - seconadary);
            Console.WriteLine(diff);

        }

        private static int SumOfDiagonals(int[][] matrix, string diagonal)
        {
            var chooseDiagonal = diagonal.ToLower().Equals("primary") ? matrix.Length-1 : 0;
            var sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][Math.Abs(chooseDiagonal - i)];
            }

            return sum;
        }

        public static int[][] ReadData()
        {
            var dimensions = int.Parse(Console.ReadLine());

            var matrix = new int[dimensions][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split()
                    .Take(dimensions)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}
