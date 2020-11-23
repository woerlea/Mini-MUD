using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Apple : Item, IEat, IConsume
    {
        public int Kcal { get; set; }
        public Apple(string name, bool ifCollectable) : base(name, ifCollectable)
        {
        }

        public string Consume()
        {
            return Name;
        }

        public int Eat()
        {
            return Kcal;
        }


    }
}
