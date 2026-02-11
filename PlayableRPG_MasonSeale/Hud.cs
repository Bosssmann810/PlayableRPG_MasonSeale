using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Hud
    {
        
        public void HudUpdate(Player player, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"HP: {player.ShowHealth()}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Enemy HP: {enemy.ShowHealth()}");
        }
        

        public void AttackMessage(Character attacker, Character target)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{attacker.ShowName()} attacked {target.ShowName()} for {attacker.GetDamage()} damage!");
        }
        public void HealMessage(Character target)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{target.ShowName()} healed to full!");
        }
    }
}
