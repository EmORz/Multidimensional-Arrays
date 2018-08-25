using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var stairs = InitializationMatrix();
            ShootOnSnake(stairs);
            Console.WriteLine(string.Join("\n", stairs.Select(r => string.Join("", r))));
        }

        private static void ShootOnSnake(char[][] matrix)
        {
            var shootData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var impactRow = shootData[0];
            var impactCol = shootData[1];
            var impactRadius = shootData[2];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (IsCellShooted(i, j, impactRow, impactCol, impactRadius))
                    {
                        matrix[i][j] = ' ';
                        
                    }
                }
            }

            for (int i = 0; i < matrix[0].Length; i++)
            {
                for (int j = matrix.Length - 1; j > 0; j--)
                {
                    if (matrix[j][i] == ' ' && matrix[j-1][i] !=' ')
                    {
                        CellsFallDown(matrix, j, i);
                    }
                }
            }
        }

        private static void CellsFallDown(char[][] matrix, int row, int col)
        {
            while (row < matrix.Length)
            {
                if (matrix[row][col] == ' ')
                {
                    var temp = matrix[row - 1][col];
                    matrix[row - 1][col] = matrix[row][col];
                    matrix[row][col] = temp;
                    row++;
                }
                else
                {
                    return;
                }
            }
        }

        private static bool IsCellShooted(int i, int j, int impactRow, int impactCol, int impactRadius)
        {
            var distance = Math.Sqrt((i - impactRow)*(i - impactRow)+(j - impactCol)*(j-impactCol));
            return distance <= impactRadius;
        }

        private static char[][] InitializationMatrix()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new char[dimensions[0]][].Select(r => r = new char[dimensions[1]]).ToArray();

            var snake = new Queue<char>(Console.ReadLine().ToCharArray());

            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                for (int j = matrix[i].Length - 1; j >= 0; j--)
                {
                    matrix[i][j] = snake.Dequeue();
                    snake.Enqueue(matrix[i][j]);
                }
                i--;

                if (i<0)
                {
                    break;
                }

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = snake.Dequeue();
                    snake.Enqueue(matrix[i][j]);
                }
            }
            return matrix;
        }
    }
}
