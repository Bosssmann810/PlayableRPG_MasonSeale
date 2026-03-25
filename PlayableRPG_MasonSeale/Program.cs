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
            bool playing = true;
            Console.CursorVisible = false;
            GameManager _gameManager = GameManager.Instance;
            while (true)
            {
                _gameManager.Start();
                _gameManager.Update();
                _gameManager.PostGameDialouge();
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if(key.Key == ConsoleKey.Escape)
                    {
                        playing = false;
                        break;
                    }
                    if(key.Key == ConsoleKey.R)
                    {
                        break;
                    }
                }
                Console.Clear();
                if(playing == false)
                {
                    break;
                }
            }

        }

        
        
    }
}
