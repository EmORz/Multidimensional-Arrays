using System;
using System.Collections.Generic;
using System.Text;

namespace StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var rotateGegrees = Initialize();

            if (rotateGegrees == 0 || rotateGegrees == 90)
            {
                int maxCount;
                var matrix = InitializeQueue( out maxCount);
                Print(matrix, rotateGegrees, maxCount);

            }
            else if (rotateGegrees == 180 || rotateGegrees == 270)
            {
                int maxCount;
                var matrix = InitializeMatrix(out maxCount);
                Print(matrix, rotateGegrees, maxCount);

            }
            else
            {
                throw new Exception("Wrong input. Degrees must be multiple of 90°!!!");
            }
        }

        private static void Print(List<Queue<char>> matrix, int rotateGegrees, int maxCount)
        {
            var sb = new StringBuilder();

            if (rotateGegrees == 0)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    sb.Append(string.Join("", matrix[i]));
                    if (matrix[i].Count < matrix.Count)
                    {
                        sb.Append(new string(' ', maxCount - matrix.Count));
                    }
                    sb.Append("\n");
                }
            }
            else if (rotateGegrees == 90)
            {
                while (maxCount > 0)
                {
                    for (int i = matrix.Count - 1; i >= 0; i--)
                    {
                        if (matrix[i].Count > 0)
                        {
                            sb.Append(matrix[i].Dequeue());
                        }
                        else
                        {
                            sb.Append(' ');
                        }
                    }
                    sb.Append("\n");
                    maxCount--;
                }
            }
            Console.Write(sb.ToString());
        }

        private static void Print(List<Stack<char>> matrix, int rotateGegrees, int maxCount)
        {
            var sb = new StringBuilder();

            if (rotateGegrees == 180)
            {
                for (int i = matrix.Count - 1; i >= 0; i--)
                {
                    sb.Append(string.Join("", matrix[i]));
                    if (matrix[i].Count < matrix.Count)
                    {
                        sb.Append(new string(' ', maxCount - matrix[i].Count));
                    }
                    sb.Append("\n");
                }
            }
            else if (rotateGegrees == 270)
            {
                while (maxCount > 0)
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        if (matrix[i].Count>0 && matrix[i].Count == maxCount)
                        {
                            sb.Append(matrix[i].Pop());
                        }
                        else
                        {
                            sb.Append(' ');
                        }
                    }
                    sb.Append("\n");
                    maxCount--;
                }
            }
            Console.Write(sb.ToString());
        }

        private static List<Stack<char>> InitializeMatrix(out int maxCount)
        {
            maxCount = 0;
            var matrix = new List<Stack<char>>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                maxCount = Math.Max(maxCount, input.Length);
                matrix.Add(new Stack<char>(input.ToCharArray()));
                input = Console.ReadLine();
            }
            return matrix;

        }

     

        private static List<Queue<char>> InitializeQueue(out int maxCount)
        {
            maxCount = 0;
            var matrix = new List<Queue<char>>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                maxCount = Math.Max(maxCount, input.Length);
                matrix.Add(new Queue<char>(input.ToCharArray()));
                input = Console.ReadLine();
            }
            return matrix;
        }

        private static int Initialize()
        {
            var input = Console.ReadLine();
            input = input.Remove(0, input.IndexOf('(')+1);
            return int.Parse(input.Substring(0, input.IndexOf(')'))) % 360;
        }
    }
}
