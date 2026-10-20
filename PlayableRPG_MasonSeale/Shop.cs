using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayableRPG_MasonSeale
{
    internal class Shop
    {
        int _itemOneCost;
        int _itemTwoCost;
        int _itemThreeCost;
        Player _player;
        public Shop(Player player)
        {
            
            _player = player;
        }

        public void CheckAmountToBuy()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                if (_player.CheckGold() >= _itemOneCost)
                {
                    _player.Restore();
                    _itemOneCost += 1;
                }
            }
            if (key.Key == ConsoleKey.D2)
            {
                if (_player.CheckGold() >= _itemTwoCost)
                {
                    _player.Restore();
                    _itemTwoCost += 1;
                }
            }
            if (key.Key == ConsoleKey.D3)
            {
                if (_player.CheckGold() >= _itemThreeCost)
                {
                    _player.Restore();
                    _itemThreeCost += 1;
                }
            }

                
        }
    }
}
