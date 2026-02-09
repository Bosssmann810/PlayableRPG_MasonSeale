using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Player player = new Player(damage: 1, color: ConsoleColor.Blue, "0", 2, 2, 10);
            Enemy enemy = new Enemy(player, 5, 5, 10, ConsoleColor.Red, "i", 1);
            Map map = new Map();
            MovementChecker refferee = new MovementChecker();
            map.SetBoundries();
            while (true)
            { 
                map.Update();
                player.Update();
                enemy.Update();
                player.Move();
                refferee.PlayerAttackDetection(player, enemy);
                refferee.PlayerBoundCheck(player, map);
                //enemy.Move();
                refferee.EnemyAttackDetection(player, enemy);
                refferee.EnemyBoundCheck(enemy, map);
                Console.WriteLine(player.GetPlayerX().ToString());
                Console.Clear();
            }

        }

    }
}
