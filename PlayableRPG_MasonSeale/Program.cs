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
            Enemy enemy = new Enemy(player, 10, 8, 10, ConsoleColor.Red, "i", 2);
            FastEnemy speedyEnemy = new FastEnemy(player, 3, 16, 5, ConsoleColor.Magenta, "x", 1);
            Map map = new Map();
            MovementChecker referee = new MovementChecker();
            map.SetBoundries();
            while (true)
            { 
                //update map
                map.Update();
                hud.HudUpdate(player, enemy);
                if (player.AliveChecker() == false)
                {
                    Console.SetCursorPosition(map.FindEndingLine().GetPositionX(), map.FindEndingLine().GetPositionY());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("You Died");
                    enemy.Update();
                    speedyEnemy.Update();
                    break;
                }
                player.Update();
                if (enemy.AliveChecker())
                {
                    enemy.Update();
                }
                if (speedyEnemy.AliveChecker())
                {
                    speedyEnemy.Update();
                }
                //player moves
                player.Move();
                referee.AttackDetection(player, enemy, hud);
                referee.AttackDetection(player, speedyEnemy, hud);
                referee.BoundCheck(player, map);
                referee.PlayerHatFound(player, map, hud);
                referee.PlayerSwordFound(player, map);
                referee.PlayerHealCheck(player, map, hud);
                
                //first enemy moves
                enemy.Move();
                if(enemy.AliveChecker() == false)
                {
                    enemy.RunDeath(map);
                }
                referee.AttackDetection(enemy, player, hud);
                referee.BoundCheck(enemy, map);
                referee.EnemyBumping(enemy, speedyEnemy);

                //second enemy moves
                speedyEnemy.Move();
                if(speedyEnemy.AliveChecker() == false)
                {
                    speedyEnemy.RunDeath(map);
                }
                referee.AttackDetection(speedyEnemy, player, hud);
                referee.BoundCheck(speedyEnemy, map);
                referee.EnemyBumping(speedyEnemy, enemy);


                Console.Clear();
            }
            Console.ReadKey(true);
        }
    }
}
