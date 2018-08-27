using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingDimenssionRowCol = InitializeParking();
            var usedCells = new HashSet<Cell>();

            var input = Console.ReadLine().Split();

            while (input[0] !="stop")
            {
                var carEntranceRow = int.Parse(input[0]);
                var parkingAim = new Cell
                {
                    Row = int.Parse(input[1]),
                    Column = int.Parse(input[2])
                };
                //
                if (IsParked(parkingAim, usedCells, parkingDimenssionRowCol))
                {
                    Console.WriteLine(Math.Abs((carEntranceRow+1)-(parkingAim.Row +1))+parkingAim.Column+1);
                    usedCells.Add(parkingAim);
                }
                else
                {
                    Console.WriteLine($"Row {parkingAim.Row} full");
                }
                input = Console.ReadLine().Split();
            }

        }
        private static bool IsParked(Cell parkingAim, HashSet<Cell> usedCells, int[] parkingDimenssionRowCol)
        {

            if (usedCells
                .Where(x => x.Row == parkingAim.Row && x.Column == parkingAim.Column)
                .FirstOrDefault() == null)
            {
                return true;
            }
            var testCol = 1;


            while (true)
            {
                var leftCol = parkingAim.Column - testCol;
                var right = parkingAim.Column + testCol;

                if (leftCol <=0 && right >= parkingDimenssionRowCol[1])
                {
                    break;
                }

                if (leftCol>0 
                    && usedCells.Where(x => x.Row == parkingAim.Row && x.Column == leftCol)
                    .FirstOrDefault() == null)
                {
                    parkingAim.Column = leftCol;
                    return true;
                }

                if (right < parkingDimenssionRowCol[1] 
                    && usedCells.Where(x => x.Row == parkingAim.Row && x.Column == right)
                    .FirstOrDefault() == null)
                {
                    parkingAim.Column = right;
                    return true;
                }
                testCol++;
            }
            return false;
        }
        private static int[] InitializeParking()
        {
            var dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new int[] { dimension[0], dimension[1] };
        }
    }
    class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }


    }
}
