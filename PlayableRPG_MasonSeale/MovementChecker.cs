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
                hud.PlayerAttackMessage();
            }
            //otherwise it dose nothing (it comes in, checks to see if everyone is fallowing the rules and says "carry on"
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
        public void PlayerHatFound(Player player, Map map, Hud hud)
        {
            if (map.FindHat() == (player.GetXPos(), player.GetYPos()))
            {
                player.HatCollected();
                map.CollectHat();
                hud.HatMessage(map);
            }
        }
        public void PlayerSwordFound(Player player, Map map)
        {
            if (map.FindSword() == (player.GetXPos(), player.GetYPos()))
            {
                player.SwordCollected();
                map.CollectSword();
                player.ChangeDamage(2);
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
