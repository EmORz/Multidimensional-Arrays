using System;
using System.Linq;

namespace RubikMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //read data and make matrix
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];

            int[][] matrixRubik = new int[rows][];

            GetMatrix(matrixRubik, cols);

            //Print(matrixRubik);
            int commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                string[] input = Console.ReadLine().Split();
                var rowCol = int.Parse(input[0]);
                var direction = input[1];
                var moves = int.Parse(input[2]);
                //
                if (direction=="down")
                {
                    MovesDown(matrixRubik, rowCol, moves % matrixRubik.Length);
                }
                else if (direction == "left")
                {
                    MovesLeft(matrixRubik, rowCol, moves % matrixRubik[0].Length);
                }
                else if (direction == "right")
                {
                    MovesRight(matrixRubik, rowCol, moves % matrixRubik[0].Length);
                }
                else if (direction == "up")
                {
                    MovesUp(matrixRubik, rowCol, moves % matrixRubik.Length);

                }               
                
            }
            var counter = 1;
            for (int row = 0; row < matrixRubik.Length; row++)
            {
                for (int col = 0; col < matrixRubik[row].Length; col++)
                {
                    if (matrixRubik[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearrange(matrixRubik, row, col, counter);
                        counter++;
                    }
                }
            }
        }

        private static void Rearrange(int[][] matrixRubik, int row, int col, int counter)
        {
            for (int targertRow = 0; targertRow < matrixRubik.Length; targertRow++)
            {
                for (int targetCol = 0; targetCol < matrixRubik[targertRow].Length; targetCol++)
                {
                    if (matrixRubik[targertRow][targetCol] == counter)
                    {
                        matrixRubik[targertRow][targetCol] = matrixRubik[row][col];
                        matrixRubik[row][col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({targertRow}, {targetCol})");
                        return;
                    }
                }
            }
        }

        private static void MovesUp(int[][] matrixRubik, int col, int moves)
        {
            for (int move = 0; move < moves; move++)
            {
                var last = matrixRubik[0][col];
                for (int row = 0; row < matrixRubik.Length-1; row++)
                {
                    matrixRubik[row][col] = matrixRubik[row + 1][col];
                }
                matrixRubik[matrixRubik.Length - 1][col] = last;
            }

        }

        private static void MovesRight(int[][] matrixRubik, int row, int moves)
        {
            for (int move = 0; move < moves; move++)
            {
                var lastElement = matrixRubik[row][matrixRubik[row].Length-1];

                for (int col = matrixRubik.Length - 1; col > 0; col--)
                {
                    matrixRubik[row][col] = matrixRubik[row][col - 1];
                }
                matrixRubik[row][0] = lastElement;
            }
  
        }

        private static void MovesLeft(int[][] matrixRubik, int row, int moves)
        {
            for (int move = 0; move < moves; move++)
            {
                var firstElemet = matrixRubik[row][0];

                for (int col = 0; col < matrixRubik[row].Length - 1; col++)
                {
                    matrixRubik[row][col] = matrixRubik[row][col + 1];
                }
                matrixRubik[row][matrixRubik[row].Length - 1] = firstElemet;
            }
       
        }

        private static void MovesDown(int[][] matrixRubik, int col, int moves)
        {
            for (int move = 0; move < moves; move++)
            {
                var lastElemet = matrixRubik[matrixRubik.Length - 1][col];
                for (int row = matrixRubik.Length - 1; row > 0; row--)
                {
                    matrixRubik[row][col] = matrixRubik[row - 1][col];
                }
                matrixRubik[0][col] = lastElemet;
            }
       
        }

        private static void Print(int[][] matrixRubik)
        {
            for (int row = 0; row < matrixRubik.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrixRubik[row]));
            }
        }

        private static void GetMatrix(int[][] matrixRubik, int cols)
        {
            var counter = 1;
            for (int row = 0; row < matrixRubik.Length; row++)
            {
                matrixRubik[row] = new int[cols];
                for (int col = 0; col < matrixRubik[row].Length; col++)
                {
                    matrixRubik[row][col] = counter++;
                }
            }
        }
    }
}
