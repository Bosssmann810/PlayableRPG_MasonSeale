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
            if (_target.GetPlayerX() > _pos.GetPositionX())
            {
                _pos.SetposX(_pos.GetPositionX()+1);
            }
            if (_target.GetPlayerX() < _pos.GetPositionX())
            {
                _pos.SetposX(_pos.GetPositionX() - 1);
            }
            if(_target.GetPlayerY() > _pos.GetPositionY())
            {
                _pos.SetposY(_pos.GetPositionY() + 1);
            }
            if (_target.GetPlayerY() < _pos.GetPositionY())
            {
                _pos.SetposY(_pos.GetPositionY() - 1);
            }
        }

        public void DenyMovement()
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
