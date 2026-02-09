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
            //otherwise it dose nothing (it comes in, checks to see if everyone is fallowing the rules and says "carry on"
        }
        //this is called after the enemy moves
        public void EnemyAttackDetection(Player player, Enemy enemy)
        {
            //if the player overlaps with an enemy
            if (player.GetPlayerY() == enemy.GetEnemyY() && player.GetPlayerX() == enemy.GetEnemyX())
            {
                //don't allow player to move
                enemy.DenyMovement();
                //and damage the enemy
                player.Pain(enemy.GetDamage());
            }
            //otherwise it dose nothing (it comes in, checks to see if everyone is fallowing the rules and says "carry on"
        }
        public void PlayerBoundCheck(Player player, Map map)
        {
            if(map.GetList().Contains((player.GetPlayerX(), player.GetPlayerY())))
            {
                player.DenyMovement();
            }
        }
        public void EnemyBoundCheck(Enemy enemy, Map map)
        {
            if(map.GetList().Contains((enemy.GetEnemyX(), enemy.GetEnemyY())))
            {
                enemy.DenyMovement();
            }
        }
    }
}
