using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var firstMatrix = Read(num);
            var secondMatrix = Read(num).Select(r => r.Reverse().ToArray()).ToArray();

            Print(firstMatrix, secondMatrix);

        }

        private static void Print(int[][] firstMatrix, int[][] secondMatrix)
        {
            if (IsComp(firstMatrix, secondMatrix))
            {
                for (int i = 0; i < firstMatrix.Length; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstMatrix[i].Concat(secondMatrix[i]))}]");
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: " + CelsCount(firstMatrix, secondMatrix));
            }
        }

        private static int CelsCount(int[][] firstMatrix, int[][] secondMatrix)
        {
            int count = 0;

            for (int i = 0; i < firstMatrix.Length; i++)
            {
                count += firstMatrix[i].Length + secondMatrix[i].Length;
            }

            return count;
        }

        private static bool IsComp(int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int i = 1; i < firstMatrix.Length; i++)
            {
                if (firstMatrix[i].Length + secondMatrix[i].Length != firstMatrix[i-1].Length + secondMatrix[i-1].Length)
                {
                    return false;
                }
            }
            return true;
        }

        private static int[][] Read(int num)
        {
            var matrix = new int[num][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] {' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}
