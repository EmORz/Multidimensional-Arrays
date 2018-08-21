using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var row = input[0];
            var col = input[1];
            char a = 'a';
            char b = 'a';
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(a);
                    Console.Write(b);
                    Console.Write(a);
                    Console.Write(" ");
                    b++;
                }
                Console.WriteLine();
                a++;
                b = a;
            }
        }
    }
}
