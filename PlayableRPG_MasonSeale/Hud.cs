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
        bool _enemyAttack = false;
        bool _hatfound = false;
        bool _swordFound = false;
        Character _currentEnemy = new Character(0,0,1,ConsoleColor.Black,"i",1);
        public void HudUpdate(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"HP: {player.ShowHealth()}");
            if (_enemyAttack == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Enemy HP: {_currentEnemy.CurrentHP()}");
            }
            if(_playerAtkMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{player.ShowName()} attacked {_currentEnemy.ShowName()} for {player.GetDamage()} damage!");
                _playerAtkMessage = false;
            }
            if(_hatfound == true)
            {
                Console.WriteLine("You found a hat");
                _hatfound = false;
            }
            if (_swordFound == true)
            {
                Console.WriteLine("You found a Sword");
                _swordFound = false;
            }
            if (_healMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{player.ShowName()} healed to full!");
                _healMessage = false;
            }
            if(_enemyAtkMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{_currentEnemy.ShowName()} attacked {player.ShowName()} for {_currentEnemy.GetDamage()} damage!");
                _enemyAtkMessage = false;
            }
            if(_enemyDeathMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{_currentEnemy.ShowName()} died");
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

        public void HatMessage()
        {
            _hatfound = true;
        }
        public void CurrentEnemyUpdate(Character newchar)
        {
            _currentEnemy = newchar; 
        }
        public void SwordMessage()
        {
            _swordFound = true;
        }
    }
}
