using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Water : Field, IEnter, IItemConsumer
    {
        public string ItemNeededToSwimm { get; set; }

        #region Konstruktor
        public Water(int nr, string name, FieldType type) : base(nr, name, type)
        {
            this.Name = name;
            this.Number = nr;
            this.Type = type;
        }
        #endregion

        #region Methoden
        // Methode, um ein Gegenstand anwenden zu können        
        public Field Enter()
        {
            if (IsPassable == true)
            {
                return this;
            }
            else
            {
                Console.WriteLine("~ . ~ . ~ . ~ . ~ . ~ . ~ . ~ .");
                Console.WriteLine("\n~ . ~ .Ohne Schwimmflügel wäre es im Wasser zu gefährlich...");
                Console.WriteLine("~ . ~ . ~ . ~ . ~ . ~ . ~ . ~ .");
                return null;
            }           
        }

        // Ist es der richtige Sportartikel?
        public bool CrossTheWater(SportItem item)
        {
            if (ItemNeededToSwimm == item.Name)
            {
                IsPassable = true;
            }
            else
            {
                IsPassable = false;
            }
            return IsPassable;
        }

        public bool UseItem(Item item)
        {
            if (item is SportItem)
            {
                return CrossTheWater(item as SportItem);
            }
            else
            {
                return false;
            }
           // return false;
        }

       
        #endregion
    }
}
