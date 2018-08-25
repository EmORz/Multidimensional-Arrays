using System;

namespace TheHeiganDance
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player()
            {
                Position = new int[] { 7, 7 },
                Blood = 18500,
                Damage = double.Parse(Console.ReadLine()),
                IsHitByCloud = false
            };

            double bossHeiganDamage = 3000000;
            string spell = "";

            while (true)
            {
                if (player.IsHitByCloud)
                {
                    player.Blood -= 3500;
                    player.IsHitByCloud = false;
                }
                bossHeiganDamage -= player.Damage;

                if (IfGameOver(player, bossHeiganDamage, spell))
                {
                    break;
                }
                var bossAtack = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                spell = bossAtack[0];
                var hitRow = int.Parse(bossAtack[1]);
                var hitCol = int.Parse(bossAtack[2]);

                if (IsReached(player.Position[0], player.Position[1], hitRow, hitCol) && IsPlayerDamage(player, hitRow, hitCol))
                {
                    switch (spell)
                    {
                        case "Cloud":
                            player.Blood -= 3500;
                            player.IsHitByCloud = true;
                            break;
                        case "Eruption":
                            player.Blood -= 6000;
                            break;
                        default:
                            break;
                    }
                }
                 if (IfGameOver(player, bossHeiganDamage, spell))
                {
                    break;
                }

            }

        }

        private static bool IsCellReached(int v1, int v2, int hitRow, int hitCol)
        {

            throw new NotImplementedException();
        }

        private static bool IsPlayerDamage(Player player, int hitRow, int hitCol)
        {
            if (player.Position[0] > 0 && 
                !IsReached(player.Position[0] - 1, player.Position[1], hitRow, hitCol))
            {
                player.Position[0]--;
                return false;
            }
            if (player.Position[1] + 1 < 15 && 
                !IsReached(player.Position[0], player.Position[1]+1, hitRow, hitCol))
            {
                player.Position[1]++;
                return false;
            }
            if (player.Position[0] + 1 < 15 && 
                !IsReached(player.Position[0]+1, player.Position[1], hitRow, hitCol))
            {
                player.Position[0]++;
                return false;
            }
            if (player.Position[1] > 0 && 
                !IsReached(player.Position[0], player.Position[1]- 1, hitRow, hitCol))
            {
                player.Position[1]--;
                return false;
            }
            return true;
        }

        private static bool IsReached(int cellRoww, int cellCol, int hitRow, int hitCol)
        {
            return (cellRoww >=hitRow -1) && (cellRoww<=hitRow+1)&&(cellCol>=hitCol -1) &&(cellCol<=hitCol+1);
        }

        private static bool IfGameOver(Player player, double bossHeiganDamage, string spell)
        {
            if (player.Blood <=0 || bossHeiganDamage<=0)
            {
                if (spell == "Cloud")
                {
                    spell = "Plague Cloud";
                }
                var boss = bossHeiganDamage > 0 ? $"Heigan: {bossHeiganDamage:f2}" : $"Heigan: Defeated!";
                var playerData = player.Blood > 0 ? $"Player: {player.Blood}" : $"Player: Killed by {spell}";
                Console.WriteLine(boss);
                Console.WriteLine(playerData);

                Console.WriteLine($"Final position: {player.Position[0]}, {player.Position[1]}");
                return true;
            }
            return false;
        }
    }
    public class Player
    {
        public int[] Position { get; set; }

        public int Blood { get; set; }

        public double Damage { get; set; }

        public bool IsHitByCloud { get; set; }
    }
}
