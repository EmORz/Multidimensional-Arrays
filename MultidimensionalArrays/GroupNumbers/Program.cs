using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            Console.WriteLine(string.Join(" ", input.Where(x => x % 3 == 0)));
            Console.WriteLine(string.Join(" ", input.Where(x => Math.Abs(x) % 3 == 1)));
            Console.WriteLine(string.Join(" ", input.Where(x => Math.Abs(x) % 3 == 2)));
        }
    }
}
