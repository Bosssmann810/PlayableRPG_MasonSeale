using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class FastEnemy : Character
    {
        Position _oldpos = new Position(0, 0);
        Player _target;
        public FastEnemy(Player target, int x, int y, int max, ConsoleColor enmColor, string enmIcon, int enmDamage) : base(x, y, max, enmColor, enmIcon, enmDamage)
        {
            _target = target;
        }
        
        //this enemy will never fail a movement and will always head towards the player moving diagonally if its faster.
        public override void Move()
        {
            _oldpos = new Position(_pos.GetPositionX(), _pos.GetPositionY());
            
            
                if (_target.GetXPos() > _pos.GetPositionX())
                {
                    _pos.SetposX(_pos.GetPositionX() + 1);
                }
                if (_target.GetXPos() < _pos.GetPositionX())
                {
                    _pos.SetposX(_pos.GetPositionX() - 1);
                }
            
            
            
                if (_target.GetYPos() > _pos.GetPositionY())
                {
                    _pos.SetposY(_pos.GetPositionY() + 1);
                }
                if (_target.GetYPos() < _pos.GetPositionY())
                {
                    _pos.SetposY(_pos.GetPositionY() - 1);
                
            }
        }

        public override void DenyMovement()
        {
            _pos.SetposX(_oldpos.GetPositionX());
            _pos.SetposY(_oldpos.GetPositionY());
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

        public override void Update()
        {
            base.Update();
        }
        public bool AliveChecker()
        {
            return _health.AliveCheck();
        }
        public int ShowHealth()
        {
            return _health.GetCurrentHP();
        }
        public void RunDeath()
        {
            _icon = "";
            _oldpos.SetposX(20);
            _oldpos.SetposY(20);
            DenyMovement();
        }
        public override string ShowName()
        {
            return "The Fast Enemy";
        }

    }
}
