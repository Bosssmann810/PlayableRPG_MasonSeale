using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    //the referee
    internal class MovementChecker
    {

        //this is called after every time the player moves to detect any attacks made
        public void PlayerAttackDetection(Player player, Enemy enemy)
        {
            //if the player overlaps with an enemy
            if (player.GetPlayerY() == enemy.GetEnemyY() && player.GetPlayerX() == enemy.GetEnemyX())
            {
                //don't allow player to move
                player.DenyMovement();
                //and damage the enemy
                enemy.Pain(player.GetDamage());
            }
            //otherwise it dose nothing
        }
    }
}
