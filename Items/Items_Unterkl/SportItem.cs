using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class SportItem : Item, IConsume
    {        
        public SportItem(string name, bool ifCollectable) : base(name, ifCollectable)
        {
        }

        public string Consume()
        {
            return Name;
        }
    }
}
