using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{ 
    class Food : Item, IEat
    {
        public int Kcal { get; set; }

        public Food(string name, bool ifCollectable, int kcal) : base(name, ifCollectable)
        {
            this.Kcal = kcal;
        }

        public int Eat()
        {
            return Kcal;
        }
    }
}
