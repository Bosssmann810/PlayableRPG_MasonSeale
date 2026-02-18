using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Character
    {
        protected Health _health;
        protected Position _pos;
        protected ConsoleColor _color;
        protected string _icon;
        protected int _damage;
        
        public virtual void Move()
        {

        }
        public Character(int startingPosX,int startingPosY, int maxHealth, ConsoleColor color, string icon, int damage)
        {
            _health = new Health(maxHealth);
            _pos = new Position(x: startingPosX, y: startingPosY);
            _damage = damage;
            _color = color;
            _icon = icon;
        }
        //displays the character at the current position.
        public virtual void Update()
        {
            Console.SetCursorPosition(_pos.GetPositionX(), _pos.GetPositionY());
            Console.ForegroundColor = _color;
            Console.Write(_icon);

        }
        public int GetDamage()
        {
            return _damage;
        }
        public virtual string ShowName()
        {
            return "You";
        }
        //placeholder function
        public virtual void DenyMovement()
        {
            
        }
        //returns x pos
        public int GetYPos()
        {
            return _pos.GetPositionY();
        }
        //returns y pos
        public int GetXPos()
        {
            return _pos.GetPositionX();
        }
        //deals damage
        public void Pain(int painAmount)
        {
            _health.TakeDamage(painAmount);
        }

        public void ChangeDamage(int newDamage)
        {
            _damage = newDamage;
        }

    }
}
