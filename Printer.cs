﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Printer
    {
        
        public Player Player { get; }

        public Printer (Player player)
        {
            this.Player = player;
        }
        #region Methoden
        // Ausgabe der Info des aktuellen Felds
        public void PrintFieldInfo()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine($"Sie sind auf dem Feld: {Player.CurrentPosition.Number} | {Player.CurrentPosition.Name}\nBeschreibung: {Player.CurrentPosition.Description}");
            if (Player.CurrentPosition.Item != null)
            {
                Console.WriteLine($"Item: {Player.CurrentPosition.Item.Name}");
                if (Player.CurrentPosition.Item.Costs > 0)
                {
                    Console.WriteLine($"Kosten: {Player.CurrentPosition.Item.Costs} Euro");
                }
                if (Player.CurrentPosition.EntryPrice > 0)
                {
                    Console.WriteLine($"Eintritt: {Player.CurrentPosition.EntryPrice} Euro");
                }
            }
            
            Console.WriteLine("\t~Umgebung~");           
            if (Player.CurrentPosition.North != null)
            {
                Console.WriteLine("Im Norden: " + Player.CurrentPosition.North.Name);
            }
            else
            {
                Console.WriteLine("Im Norden: Mauer");
            }
            if (Player.CurrentPosition.South != null)
            {
                Console.WriteLine("Im Süden: " + Player.CurrentPosition.South.Name);
            }
            else
            {
                Console.WriteLine("Im Süden: Mauer");
            }
            if (Player.CurrentPosition.West != null)
            {
                Console.WriteLine("Im Westen: " + Player.CurrentPosition.West.Name);
            }
            else
            {
                Console.WriteLine("Im Westen: Mauer");
            }
            if (Player.CurrentPosition.East != null)
            {
                Console.WriteLine("Im Osten: " + Player.CurrentPosition.East.Name);
            }
            else
            {
                Console.WriteLine("Im Osten: Mauer");
            }
            Console.WriteLine("*****************************");
        }

        // Ausgabe des Rucksackinhalts
        public void PrintBackpackContent()
        {            
            if (Player.myBackpack.GetAmountOfItemsInBackPack()>0)
            {
                Console.WriteLine("Im Rucksack:");
                foreach (Item item in Player.myBackpack.Content)
                {
                    Console.WriteLine($"- {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Im Rucksack\n...ist nichts..");
            }            
        }

        // Ausgabe Player Status
        public void PrintStatus()
        {
            Console.WriteLine("\t\t\t\t\tPlayerstatus\n\t\t\t\t#Energie ... {0,7} Kcal\n\t\t\t\t#Geld ... {1,10} Euro", Player.Energy, Player.Money);
        }

        #endregion
    }
}
