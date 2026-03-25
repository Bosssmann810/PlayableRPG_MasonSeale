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
        bomb bomb;
        Enemy enemy;
        Enemy secondEnemy;
        Enemy hoard1;
        Enemy hoard2;
        Enemy hoard3;
        Enemy hoard4;
        Enemy hoard5;
        Enemy hoard6;
        Enemy hoard7;
        Enemy hoard8;
        Enemy hoard9;
        Enemy hoard10;
        Enemy hoard11;
        Enemy hoard12;
        Enemy hoard13;
        Enemy hoard14;
        Enemy hoard15; 
        Enemy hoard16;
        Enemy hoard17;
        Enemy hoard18;
        Enemy hoard19;
        Enemy hoard20;
        Enemy hoard21;
        Enemy hoard22;
        Enemy fred;
        FastEnemy speedyEnemy;
        FastEnemy secondSpeedEnemy;
        BeefyEnemy beefyEnemy;
        Map currentMap;
        Map firstMap = new Map();
        Map secondMap = new SecondMap();
        MovementChecker referee;
        List<Character> _enemyManager = new List<Character>();

        public void Start()
        {
            hud = new Hud();
            player = new Player(damage: 1, color: ConsoleColor.Blue, "0", 2, 4, 10);
            enemy = new Enemy(player, 10, 8, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(enemy);
            secondEnemy = new Enemy(player, 15, 17, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(secondEnemy);
            speedyEnemy = new FastEnemy(player, 3, 16, 5, ConsoleColor.Magenta, "x", 1);
            _enemyManager.Add(speedyEnemy);
            secondSpeedEnemy = new FastEnemy(player, 42, 2, 5, ConsoleColor.Magenta, "x", 1);
            _enemyManager.Add(secondSpeedEnemy);
            beefyEnemy = new BeefyEnemy(player, 45, 10, 20, ConsoleColor.DarkRed, "&", 2);
            _enemyManager.Add(beefyEnemy);
            hoard1 = new Enemy(player, 52, 5, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard1);
            hoard2 = new Enemy(player, 53, 5, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard2);
            hoard3 = new Enemy(player, 54, 5, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard3);
            hoard4 = new Enemy(player, 55, 5, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard4);
            hoard5 = new Enemy(player, 56, 5, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard5);
            hoard6 = new Enemy(player, 52, 6, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard6);
            hoard7 = new Enemy(player, 53, 6, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard7);
            hoard8 = new Enemy(player, 54, 6, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard8);
            hoard9 = new Enemy(player, 55, 6, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard9);
            hoard10 = new Enemy(player, 56, 6, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard10);
            hoard11 = new Enemy(player, 52, 7, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard11);
            hoard12 = new Enemy(player, 53, 7, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard12);
            hoard13 = new Enemy(player, 54, 7, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard13);
            hoard14 = new Enemy(player, 55, 7, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard14);
            hoard15 = new Enemy(player, 56, 7, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard15);
            hoard16 = new Enemy(player, 52, 8, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard16);
            hoard17 = new Enemy(player, 53, 8, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard16);
            hoard18 = new Enemy(player, 54, 8, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard18);
            hoard19 = new Enemy(player, 55, 8, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard19);
            hoard20 = new Enemy(player, 56, 8, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard20);
            hoard21 = new Enemy(player, 52, 9, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard21);
            hoard22 = new Enemy(player, 53, 9, 10, ConsoleColor.Red, "i", 2);
            _enemyManager.Add(hoard22);
            fred = new Enemy(player, 54, 9, 10, ConsoleColor.DarkRed, "i", 2);
            _enemyManager.Add(fred);

            currentMap = new Map();
            referee = new MovementChecker();
            
            currentMap.SetBoundries();
            bomb = new bomb(currentMap);
            player.GetBomb(bomb);
        }
        public void Update()
        {
            while (true)
            {
                //update map
                currentMap.Update();
                hud.HudUpdate(player);
                if (player.AliveChecker() == false)
                {
                    Console.Clear();
                    currentMap.Update();
                    Console.SetCursorPosition(currentMap.FindEndingLine().GetPositionX(), currentMap.FindEndingLine().GetPositionY());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("You Died. Game Over");
                    foreach (Character enemy in _enemyManager)
                    {
                        if (enemy.AliveChecker())
                        {
                            enemy.Update();
                        }
                    }
                    break;
                }
                player.Update();
                foreach(Character enemy in _enemyManager)
                {
                    if (enemy.AliveChecker())
                    {
                        enemy.Update();
                    }
                }
                bomb.Update(player);
                //player moves
                player.Move();
                //run all detection if the player hit an enemy
                foreach(Character enemy in _enemyManager)
                {
                    referee.EnemyAttackMessageDetection(enemy, player, hud);
                    referee.AttackDetection(player, enemy, hud);
                }

                if(referee.LoadMapCheck(player, currentMap) == true)
                {
                    ChangeMap(secondMap, currentMap);
                }
                //run all detection if the player hit something else
                referee.BoundCheck(player, currentMap);
                referee.PlayerHatFound(player, currentMap, hud, bomb);
                
                referee.PlayerSwordFound(player, currentMap, hud);
                referee.PlayerArmorFound(player, currentMap, hud);
                referee.PlayerHealCheck(player, currentMap, hud);
                referee.PlayerGoldCheck(player, currentMap, hud);
                referee.LavaCheck(player, currentMap, hud);
                if(player.CheckGold() >= 26)
                {
                    Console.Clear();
                    currentMap.Update();
                    hud.WinMessage();
                    hud.HudUpdate(player);
                    
                    break;
                }
                foreach(Character enemy in _enemyManager)
                {  
                    if(bomb.GetExplosionZone().Contains((enemy.GetXPos(), enemy.GetYPos())))
                    {
                        enemy.Pain(10);
                    }
                    enemy.Move();  
                  
                    if(enemy.AliveChecker() == false)
                    {
                        enemy.Disable(currentMap);
                    }
                    referee.AttackDetection(enemy, player, hud);
                    referee.BoundCheck(enemy, currentMap);
                    foreach(Character otherenemy in _enemyManager)
                    {
                        if(otherenemy != enemy)
                        {
                            referee.EnemyBumping(enemy, otherenemy);
                        }
                    }

                } 
                hud.WipeHud(currentMap);    
                Console.SetCursorPosition(0,0);
                
                //enemy.Disable(map);
                
            }
            Console.ReadKey(true);
        }
        //this dose not work and as such is never used.
        public void ChangeMap(Map newmap, Map currentmap)
        {
            player.SetPosition(newmap.GetNewMapSpawn().Item1, newmap.GetNewMapSpawn().Item2);
            currentmap = newmap;
            currentmap.SetBoundries();
            currentmap.Update();
        }

        //this is called after the game ends
        public void PostGameDialouge()
        {
            _enemyManager.Clear();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would You like play again?");
            Console.WriteLine("Press Esc to quit or R to play again");
        }
    }

}

