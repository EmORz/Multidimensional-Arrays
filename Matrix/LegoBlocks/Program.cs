using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var firstMatrix = Read(input);
            var secondMatrix = Read(input).Select(x => x.Reverse().ToArray()).ToArray();

            Print(firstMatrix, secondMatrix);

     
        }

        private static void Print(int[][] firstMatrix, int[][] secondMatrix)
        {
            if (IsEqual(firstMatrix, secondMatrix))
            {
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    Console.WriteLine("["+string.Join(", ", firstMatrix[row].Concat(secondMatrix[row]))+"]");
                }
            }
            else
            {
                string str = "The total number of cells is: ";
                Console.WriteLine(str+Count(firstMatrix, secondMatrix));
            }
        }

        private static int Count(int[][] firstMatrix, int[][] secondMatrix)
        {
            int count = 0;
            for (int row = 0; row < firstMatrix.Length; row++)
            {
                count += firstMatrix[row].Length + secondMatrix[row].Length;
            }
            return count;
        }

        private static bool IsEqual(int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int row = 1; row < firstMatrix.Length; row++)
            {
                if (firstMatrix[row].Length+secondMatrix[row].Length != firstMatrix[row-1].Length+secondMatrix[row-1].Length)
                {
                    return false;
                }
            }
            return true;
        }

        private static int[][] Read(int input)
        {
            int[][] matrix = new int[input][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            return matrix;
        }
    }
}
