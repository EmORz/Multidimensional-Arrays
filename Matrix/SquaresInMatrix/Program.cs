using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new char[] {' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var row = dimensions[0];
            var col = dimensions[1];
     
            char[,] matrix = new char[row, col];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = str[c];
                }
            }
            var counter = 0;
            for (int rr = 0; rr < matrix.GetLength(0)-1; rr++)
            {
                for (int cc = 0; cc < matrix.GetLength(1)-1; cc++)
                {
                    bool areEqual = matrix[rr, cc] == matrix[rr, cc + 1] &&
                                    matrix[rr, cc]==matrix[rr+1, cc+1]&&
                                    matrix[rr, cc]==matrix[rr+1, cc];
                    if (areEqual)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
