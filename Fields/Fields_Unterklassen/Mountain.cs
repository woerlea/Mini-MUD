using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Mountain : Field, IEnter, IItemConsumer
    {
        public int HealthBonus { get; } = 15;
        public string ItemNeededForMountain { get; set; }

        #region Konstruktor
        public Mountain (int nr, string name, FieldType type) : base(nr, name, type)
        {
            this.Name = name;
            this.Number = nr;
            this.Type = type;
        }
        #endregion

        #region Methoden
        // Prüfe, ob das Feld frei zugänglich ist
        public Field Enter()
        {
            if (IsPassable == true)
            {
                return this;
            }
            else
            {
                Console.WriteLine("/\\/\\/\\/\\/\\/\\/\\/\\");
                Console.WriteLine("/\\/\\Ohne Bergausrüstung geht man nicht in die Berge...");
                Console.WriteLine("/\\/\\/\\/\\/\\/\\/\\/\\");
                return null;
            }
            
        }

        // Ist es ein Sportartikel, was der Spieler verwenden will?
        public bool UseItem(Item item)
        {
            if (item is SportItem)
            {
                return ConquireMountain(item as SportItem);
            }
            return false;
        }

        // Ist es der richtige Sportartikel?
        public bool ConquireMountain(SportItem item)
        {
            if (ItemNeededForMountain == item.Name)
            {
                IsPassable = true;
            }
            else
            {
                IsPassable = false;
            }
            return IsPassable;
        }        
        #endregion

    }
}
