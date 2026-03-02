using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class GameManager
    {
        Hud hud;
        Player player;
        Enemy enemy;
        FastEnemy speedyEnemy;
        Map map;
        MovementChecker referee;

        public void Start()
        {
            hud = new Hud();
            player = new Player(damage: 1, color: ConsoleColor.Blue, "0", 2, 4, 10);
            enemy = new Enemy(player, 10, 8, 10, ConsoleColor.Red, "i", 2);
            speedyEnemy = new FastEnemy(player, 3, 16, 5, ConsoleColor.Magenta, "x", 1);
            map = new Map();
            referee = new MovementChecker();

            map.SetBoundries();

        }
        public void Update()
        {
            while (true)
            {
                //update map
                map.Update();
                hud.HudUpdate(player);
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
                referee.EnemyAttackMessageDetection(enemy, player, hud);
                referee.AttackDetection(player, enemy, hud);
                referee.EnemyAttackMessageDetection(speedyEnemy, player, hud);
                referee.AttackDetection(player, speedyEnemy, hud);
                
                referee.BoundCheck(player, map);
                referee.PlayerHatFound(player, map, hud);
                referee.PlayerSwordFound(player, map, hud);
                referee.PlayerArmorFound(player, map, hud);
                referee.PlayerHealCheck(player, map, hud);

                //first enemy moves
                enemy.Move();
                if (enemy.AliveChecker() == false)
                {
                    enemy.RunDeath(map);
                }
                referee.AttackDetection(enemy, player, hud);
                referee.BoundCheck(enemy, map);
                referee.EnemyBumping(enemy, speedyEnemy);

                //second enemy moves
                speedyEnemy.Move();
                if (speedyEnemy.AliveChecker() == false)
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

