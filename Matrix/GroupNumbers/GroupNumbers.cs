using System;
using System.Linq;

namespace GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var zero = inputArr.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            var one = inputArr.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            var two = inputArr.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            int[][] jagga = new int[3][];
            jagga[0] = zero;
            jagga[1] = one;
            jagga[2] = two;
            foreach (int[] item in jagga)
            {
                Console.WriteLine(string.Join(" ", item));
            }


        }
    }
}
