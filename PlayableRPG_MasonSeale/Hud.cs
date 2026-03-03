using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Hud
    {
        bool _AtkMessage = false;
        bool _healMessage = false;
        bool _lavaMessage = false;
        bool _winMessage = false;
        bool _enemyDeathMessage = false;
        bool _enemyAttack = false;
        bool _hatfound = false;
        bool _swordFound = false;
        bool _armorFound = false;
        Character _attacker = new Character(0,0,1,ConsoleColor.Black,"i",1);
        Character _victim = new Character(0, 0, 1, ConsoleColor.Black, "i", 1);
        List<(Character a, Character v)> _attackEvents = new List<(Character, Character)>();
        Character _currentEnemy = new Character(0,0,1,ConsoleColor.Black, "i", 1);
        public void HudUpdate(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"HP: {player.ShowHealth()}");
            if (_enemyAttack == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{_currentEnemy.ShowName()} HP: {_currentEnemy.CurrentHP()}");
                _enemyAttack = false;
            }

            if(_hatfound == true)
            {
                Console.WriteLine("You found a hat");
                _hatfound = false;
            }
            if(_armorFound == true)
            {
                Console.WriteLine("You found some armor");
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
            if(_lavaMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{player.ShowName()} stepped in lava");
                _lavaMessage = false;
            }
            if(_AtkMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach((Character a, Character v) _events in _attackEvents)
                {
                    _attacker = _events.a;
                    _victim = _events.v;
                    Console.WriteLine($"{_attacker.ShowName()} attacked {_victim.ShowName()} for {_attacker.GetDamage()} damage!");
                   
                }
                _attackEvents.Clear();
                _AtkMessage = false;
            }
            if(_enemyDeathMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{_victim.ShowName()} died");
                _enemyDeathMessage = false;
            }
            if(_winMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You Win");
                _winMessage = false;
            }

        }
        

        public void AttackMessage(Character attacker, Character victim)
        {
            _attackEvents.Add((attacker, victim));
            _AtkMessage = true;
        }
        
        public void HealMessage()
        {
            _healMessage = true;
        }

        public void EnemyDeathMessage()
        {
            _enemyDeathMessage = true;
        }

        public void HatMessage()
        {
            _hatfound = true;
        }
        public void ArmorMessage()
        {
            _armorFound = true;
        }
        public void CurrentVictimUpdate(Character newchar)
        {
            _victim = newchar; 
        }
        public void CurrentAttackerUpdate(Character newchar)
        {
            _attacker = newchar;
        }
        public void SwordMessage()
        {
            _swordFound = true;
        }

        public void ChangeCurrentEnemyDisplayed(Character newEnemy)
        {
            _currentEnemy = newEnemy;
            _enemyAttack = true;
        }

        public void LavaMessage()
        {
            _lavaMessage = true;
        }
        public void WinMessage()
        {
            _winMessage = true;
        }
    }
}
