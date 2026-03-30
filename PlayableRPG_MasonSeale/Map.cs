using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Map
    {
        List<(int,int)> _noGoZone = new List<(int, int)>();
        List<(int, int)> _healSpots = new List<(int, int)>();
        List<(int, int)> _lavaSpots = new List<(int, int)>();
        List<(int, int)> _goldSpots = new List<(int, int)>();
        List<(int, int)> _goldManager = new List<(int, int)>();
        List<(int, int)> _itemManager = new List<(int, int)>();
        (int, int) _bombLocation;
        (int, int) _swordLocation;
        (int, int) _armorLocation;
        bool _bombCollected = false;
        bool _swordCollected = false;
        bool _armorCollected = false;
        Position _endingLine = new Position(1,1);
        (int,int) _exit;
        bool _active = true;
        (int, int) _spawn;
        
        //sets all parts that need to be interacted with, borders, the hat location and heal spots.
        public virtual void SetBoundries()
        {
            string path = "map.txt";
            string[] map = File.ReadAllLines(path);

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '│' || map[i][j] == '─' || map[i][j] == '┐' || map[i][j] == '┌' || map[i][j] == '┘' || map[i][j] == '└' || map[i][j] == '^')
                    {
                        _noGoZone.Add((j,i));
                    }
                    if (map[i][j] == '+')
                    {
                        _healSpots.Add((j, i));
                    }
                    if (map[i][j] == '*')
                    {
                        _bombLocation = (j, i);
                    }
                    if (map[i][j] == '!')
                    {
                        _swordLocation = (j, i);
                        _itemManager.Add((j, i));
                    }
                    if (map[i][j] == ':')
                    {
                        _endingLine = new Position(j, i);
                    }
                    if (map[i][j] == '=')
                    {
                        _lavaSpots.Add((j, i));
                    }
                    if (map[i][j] == '@')
                    {
                        _armorLocation = (j, i);
                        _itemManager.Add((j, i));
                    }
                    if (map[i][j] == '-')
                    {
                        _goldSpots.Add((j, i));
                        _itemManager.Add((j, i));
                    }
                    if (map[i][j] == '[')
                    {
                        _exit = (j, i);
                    }
                }
            }
        }
        //draws the map to the screen
        public virtual void Update()
        {
            string path = "Map.txt";
            string[] map = File.ReadAllLines(path);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < map.GetLength(0); i++)
            {  
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '`')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    if (map[i][j] == '│' || map[i][j] == '─' || map[i][j] == '┐' || map[i][j] == '┌' || map[i][j] == '┘' || map[i][j] == '└')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (map[i][j] == '+')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (map[i][j] == '-')
                    { 
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        if (_goldSpots.Contains((j, i)) == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write('`');
                            continue;
                        }
                    }
                    if (map[i][j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (map[i][j] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    if (map[i][j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (map[i][j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        //if the hat is collected just draw a normal grass tile instead.
                        if (_bombCollected == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write('`');
                            continue;
                        }
                    }
                    if (map[i][j] == '!')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if(_swordCollected == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("~");
                            continue;
                        }
                    }
                    if (map[i][j] == '=')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    if (map[i][j] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (_armorCollected == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("`");
                            continue;
                        }
                    }
                    if (map[i][j] == ':')
                    {
                        continue;
                    }
                    if (FindEndingLine().GetPositionY() >= Console.WindowHeight)
                    {
                        Console.WriteLine("Please increase console size to fit the map on screen.");
                        Console.WriteLine("If the map is displaying incorrectly please increase the window size further");
                        return;
                    }
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();

               
            }
        }
        //returns the list of no go places for later use

        public List<(int,int)> GetListNoGo()
        {
            return _noGoZone;
        }

        //returns the list of healing spots
        public List<(int,int)> GetHealthSpots()
        {
            return _healSpots;
        }

        public List<(int, int)> GetLavaSpots()
        {
            return _lavaSpots;
        }
        public List<(int,int)> GetGoldSpots()
        {
            return _goldSpots;
        }
        public (int,int) BombHat()
        {
            return _bombLocation;
        }
        public (int, int) FindSword()
        {
            return _swordLocation;
        }
        public (int,int) FindArmor()
        {
            return _armorLocation;
        }
        public void CollectBomb()
        {
            _bombCollected = true;
        }
        public void CollectSword()
        {
            _swordCollected = true;
        }

        public void CollectArmor()
        {
            _armorCollected = true;
        }
        //returns the position of the bottom most line
        public Position FindEndingLine()
        {
            return _endingLine;
        }
        public (int,int) GetMapLoadZone()
        {
            return _exit;
        }
        public (int,int) GetNewMapSpawn()
        {
            return _spawn;
        }

        public void RemoveGold(Position pos)
        {
            _goldSpots.Remove((pos.GetPositionX(), pos.GetPositionY()));
        }

    }
}
