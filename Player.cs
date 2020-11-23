using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Player
    {
        #region Eigenschaften
        public int Energy { get; set; } 
        public int Money { get; set; }
        public Field CurrentPosition { get; set; }
        public Backpack myBackpack { get; }

        #endregion

        #region
        public Player (Field position)
        {
            this.CurrentPosition = position;
            this.myBackpack = new Backpack();
            this.Money = 100;
            this.Energy = 100;
        }
        #endregion

        #region Methoden
        // Geld verwenden
        public int SpendMoney(int price)
        {
            return Money -= price;
        }

        // Geld verdienen
        public int GetMoney (int earnings)
        {
            return Money += earnings;
        }

        // Energie für die Bewegung verwenden
        public int SpendEnergyToMove()
        {
            Energy -= 10;
            return Energy;
        }

        // Energie beim Essen bekommen
        public int GetEnergy(int kcal)
        {
            Energy += kcal;
            return Energy;
        }

        // Gegenstand in den Rucksack legen
        public void PutIntoBackpack(Item item) 
        {
            this.myBackpack.Content.Add(item); 
        }

        // Gib die aktuelle Position aus
        public Field GetCurrentPosition()
        {
            return CurrentPosition;
        }

        // Wenn das aktuelle Spielfeld das Gefährfeld ist, verwende ein Gegenstand, um sich zu verteidigen
        public void UseWeapontToFight(Item item)
        {
            if (CurrentPosition == (CurrentPosition as DangerousArea))
            {
                (CurrentPosition as IItemConsumer).UseItem(item);
                if ((CurrentPosition as DangerousArea).Defeated == false)
                {
                    SpendMoney(this.Money);
                    Console.WriteLine($"Mit {item.Name} können Sie Banditen nicht abhalten..Ihr ganzes Geld ist weg");
                }
                else
                {
                    Console.WriteLine("Sie sind sehr tapfer");
                }
            }
            else
            {
                Console.WriteLine("Auf diesem Feld ist keine Gefahr");
            }          
        }

        // Verwende ein Gegenstand in gewählte Richtung
        public void UseItemInDirection(string direktion, Item item)
        {
            switch (direktion)
            {
                case "u":
                    if (CurrentPosition.North.IsPassable != false)
                    {
                        Console.WriteLine("Das Feld ist frei zugäglich. Sie müssen auf diesem Feld nichts anwenden.");
                        MoveTo(direktion);
                    }
                    else if (CurrentPosition.North != null && CurrentPosition.North is IItemConsumer)
                    {
                        (CurrentPosition.North as IItemConsumer).UseItem(item);
                        MoveTo(direktion);                       

                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} kann auf dem Feld {CurrentPosition.North.Number} {CurrentPosition.North.Name} nicht angewendet werden");
                    }
                    break;
                case "d":
                    if (CurrentPosition.South.IsPassable != false)
                    {
                        Console.WriteLine("Das Feld ist frei zugäglich. Sie müssen auf diesem Feld nichts anwenden.");
                        MoveTo(direktion);
                    }
                    else if (CurrentPosition.South != null && CurrentPosition.South is IItemConsumer)
                    {
                        (CurrentPosition.South as IItemConsumer).UseItem(item);
                        MoveTo(direktion);
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} kann auf dem Feld {CurrentPosition.South.Number} {CurrentPosition.South.Name} nicht angewendet werden");
                    }
                    break;
                case "l":
                    if (CurrentPosition.West.IsPassable != false)
                    {
                        Console.WriteLine("Das Feld ist frei zugäglich. Sie müssen auf diesem Feld nichts anwenden.");
                        MoveTo(direktion);
                    }
                    else if (CurrentPosition.West != null && CurrentPosition.West is IItemConsumer)
                    {
                        (CurrentPosition.West as IItemConsumer).UseItem(item);
                        MoveTo(direktion);
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} kann auf dem Feld {CurrentPosition.West.Number} {CurrentPosition.West.Name} nicht angewendet werden");
                    }
                    break;
                case "r":
                    if (CurrentPosition.East.IsPassable != false)
                    {
                        Console.WriteLine("Das Feld ist frei zugäglich. Sie müssen auf diesem Feld nichts anwenden.");
                        MoveTo(direktion);
                    }
                    else  if (CurrentPosition.East != null && CurrentPosition.East is IItemConsumer)
                    {
                        (CurrentPosition.East as IItemConsumer).UseItem(item);
                        MoveTo(direktion);
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} kann auf dem Feld {CurrentPosition.East.Number} {CurrentPosition.East.Name} nicht angewendet werden");
                    }
                    break;
                default: Console.WriteLine("Error");
                    break;
            }
        }

        // Je nach Feld, wird Energie geschenkt, Geld abgezogen
        public void ApplyFieldSpecification (Field field)
        {
            // Energie+ in den Bergen
            if (this.CurrentPosition == (field as Mountain)) 
            {
                GetEnergy((field as Mountain).HealthBonus);
            }
            // Eintritt 5 Euro in Museum
            if (this.CurrentPosition == (field as Museum))
            {
                SpendMoney((field as Museum).EntryPrice);
            }
            // Verkäuferlohn auf dem Feld VMilch
            if(this.CurrentPosition == (field as WorkingArea))
            {
               GetMoney((field as WorkingArea).Earnings);
            }
        }

        // Je schwerer ist der Rucksack, desto mehr Energie wird zum Tragen verwendet
        public int SpendEnergyToCarryBag()
        {            
            foreach (Item item in myBackpack.Content)
            {
                this.Energy -= 5;
            }
            return Energy;
        }

        // Spieler bewegt sich in verschiedene Richtungen
        public void MoveTo(string direktion)
        {
            switch (direktion)
            {
                case "u":
                    if (CurrentPosition.North == null)
                    {
                        Console.WriteLine("-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-\n-/-/-/-Achtung!Wand!-\\-\\-\n-\\-\\--\\-\\--\\-\\-\\-\\--\\-\\--\\-\\-");

                    }
                    else
                    {
                        Field fieldToMoveToNorth = (CurrentPosition.North as IEnter).Enter();
                        if (fieldToMoveToNorth != null)
                        {                            
                            this.CurrentPosition = fieldToMoveToNorth;
                            SpendEnergyToMove();
                            SpendEnergyToCarryBag();
                            ApplyFieldSpecification(fieldToMoveToNorth);
                        }

                    }
                    break;
                case "d":
                    if (CurrentPosition.South == null)
                    {
                        Console.WriteLine("-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-\n-/-/-/-Achtung!Wand!-\\-\\-\n-\\-\\--\\-\\--\\-\\-\\-\\--\\-\\--\\-\\-");

                    }
                    else
                    {
                        Field fieldToMoveToSouth = (CurrentPosition.South as IEnter).Enter();
                        if (fieldToMoveToSouth != null)
                        {
                            this.CurrentPosition = fieldToMoveToSouth;
                            SpendEnergyToMove();
                            SpendEnergyToCarryBag();
                            ApplyFieldSpecification(fieldToMoveToSouth);
                        }

                    }
                    break;
                case "r":
                    if (CurrentPosition.East == null)
                    {
                        Console.WriteLine("-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-\n-/-/-/-Achtung!Wand!-\\-\\-\n-\\-\\--\\-\\--\\-\\-\\-\\--\\-\\--\\-\\-");

                    }
                    else
                    {
                        Field fieldToMoveToEast = (CurrentPosition.East as IEnter).Enter();
                        if (fieldToMoveToEast != null)
                        {
                            this.CurrentPosition = fieldToMoveToEast;
                            SpendEnergyToMove();
                            SpendEnergyToCarryBag();
                            ApplyFieldSpecification(fieldToMoveToEast);
                        }

                    }
                    break;
                case "l":
                    if (CurrentPosition.West == null)
                    {
                        Console.WriteLine("-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-\n-/-/-/-Achtung!Wand!-\\-\\-\n-\\-\\--\\-\\--\\-\\-\\-\\--\\-\\--\\-\\-");

                    }
                    else
                    {
                        Field fieldToMoveToWest = (CurrentPosition.West as IEnter).Enter();
                        if (fieldToMoveToWest != null)
                        {
                            this.CurrentPosition = fieldToMoveToWest;
                            SpendEnergyToMove();
                            SpendEnergyToCarryBag();
                            ApplyFieldSpecification(fieldToMoveToWest);
                        }                        
                    }
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
        }          
         #endregion
    }
}
