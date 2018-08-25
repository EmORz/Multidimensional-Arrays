using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = InitializeMatrix();
            ExecuteCommands(matrix);
            Console.Write(GetReangeMatrix(matrix));

        }

        private static string GetReangeMatrix(int[][] matrix)
        {
            var sb = new StringBuilder();
            var expectedvalue = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0;  j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] !=expectedvalue)
                    {
                        sb.Append(Swap(matrix, i, j, expectedvalue));
                    }
                    else
                    {
                        sb.Append($"No swap required{Environment.NewLine}");
                    }
                    expectedvalue++;
                }
            }
            return sb.ToString();
        }

        private static string Swap(int[][] matrix, int row, int col, int expectedvalue)
        {

            for (int i = row; i < matrix.Length; i++)
            {
                for (int j = 0;  j < matrix[i].Length; j++)
                {

                    if (matrix[i][j] == expectedvalue)
                    {
                        var temp = matrix[i][j];
                        matrix[i][j] = matrix[row][col];
                        matrix[row][col] = temp;
                        return $"Swap ({row}, {col}) with ({i}, {j})\n";
                    }
                }
            }
            return string.Empty;

        }

        private static void ExecuteCommands(int[][] matrix)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = n ; i > 0; i--)
            {
                var command = Console.ReadLine().Split();
                RotateMatrix(matrix, int.Parse(command[0]), command[1], int.Parse(command[2]));
            }
        }
       
        private static void RotateMatrix(int[][] matrix, int rowCol, string direction, int moves)
        {
            switch (direction.ToLower())
            {
                case "up":
                    var rowBecomingFirst = moves % matrix.Length;
                    if (rowBecomingFirst !=0)
                    {
                        RotateColumn(matrix, rowCol, rowBecomingFirst);
                    }
                    break;
                case "down":
                    rowBecomingFirst = moves % matrix.Length == 0 ? 0 : matrix.Length - (moves % matrix.Length);
                    if (rowBecomingFirst != 0)
                    {
                        RotateColumn(matrix, rowCol, rowBecomingFirst);
                    }
                    break;
                case "left":
                    var colBecomingFirst = moves % matrix[rowCol].Length;

                    if (colBecomingFirst != 0)
                    {
                        RotateRow(matrix, rowCol, colBecomingFirst);
                    }

                    break;
                case "right":
                    colBecomingFirst = (moves % matrix[rowCol].Length == 0) ?
                        0 : 
                        matrix[rowCol].Length - (moves % matrix[rowCol].Length);
                    if (colBecomingFirst != 0)
                    {
                        RotateRow(matrix, rowCol, colBecomingFirst);
                    }
                    break;
                default:
                    break;
            }

        }

        private static void RotateRow(int[][] matrix, int row, int col)
        {
            var data = new Queue<int>(matrix[row].Length);

            for (int i = 0; i < matrix[row].Length; i++)
            {
                if (col == matrix[row].Length)
                {
                    col = 0;
                }
                data.Enqueue(matrix[row][col]);
                col++;
            }
            matrix[row] = data.ToArray();
        }

        private static void RotateColumn(int[][] matrix, int col, int row)
        {
            var data = new Queue<int>(matrix.Length);


            while (data.Count< matrix.Length)
            {
                if (row == matrix.Length)
                {
                    row = 0;
                }
                data.Enqueue(matrix[row][col]);
                row++;
            }
            for (int h = 0; h < matrix.Length; h++)
            {
                matrix[h][col] = data.Dequeue();
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
