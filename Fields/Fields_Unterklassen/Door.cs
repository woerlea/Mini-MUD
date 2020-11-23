using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Door : Field, IEnter, IItemConsumer
    {
        public string MyPassword { get; set; }

        #region Konstruktor
        public Door (int nr, string name, FieldType type, string password) : base(nr, name, type)
        {
            this.MyPassword = password;
        }

        #endregion

        #region Methoden
        // Prüfe, ob die Tür offen oder zu ist       
        public Field Enter()
        {
            if (IsPassable != true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=====================\n==Du brauchst einen passenden Schlüssel==\n=====================");
                Console.ResetColor();
               return null;
            }
            return this; 
        }

        // Prüfe, ob der Schlüssel zur Tür passt
        public bool UnlockDoor(Key key)
        {
            if (MyPassword == key.Passwort)
            {
                IsPassable = true;
            }
            else
            {
                IsPassable = false;
                Console.WriteLine("Falscher Schlüssel");
            }
            return IsPassable;
        }

        // Prüfe, ob der Gegenstand ein Schlüssel ist
        public bool UseItem(Item item)
        {
            if (item is Key)
            {
               return UnlockDoor(item as Key);
            }
            else
            {
                return false;
            }            
        }

       



        #endregion
    }
}
