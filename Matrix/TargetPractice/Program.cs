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
            int[] dimensions = Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] targets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] matrix = new char[rows][];

            GetMatrix(matrix, cols, snake);  
            Shoot(matrix, targets);
            Collapse(matrix);
            Print(matrix);

        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> elements = new Queue<char>(matrix.Length);
            for (int col = 0; col < matrix[0].Length; col++)
            {
                var counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }
                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }
                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
          
        }

        private static void Shoot(char[][] matrix, int[] targets)
        {
            var targetRow = targets[0];
            var targetCol = targets[1];
            var radius = targets[2];


            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInsidePitagorTheory = Math.Pow((targetRow-row), 2)+Math.Pow((targetCol-col),2)<=Math.Pow(radius,2);
                    if (isInsidePitagorTheory)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void Print(char[][] matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item ));

            }
        }

        private static void GetMatrix(char[][] matrix, int cols, string snake)
        {
            var counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];
                if (isLeft)
                {                 
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }
                    isLeft = false;
                }
                else
                {                  
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }
                    isLeft = true;
                }
              

            }

        }

        private static int SetLetter(char[][] matrix, string snake, int counter, int row, int col)
        {
            if (counter > snake.Length - 1)
            {
                counter = 0;
            }
            matrix[row][col] = snake[counter++];
            return counter;
        }
    }
}
