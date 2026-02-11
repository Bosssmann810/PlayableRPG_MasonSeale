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
            Hud hud = new Hud();
            Console.CursorVisible = false;
            Player player = new Player(damage: 1, color: ConsoleColor.Blue, "0", 2, 4, 10);
            Enemy enemy = new Enemy(player, 10, 8, 10, ConsoleColor.Red, "i", 1);
            Map map = new Map();
            MovementChecker referee = new MovementChecker();
            map.SetBoundries();
            while (true)
            { 
                map.Update();
                hud.HudUpdate(player, enemy);
                if (player.AliveChecker() == false)
                {
                    enemy.Update();
                    break;
                }
                player.Update();
                if (enemy.AliveChecker())
                {
                    enemy.Update();
                }
                player.Move();
                referee.PlayerAttackDetection(player, enemy, hud);
                referee.PlayerBoundCheck(player, map);
                referee.PlayerHatFound(player, map);
                referee.PlayerHealCheck(player, map, hud);
                enemy.Move();
                if(enemy.AliveChecker() == false)
                {
                    enemy.RunDeath();
                }
                referee.EnemyAttackDetection(player, enemy, hud);
                referee.EnemyBoundCheck(enemy, map);
                Console.Clear();
            }
            Console.ReadKey(true);
        }
    }
}
