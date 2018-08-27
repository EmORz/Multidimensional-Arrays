using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] playerPosition;
            var bunnies = Initialize(out playerPosition);
            PlayTheGame(bunnies, playerPosition);
        }

        private static void PlayTheGame(bool[][] bunnies, int[] playerPosition)
        {
            while (true)
            {
                var playerSpeedDirections = Console.ReadLine().ToCharArray();
                var isPlayerdEscaped = false;

                foreach (var stepDirection in playerSpeedDirections)
                {
                    isPlayerdEscaped = IsPlayerdEscaped(bunnies, playerPosition, stepDirection);
                    MultiplyBunnies(bunnies);

                    if (isPlayerdEscaped)
                    {
                        Print(bunnies);
                        Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
                        return;
                    }
                    if (bunnies[playerPosition[0]][playerPosition[1]])
                    {
                        Print(bunnies);
                        Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                        return;
                    }
                }
            }
            throw new NotImplementedException();
        }

        private static void Print(bool[][] bunnies)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < bunnies.Length; i++)
            {
                for (int j = 0; j < bunnies[i].Length; j++)
                {
                    sb.Append(bunnies[i][j] ? 'B' : '.');
                }
                sb.Append("\n");
            }
            Console.WriteLine(sb.ToString().Trim());

        }

        private static void MultiplyBunnies(bool[][] bunnies)
        {
            var newBunnies = new Stack<int[]>();
            for (int i = 0; i < bunnies.Length; i++)
            {
                for (int j = 0; j < bunnies[i].Length; j++)
                {
                    if (bunnies[i][j])
                    {
                        newBunnies.Push(new int[] { i + 1, j });
                        newBunnies.Push(new int[] { i - 1, j });
                        newBunnies.Push(new int[] { i, j+1 });
                        newBunnies.Push(new int[] { i, j-1 });
                    }
                }
            }
            while (newBunnies.Count > 0)
            {
                var currentBunnie = newBunnies.Pop();

                if (isInsideTheLayer(currentBunnie, bunnies))
                {
                    bunnies[currentBunnie[0]][currentBunnie[1]] = true;
                }
            }
        }

        private static bool IsPlayerdEscaped(bool[][] bunnies, int[] playerPosition, char stepDirection)
        {
            switch (stepDirection)
            {
                case 'U':
                    playerPosition[0]--;
                    if (!isInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[0]++;
                        return true;
                    }
                    break;
                case 'D':
                    playerPosition[0]++;
                    if (!isInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[0]--;
                        return true;
                    }
                    break;
                case 'L':
                    playerPosition[1]--;
                    if (!isInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[1]++;
                        return true;
                    }
                    break;
                case 'R':
                    playerPosition[1]++;

                    if (!isInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[1]--;
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        private static bool isInsideTheLayer(int[] playerPosition, bool[][] bunnies)
        {
            var checker = (playerPosition[0] >= 0 && playerPosition[0] < bunnies.Length) && (playerPosition[1] >= 0 && playerPosition[1] < bunnies[0].Length);
            return checker;
        }

        private static bool[][] Initialize(out int[] playerPosition)
        {
            var dimenssion = Console.ReadLine().Split().Select(int.Parse).ToArray();
            playerPosition = new int[] { 0, 0 };
            var bunnies = new bool[dimenssion[0]][];

            for (int i = 0; i < bunnies.Length; i++)
            {
                var input = Console.ReadLine();
                bunnies[i] = new bool[input.Length];

                for (int j = 0; j < bunnies[i].Length; j++)
                {
                    if (input[j] == 'B')
                    {
                        bunnies[i][j] = true;
                    }
                    else if (input[j] == 'P')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;
                    }
                }
            }
            return bunnies;
        }
    }
}
