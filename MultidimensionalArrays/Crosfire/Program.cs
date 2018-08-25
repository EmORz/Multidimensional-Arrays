using System;
using System.Linq;

namespace Crosfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = Initial();
            matrix = Execute(matrix);
            Print(matrix);
        }

        private static void Print(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i].Where(c => c != -1)));
            }
        }
        private static int[][] Execute(int[][] matrix)
        {
            var command = Console.ReadLine().Trim();

            while (command != "Nuke it from orbit")
            {
                var commandsDetails = command.Split().Select(int.Parse).ToArray();
                var row = commandsDetails[0];
                var col = commandsDetails[1];
                var radius = commandsDetails[2];

                matrix = DestroyMatrix(matrix, row, col, radius);
                command = Console.ReadLine().Trim();
            }
            return matrix;
        }

        private static int[][] DestroyMatrix(int[][] matrix, int rowH, int colH, int radius)
        {
            for (int row = rowH-radius; row <= rowH+radius; row++)
            {
                if (IsInMatrix(row, colH, matrix))
                {
                    matrix[row][colH] = -1;
                }
            }
            //
            for (int col = colH - radius; col <= colH + radius; col++)
            {
                if (IsInMatrix(rowH, col, matrix))
                {
                    matrix[rowH][col] = -1;
                }
            }
            //*****
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j]<0)
                    {
                        matrix[i] = matrix[i].Where(X => X > 0).ToArray();
                        break;
                    }

                }
                if (matrix[i].Count()<1)
                {
                    matrix = matrix.Take(i).Concat(matrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }
            return matrix;
        }

        private static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            var checker = row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
            return checker;
        }

        private static int[][] Initial()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var currentCellNum = 1;
            var matrix = new int[dimensions[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[dimensions[1]];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = currentCellNum;
                    currentCellNum++;
                }
            }
            return matrix;
        }
    }
}
