using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    //[Serializable] -- 
    internal class Settings
    {
        public ConsoleColor playerColor { get; set; } = ConsoleColor.Blue;
        public int playerDamage { get; set; } = 1;
        public int playerHealth { get; set; } = 10;
        public string playerIcon { get; set; } = "1";
        public int swordDamage { get; set; } = 5;
        public int armorDefense { get; set; } = 1;

        public ConsoleColor enemyColor { get; set; } = ConsoleColor.Red;
        public int enemyDamage { get; set; } = 2;
        public int enemyHealth { get; set; } = 10;
        public string enemyIcon { get; set; } = "i";
        public ConsoleColor fastEnemyColor { get; set; } = ConsoleColor.Magenta;
        public int fastEnemyDamage { get; set; } = 1;
        public int fastEnemyHealth { get; set; } = 5;
        public string fastEnemyIcon { get; set; } = "x";
        public ConsoleColor beefyEnemyColor { get; set; } = ConsoleColor.DarkRed;
        public int beefyEnemyDamage { get; set; } = 2;
        public int beefyEnemyHealth { get; set; } = 20;
        public string beefyEnemyIcon { get; set; } = "&";

        public ConsoleColor fredColor { get; set; } = ConsoleColor.DarkRed;
    }
}

