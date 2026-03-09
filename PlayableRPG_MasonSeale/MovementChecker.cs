using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    //the referee
    internal class MovementChecker
    {
        bool _armorfound = false;
        bool _hatfound = false;
        bool _swordFound = false;
        //this is called after every time something moves to detect any attacks made
        public void AttackDetection(Character attacker, Character victim, Hud hud)
        {
            //if the attacker overlaps with an victim
            if (attacker.GetYPos() == victim.GetYPos() && attacker.GetXPos() == victim.GetXPos())
            {
                //don't allow attacker to move
                attacker.DenyMovement();
                //and damage the victim
                victim.Pain(attacker.GetDamage());
                //tell hud to display a message
                hud.AttackMessage(attacker, victim);
            }
            //otherwise it dose nothing (it comes in, checks to see if everyone is fallowing the rules and says "carry on"
        }

        public void EnemyAttackMessageDetection(Character enemy, Player player, Hud hud)
        {
            if(enemy.GetYPos() == player.GetYPos() && enemy.GetXPos() == player.GetXPos())
            {
                hud.ChangeCurrentEnemyDisplayed(enemy);
            }

        }

        public void LavaCheck(Character entity, Map map, Hud hud)
        {
            if(map.GetLavaSpots().Contains((entity.GetXPos(), entity.GetYPos())))
            {
                entity.PenDamage(1);
                hud.LavaMessage();
            }
        }
        public void BoundCheck(Character entity, Map map)
        {
            if(map.GetListNoGo().Contains((entity.GetXPos(), entity.GetYPos())))
            {
                entity.DenyMovement();
            }
        }
        public void PlayerHealCheck(Player player, Map map, Hud hud)
        {
            if (map.GetHealthSpots().Contains((player.GetXPos(), player.GetYPos())))
            {
                player.Restore();
                hud.HealMessage();
            }
        }

        public bool PlayerGoldCheck(Player player, Map map, Hud hud)
        {
            if (map.GetGoldSpots().Contains((player.GetXPos(), player.GetYPos())))
            {
                hud.WinMessage();
                return true;
            }
            return false;
        }
        public void PlayerHatFound(Player player, Map map, Hud hud)
        {
            if (map.FindHat() == (player.GetXPos(), player.GetYPos()))
            {
                if(_hatfound == true)
                {
                    return;
                }
                player.DenyMovement();
                player.HatCollected();
                map.CollectHat();
                hud.HatMessage();
                _hatfound = true;
            }
        }
        public bool  LoadMapCheck(Player player, Map currentmap)
        {
            if(currentmap.GetMapLoadZone() == (player.GetXPos(), player.GetYPos()))
            {
                return true;

            }
            return false;
        }
        public void PlayerArmorFound(Player player, Map map, Hud hud)
        {
            if (map.FindArmor() == (player.GetXPos(), player.GetYPos()))
            {
                if (_armorfound == true)
                {
                    return;
                }
                player.DenyMovement();
                player.ChangeColor(ConsoleColor.Cyan);
                player.ChangeDefense(1);
                map.CollectArmor();
                hud.ArmorMessage();
                _armorfound = true;
            }
        }
        public void PlayerSwordFound(Player player, Map map, Hud hud)
        {
            if (map.FindSword() == (player.GetXPos(), player.GetYPos()))
            {
                if(_swordFound == true)
                {
                    return;
                }
                player.DenyMovement();
                player.SwordCollected();
                map.CollectSword();
                player.ChangeDamage(2);
                hud.SwordMessage();
                _swordFound = true;
            }
        }
        public void EnemyBumping(Character enemyA, Character enemyB)
        {
            if(enemyA.GetXPos() == enemyB.GetXPos() && enemyA.GetYPos() == enemyB.GetYPos())
            {
                enemyA.DenyMovement();
            }

        }
    }
}
