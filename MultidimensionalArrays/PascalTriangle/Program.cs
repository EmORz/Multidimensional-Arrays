using System;
using System.Numerics;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            BigInteger temp = 0;

            for (int row = 0; row < n; row++)
            {
                for (int space = 0; space < n - row; space++)
                {
                    Console.Write(" ");
                }
                for (int col = 0; col <= row; col++)
                {
                    if (row ==0 || col == 0)
                    {
                        temp = 1;
                    }
                    else
                    {
                        temp = temp * (row-col+1) / col;
                    }
                    Console.Write($"{temp} ");
                }
                Console.WriteLine();
            }
            //
            //for (int row = n -2; row >= 0; row--)
            //{
            //    for (int space = 0; space < n - row; space++)
            //    {
            //        Console.Write(" ");
            //    }
            //    for (int col = 0; col <= row; col++)
            //    {
            //        if (row == 0 || col == 0)
            //        {
            //            temp = 1;
            //        }
            //        else
            //        {
            //            temp = temp * (row - col + 1) / col;
            //        }
            //        Console.Write($"{temp} ");
            //    }
            //    Console.WriteLine();
            //}

        }
      
    }
}
