using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PlayableRPG_MasonSeale
{
    internal class Health
    {
        int _maxHP;
        int _currentHP;
        public Health(int max)
        {
            _maxHP = max;
            _currentHP = max;
        }

        public void TakeDamage(int damage)
        {
            _currentHP -= damage; 
        }

        public void ResetHP()
        {
            _maxHP = _currentHP;
        }
        public int GetCurrentHP()
        {
            return _currentHP;
        }
    }
}
