using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Enemy : Character 
    {
        Position _oldpos = new Position(0,0);
        Player _target;
        public Enemy(Player target, int x, int y, int max, ConsoleColor enmColor, string enmIcon, int enmDamage) : base(x,y,max,enmColor,enmIcon,enmDamage)
        {
            _target = target;
        }

        public override void Move()
        {
            _oldpos = new Position(_pos.GetPositionX(), _pos.GetPositionY());
            Random _rng = new Random();
            int _moveChoice = _rng.Next(0, 2);
            if (_moveChoice == 0)
            {
                if (_target.GetXPos() > _pos.GetPositionX())
                {
                    _pos.SetposX(_pos.GetPositionX() + 1);
                }
                if (_target.GetXPos() < _pos.GetPositionX())
                {
                    _pos.SetposX(_pos.GetPositionX() - 1);
                }
            }
            if (_moveChoice == 1)
            {
                if (_target.GetYPos() > _pos.GetPositionY())
                {
                    _pos.SetposY(_pos.GetPositionY() + 1);
                }
                if (_target.GetYPos() < _pos.GetPositionY())
                {
                    _pos.SetposY(_pos.GetPositionY() - 1);
                }
            }
        }

        public override void DenyMovement()
        {
            _pos.SetposX(_oldpos.GetPositionX());
            _pos.SetposY(_oldpos.GetPositionY());
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
        public void RunDeath(Map map)
        {
            _icon = "";
            _oldpos.SetposX(map.FindEndingLine().GetPositionX());
            _oldpos.SetposY(map.FindEndingLine().GetPositionY());
            DenyMovement();
        }
        public override string ShowName()
        {
            return "The Enemy";
        }

    }
}
