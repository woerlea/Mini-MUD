using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Backpack
    {
       public List<Item> Content = new List<Item>();


        #region Methoden
        // Anzahl der Gegenstände im Rucksack
        public int GetAmountOfItemsInBackPack()
        {
            int amountOfItems = this.Content.Count;
            return amountOfItems;
        }

        // Damit ein Gegenstand aus der Liste der Gegenstände im Rucksack ausgewählt werden kann
        public Item ChooseItem(string name)
        {
            return Content.Find(Item => Item.Name == name); 
        }

        // Gegenstand aus dem Rucksack entfernen
        public void RemoveItemFromBackpack (Item item)
        {
            this.Content.Remove(item);
        }
       
        #endregion
    }
}
