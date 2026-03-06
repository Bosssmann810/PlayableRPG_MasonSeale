using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            } 
        }
        protected GameManager()
        {

        }
        Hud hud;
        Player player;
        Enemy enemy;
        Enemy secondEnemy;
        FastEnemy speedyEnemy;
        BeefyEnemy beefyEnemy;
        Map map;
        MovementChecker referee;

        public void Start()
        {
            hud = new Hud();
            player = new Player(damage: 1, color: ConsoleColor.Blue, "0", 2, 4, 10);
            enemy = new Enemy(player, 10, 8, 10, ConsoleColor.Red, "i", 2);
            secondEnemy = new Enemy(player, 15, 17, 10, ConsoleColor.Red, "i", 2);
            speedyEnemy = new FastEnemy(player, 3, 16, 5, ConsoleColor.Magenta, "x", 1);
            beefyEnemy = new BeefyEnemy(player, 47, 10, 20, ConsoleColor.DarkRed, "&", 2);
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
                if (secondEnemy.AliveChecker())
                {
                    secondEnemy.Update();
                }
                if (speedyEnemy.AliveChecker())
                {
                    speedyEnemy.Update();
                }
                if (beefyEnemy.AliveChecker())
                {
                    beefyEnemy.Update();
                }
                //player moves
                player.Move();
                //run all detection if the player hit an enemy
                referee.EnemyAttackMessageDetection(enemy, player, hud);
                referee.AttackDetection(player, enemy, hud);
                referee.EnemyAttackMessageDetection(speedyEnemy, player, hud);
                referee.AttackDetection(player, speedyEnemy, hud);
                referee.EnemyAttackMessageDetection(beefyEnemy, player, hud);
                referee.AttackDetection(player, beefyEnemy, hud);
                referee.EnemyAttackMessageDetection(secondEnemy, player, hud);
                referee.AttackDetection(player, secondEnemy, hud);
                //run all detection if the player hit something else
                referee.BoundCheck(player, map);
                referee.PlayerHatFound(player, map, hud);
                referee.PlayerSwordFound(player, map, hud);
                referee.PlayerArmorFound(player, map, hud);
                referee.PlayerHealCheck(player, map, hud);
                referee.PlayerGoldCheck(player, map, hud);
                referee.LavaCheck(player, map, hud);
                if(referee.PlayerGoldCheck(player,map,hud) == true)
                { 
                    Console.SetCursorPosition(map.FindEndingLine().GetPositionX(), map.FindEndingLine().GetPositionY());
                    hud.HudUpdate(player);
                    break;
                }

                //first enemy moves
                enemy.Move();
                if (enemy.AliveChecker() == false)
                {
                    enemy.RunDeath(map);
                }
                referee.AttackDetection(enemy, player, hud);
                referee.BoundCheck(enemy, map);
                referee.EnemyBumping(enemy, speedyEnemy);
                referee.EnemyBumping(enemy, beefyEnemy);
                referee.EnemyBumping(enemy, secondEnemy);

                //second enemy moves
                secondEnemy.Move();
                if (secondEnemy.AliveChecker() == false)
                {
                    secondEnemy.RunDeath(map);
                }
                referee.AttackDetection(secondEnemy, player, hud);
                referee.BoundCheck(secondEnemy, map);
                referee.EnemyBumping(secondEnemy, enemy);
                referee.EnemyBumping(secondEnemy, beefyEnemy);
                referee.EnemyBumping(secondEnemy, speedyEnemy);
                
                //speedy enemy moves
                speedyEnemy.Move();
                if (speedyEnemy.AliveChecker() == false)
                {
                    speedyEnemy.RunDeath(map);
                }
                referee.AttackDetection(speedyEnemy, player, hud);
                referee.BoundCheck(speedyEnemy, map);
                referee.EnemyBumping(speedyEnemy, enemy);
                referee.EnemyBumping(speedyEnemy, beefyEnemy);
                referee.EnemyBumping(speedyEnemy, secondEnemy);

                //beefy enemy moves (I could totally make this a list and loop function but I don't want to at the moment
                beefyEnemy.Move();
                if (beefyEnemy.AliveChecker() == false)
                {
                    beefyEnemy.RunDeath(map);
                }
                referee.AttackDetection(beefyEnemy, player, hud);
                referee.BoundCheck(beefyEnemy, map);
                referee.EnemyBumping(beefyEnemy, enemy);
                referee.EnemyBumping(beefyEnemy, speedyEnemy);
                referee.EnemyBumping(beefyEnemy, secondEnemy);
                
                Console.Clear();
                //enemy.Disable(map);
            }
            Console.ReadKey(true);
        }
    }
}

