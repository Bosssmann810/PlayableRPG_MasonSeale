using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Player : Character
    {
        Position _oldPos;
        bool _foundHat = false;
        int _facingDirection;
        bool _foundSword = false;

        public Player(int damage, ConsoleColor color, string icon, int startingXPos, int startingYPos, int maxHP) : base(startingXPos, startingYPos, maxHP, color,icon,damage)
        {
            
        }
        //called whenever we need to move
        public override void Move()
        {
            //this will keep the previous position in case a reset is needed. 
            _oldPos = new Position(_pos.GetPositionX(), _pos.GetPositionY());

            ConsoleKeyInfo _playerInput = Console.ReadKey(true);

            //reads the players key press and moves accordingly
            if(_playerInput.Key == ConsoleKey.W)
            {
                _pos.SetposY(_pos.GetPositionY() - 1);
            }
            if (_playerInput.Key == ConsoleKey.S)
            {
                _pos.SetposY(_pos.GetPositionY() + 1);

            }
            if(_playerInput.Key == ConsoleKey.A)
            {
                _pos.SetposX(_pos.GetPositionX() - 1);
                _facingDirection = -1;
            }
            if(_playerInput.Key == ConsoleKey.D)
            {
                _pos.SetposX(_pos.GetPositionX() + 1);
                _facingDirection = 1;
            }
            //attack overlap is handled by MovementChecker
        }
        //returns the players x position


        //returns the players Y position

        //this is called when I want to prevent the player from going somewhere, it resets the players position back to _oldPos, which was declaired in movement;
        public override void DenyMovement()
        {
            _pos.SetposX(_oldPos.GetPositionX());
            _pos.SetposY(_oldPos.GetPositionY());
        }
        //this function will be in anything that needs to be updated, and they will all be placed into the update method in the main program.
        public override void Update()
        {
            Console.SetCursorPosition(_pos.GetPositionX(), _pos.GetPositionY());
            Console.ForegroundColor = _color;
            Console.Write(_icon);
            //this only works if the player has found the hat.
            if (_foundHat)
            {
                Console.SetCursorPosition(_pos.GetPositionX(), _pos.GetPositionY() - 1);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write('*');
            }
            if (_foundSword)
            {
                Console.SetCursorPosition(_pos.GetPositionX() + _facingDirection, _pos.GetPositionY());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("!");
            }
        }
        public Position PositionCheck()
        {
            return _pos;
        }
        public int ShowHealth()
        {
            return _health.GetCurrentHP();
        }
        //this function heals the player to full
        public void Restore()
        {
            _health.ResetHP();
        }
        //this method checks to see if the player is still alive. 
        public bool AliveChecker()
        {
            return _health.AliveCheck();
        }
        //displays the hat when called
        public void HatCollected()
        {
            _foundHat = true;
        }
        public void SwordCollected()
        {
            _foundSword = true;
        }
        public bool HatMessage()
        {
            return _foundHat;
        }
        public bool SwordMessage()
        {
            return _foundSword;
        }
        public override string ShowName()
        {
            return "You";
        }

    }
}
