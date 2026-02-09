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
        
        public void SetBoundries()
        {
            string path = "map.txt";
            string[] map = File.ReadAllLines(path);

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '│' || map[i][j] == '─' || map[i][j] == '┐' || map[i][j] == '┌' || map[i][j] == '┘' || map[i][j] == '└')
                    {
                        _noGoZone.Add((j,i));
                    }
                }
            }
        }
        public void Update()
        {
            string path = "Map.txt";
            string[] map = File.ReadAllLines(path);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                
                for (int j = 0; j < map[i].Length; j++)
                {
                    Console.Write(map[i][j]);
                }
                Console.WriteLine();
            }
        }

        public List<(int,int)> GetList()
        {
            return _noGoZone;

        }

    }
}
