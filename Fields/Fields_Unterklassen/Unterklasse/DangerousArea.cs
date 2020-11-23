using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class DangerousArea : FreeEntryFields, IItemConsumer
    {
        public bool Defeated { get; set; }

        #region Konstruktor
        public DangerousArea(int nr, string name, FieldType type) : base(nr, name, type)
        {          

        }
        #endregion

        #region Methoden

        // Wenn der Gegenstand eine Waffe oder ein Apfel ist, kann der Spieler sich verteidigen
        public bool UseItem(Item item)
        {
            if (item is Weapon || item is Apple)
            {
                Defeated = true;
            }
            else
            {
                Defeated = false;
            }
            return Defeated;
        }   

        #endregion
    }
}
