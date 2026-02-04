using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Position
    {
        int _x;
        int _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public int GetPositionX()
        {
            return _x;
        }
        public int GetPositionY()
        {
            return _y;
        }
        public void SetposY(int newY)
        {
            _y = newY;
        }
        public void SetposX(int newX)
        {
            _y = newX;
        }
    }
}
