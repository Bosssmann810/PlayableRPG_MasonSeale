using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PlayableRPG_MasonSeale
{
    //currently a work in progress
    internal class bomb
    {
        Position _pos;
        bool _held = false;
        bool _active = false;
        bool _blownUp = false;
        int _timeLeft = 5;
        List<(int, int)> _explsoionZone = new List<(int, int)>();
        public bomb(Map map)
        {
            _pos = new Position(map.BombHat().Item1, map.BombHat().Item2);
        }
        
        public void Update(Player player)
        {
            if(_blownUp == true)
            {
                _explsoionZone.Clear();
                return;
            }
            if (_held == true)
            {
                Console.SetCursorPosition(player.GetXPos(), player.GetYPos() -1);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write('*');
            }
            if(_held == false)
            {
                Console.SetCursorPosition(_pos.GetPositionX(), _pos.GetPositionY());
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if(_timeLeft == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write('*');
            }
            if(_active == true)
            {
                DecreaseFuse();
            }
        }

        public void DecreaseFuse()
        {
            if(_active == false)
            {
                return;
            }
            else
            {
                if(_timeLeft > 0)
                {
                    _timeLeft -= 1;
                }
                if(_timeLeft <= 0)
                {
                    Detionate();
                }
            }
        }
        public void DropBomb(Player player)
        {
            _pos = new Position(player.GetXPos(), player.GetYPos());
            _active = true;
            _held = false;
        }
        public void Detionate()
        {
            _blownUp = true;
            _active = false;
            _explsoionZone.Add((_pos.GetPositionX() + 1, _pos.GetPositionY() + 1));
            _explsoionZone.Add((_pos.GetPositionX() , _pos.GetPositionY() + 1));
            _explsoionZone.Add((_pos.GetPositionX() + 1, _pos.GetPositionY()));
            _explsoionZone.Add((_pos.GetPositionX(), _pos.GetPositionY()));
            _explsoionZone.Add((_pos.GetPositionX() - 1, _pos.GetPositionY() + 1));
            _explsoionZone.Add((_pos.GetPositionX() + 1, _pos.GetPositionY() - 1));
            _explsoionZone.Add((_pos.GetPositionX() - 1, _pos.GetPositionY() - 1));
            _explsoionZone.Add((_pos.GetPositionX(), _pos.GetPositionY() - 1));
            _explsoionZone.Add((_pos.GetPositionX() - 1, _pos.GetPositionY()));

            foreach((int,int) spot in _explsoionZone)
            {
                Console.SetCursorPosition(spot.Item1, spot.Item2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
            }

        }
        public List<(int,int)> GetExplosionZone()
        {
            return _explsoionZone;
        }
        public void PickedUp(Player player)
        {
            _held = true;

        }
    }
}
