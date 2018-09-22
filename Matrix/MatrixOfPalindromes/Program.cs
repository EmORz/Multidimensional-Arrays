using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] inputNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var row = inputNum[0];
            var col = inputNum[1];

            var matrix = ReadData(row, col, alphabet);

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static string[][] ReadData(int row, int col, char[] alphabet)
        {
            string[][] matrix = new string[row][];

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r] = new string[col];
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    matrix[r][c] = $"{alphabet[r]}{alphabet[r+c]}{alphabet[r]} ";
                }
            }
            return matrix;
        }
    }
}
