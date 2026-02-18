using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Hud
    {
        bool _playerAtkMessage = false;
        bool _healMessage = false;
        bool _enemyAtkMessage = false;
        bool _enemyDeathMessage = false;
        public void HudUpdate(Player player, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"HP: {player.ShowHealth()}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Enemy HP: {enemy.ShowHealth()}");
            if(_playerAtkMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{player.ShowName()} attacked {enemy.ShowName()} for {player.GetDamage()} damage!");
                _playerAtkMessage = false;
            }
            if(_healMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{player.ShowName()} healed to full!");
                _healMessage = false;
            }
            if(_enemyAtkMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{enemy.ShowName()} attacked {player.ShowName()} for {enemy.GetDamage()} damage!");
                _enemyAtkMessage = false;
            }
            if(_enemyDeathMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{enemy.ShowName()} died");
                _enemyDeathMessage = false;
            }
        }
        

        public void PlayerAttackMessage()
        {
            _playerAtkMessage = true;

        }
        public void HealMessage()
        {
            _healMessage = true;
        }
        public void EnemyAttackMessage()
        {
            _enemyAtkMessage = true;
        }
        public void EnemyDeathMessage()
        {
            _enemyDeathMessage = true;
        }

        public void HatMessage(Map pos)
        {
            Console.SetCursorPosition(pos.FindEndingLine().GetPositionX(), pos.FindEndingLine().GetPositionY());
            Console.WriteLine();
            Console.WriteLine("You found a hat");
        }
    }
}
