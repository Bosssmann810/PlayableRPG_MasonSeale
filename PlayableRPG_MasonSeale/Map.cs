using System;
using System.Collections.Generic;
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
        (int, int) _hatLocation;
        bool _collected = false;
        
        //sets all parts that need to be interacted with, borders, the hat location and heal spots.
        public void SetBoundries()
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
                        _hatLocation = (j, i);
                    }
                }
            }
        }
        //draws the map to the screen
        public void Update()
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
                    if (map[i][j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (map[i][j] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    if (map[i][j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        //if the hat is collected just draw a normal grass tile instead.
                        if (_collected == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write('`');
                            continue;
                        }
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
        public (int,int) FindHat()
        {
            return _hatLocation;
        }
        public void CollectHat()
        {
            _collected = true;
        }

    }
}
