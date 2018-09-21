using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            long[][] jaggedArr = new long[n][];

            for (int i = 1; i <= n; i++)
            {
                jaggedArr[i - 1] = new long[i];
                jaggedArr[i-1][0] = 1;
                jaggedArr[i-1][jaggedArr[i-1].Length - 1] = 1;
            }

            for (int i = 2; i < n; i++)
            {
                for (int j = 1; j < jaggedArr[i].Length-1; j++)
                {
                    jaggedArr[i][j] = jaggedArr[i - 1][j - 1] + jaggedArr[i - 1][j];
                }
            }

            foreach (var item in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
