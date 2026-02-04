using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Enemy : Character 
    {
        Player _target;
        public Enemy(Player target, int x, int y, int max, ConsoleColor enmColor, string enmIcon, int enmDamage) : base(x,y,max,enmColor,enmIcon,enmDamage)
        {
            _target = target;
        }

        public override void Move()
        {

        }
        //returns enemy x position
        public int GetEnemyX()
        {
            return _pos.GetPositionX();
        }
        //returns enemy y position
        public int GetEnemyY()
        {
            return _pos.GetPositionY();
        }
        public void Pain(int painAmount)
        {
            _health.TakeDamage(painAmount);
        }
        public override void Update()
        {
            base.Update();
        } 
    }
}
