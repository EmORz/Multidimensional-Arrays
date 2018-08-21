using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadData();

            Print(matrix);

        }

        private static void Print(int[][] matrix)
        {
            var biggestSum = int.MinValue;
            var resul = new int[2];


            for (int r = 0; r < matrix.Length-2; r++)
            {
                for (int c = 0; c < matrix[r].Length-2; c++)
                {
                    var tempSum = matrix[r][c]+matrix[r][c+1]+matrix[r][c+2]
                        +matrix[r+1][c]+matrix[r+1][c+1]+matrix[r+1][c+2]+
                        matrix[r+2][c]+matrix[r+2][c+1]+matrix[r+2][c+2];

                    if (tempSum > biggestSum)
                    {
                        biggestSum = tempSum;
                        resul[0] = r;
                        resul[1] = c;
                    }

                }
            }

            Console.WriteLine($"Sum = {biggestSum}");
            Console.WriteLine(string.Join("\n",
                matrix
                    .Skip(resul[0])
                    .Take(3)
                    .Select(r => string.Join(" ", r.Skip(resul[1]).Take(3)))));
        }

        private static int[][] ReadData()
        {
            var inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new int[inputArr[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).Take(inputArr[1]).ToArray();
            }

            return matrix;

        }
    }
}
