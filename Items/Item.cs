using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Item
    {
        #region Eigenschaften
        public string Name { get; set; }
        public int Costs { get; set; } = 0;
        public bool Collectable { get; set; }
        #endregion

        #region Konstruktor
        public Item (string name, bool ifCollectable)
        {
            this.Name = name;
            this.Collectable = ifCollectable;
        }
        #endregion
    }
}
