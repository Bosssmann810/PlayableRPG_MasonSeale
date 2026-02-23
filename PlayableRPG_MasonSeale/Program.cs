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
            Console.CursorVisible = false;
            GameManager _gameManager = new GameManager();
            _gameManager.Start();
            _gameManager.Update();
        }
    }
}
