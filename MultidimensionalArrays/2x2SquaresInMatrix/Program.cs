using System;
using System.Linq;

namespace _2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadData();

            var checkForSquare = Check(matrix);
            int result = checkForSquare;
            Console.WriteLine(result);


        }

        private static int Check(char[][] matrix)
        {
            var counter = 0;

            for (int r = 0; r < matrix.Length-1; r++)
            {
                for (int c = 0; c < matrix[0].Length-1; c++)
                {
                    if (   matrix[r][c] == matrix[r][c+1]
                        && matrix[r][c] == matrix[r+1][c]
                        && matrix[r][c] == matrix[r+1][c+1])
                    {
                        counter++;
                    }
                }
            }



            return counter;
        }

        private static char[][] ReadData()
        {
            var arrInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new char[arrInput[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .ToCharArray()
                    .Where(x => x != ' ').ToArray();
            }



            return matrix;
        }
    }
}
