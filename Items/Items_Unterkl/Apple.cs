using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Apple : Item, IEat
    {
        public int Kcal { get; set; }
        public Apple(string name, bool ifCollectable) : base(name, ifCollectable)
        {
        }

        public int Eat()
        {
            return Kcal;
        }


    }
}
