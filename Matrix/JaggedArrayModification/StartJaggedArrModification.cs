using System;
using System.Linq;

namespace JaggedArrayModification
{
    class StartJaggedArrModification
    {
        static void Main(string[] args)
        {
            var matrix = ReadDataToMatrix();
            var readCommand = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (readCommand[0] !="END")
            {
  ;
                var command = readCommand[0];
                var row = int.Parse(readCommand[1]);
                var col = int.Parse(readCommand[2]);
                var update = int.Parse(readCommand[3]);

                if (row<0||col<0||row>matrix.Length||col>matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    readCommand = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        matrix[row][col] += update;
                        break;
                    case "Subtract":
                        matrix[row][col] -= update;
                        break;
                }

                readCommand = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        private static int[][] ReadDataToMatrix()
        {
            var matrixDimension = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[matrixDimension[0]][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            return matrix;
        }
    }
}
