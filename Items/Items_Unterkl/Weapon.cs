using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Weapon : Item, IConsume
    {
        public Weapon(string name, bool ifCollectable) : base(name, ifCollectable)
        {
        }

        #region Methoden
        public string Consume()
        {
            return Name; 
        }
        #endregion
    }
}
