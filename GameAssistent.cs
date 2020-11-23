using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class GameAssistent
    {
        #region Eigenschaften
        public Player MyPlayer { get; }
        public Printer myPrinter { get; }
        #endregion

        #region Konstruktor
        public GameAssistent(Player player)
        {
            MyPlayer = player;
            myPrinter = new Printer(MyPlayer);
        }
        #endregion

        // Wie soll Universalgegenstand (Äpfel) angewendet werden?
        public void UseUniversalItem (Item item)
        {
            Console.WriteLine($"Wollen Sie {item.Name} [e]ssen oder [a]nwenden?");
            string myUsage = Console.ReadLine();
            switch (myUsage)
            {
                case "e":                    
                    MyPlayer.GetEnergy((item as Apple).Eat());
                    MyPlayer.myBackpack.RemoveItemFromBackpack(item);
                    Console.WriteLine($"Mmm.. {item.Name} war aber lecker!");
                    break;
                case "a":
                    MyPlayer.UseWeapontToFight(item);
                    break;
                default:
                    break;
            }
        }

        // Frage, welche Richtung der Gegenstand angewendet wird
        public void GiveDirektionToUseTheItem(Item item)
        {
            Console.WriteLine($"Welche Richtung soll {item.Name} angewendet werden: [u]p, [d]own, [l]eft, [r]ight?");
            string useInDirektion = Console.ReadLine();
            MyPlayer.UseItemInDirection(useInDirektion, item);
        }

        // Frage, ob der Spieler ein Gegenstand aus dem Rucksack verwenden möchte
        public void AskIfAnItemShouldBeUsed()
        {
            // Wenn nur ein Gegenstand im Rucksack ist
            myPrinter.PrintBackpackContent();
            if (MyPlayer.myBackpack.GetAmountOfItemsInBackPack() > 0)
            {
                Console.WriteLine("Wollen Sie ein Gegenstand aus dem Rucksack verwenden: [y]es, [n]o?");
                string useItem = Console.ReadLine();
                if (useItem == "y") // Gegenstand verwenden
                {
                    // wenn nur 1 Gegenstand im Rucksack liegt
                    if (MyPlayer.myBackpack.GetAmountOfItemsInBackPack() == 1)
                    {
                        var soloItem = MyPlayer.myBackpack.Content[0];
                        if (soloItem is SportItem)
                        {                            
                            GiveDirektionToUseTheItem(soloItem);
                            myPrinter.PrintFieldInfo();
                        }
                        if (soloItem is Food)
                        {
                            MyPlayer.GetEnergy((soloItem as Food).Eat());
                            MyPlayer.myBackpack.RemoveItemFromBackpack(soloItem);
                            Console.WriteLine($"Mmm.. {soloItem.Name} war aber lecker!");
                            MyPlayer.myBackpack.RemoveItemFromBackpack(soloItem);
                        }
                        if (soloItem is Apple)
                        {
                            UseUniversalItem(soloItem);
                        }
                        if (soloItem is Weapon)
                        {
                            MyPlayer.UseWeapontToFight(soloItem);
                        }

                    }
                    // Wenn mehrere Gegenstände im Rucksack sind
                    else
                    {
                        Console.WriteLine("Wählen Sie den Gegenstand");
                        string item = Console.ReadLine();
                        Item chosenItem = MyPlayer.myBackpack.ChooseItem(item);
                        if (chosenItem is Weapon)
                        {
                            MyPlayer.UseWeapontToFight(chosenItem);
                        }
                        if (chosenItem is Food)
                        {
                            MyPlayer.GetEnergy((chosenItem as Food).Eat());
                            MyPlayer.myBackpack.RemoveItemFromBackpack(chosenItem);
                            Console.WriteLine($"Mmm.. {chosenItem.Name} war aber lecker!");
                        }
                        if (chosenItem is Apple)
                        {
                            UseUniversalItem(chosenItem);
                        }
                        if (chosenItem is Key)
                        {
                            GiveDirektionToUseTheItem(chosenItem);
                            myPrinter.PrintFieldInfo();
                        }
                        if (chosenItem is SportItem)
                        {
                            GiveDirektionToUseTheItem(chosenItem);
                            myPrinter.PrintFieldInfo();
                        }
                    }
                }
            }            
        }

        // Frage, ob ein Gegenstand gekauft werden soll
        public void IfTheItemShouldBeBought()
        {
            Console.WriteLine($"Was möchten Sie als nächstes tun?\n[1] - {MyPlayer.CurrentPosition.Item.Name} kaufen; \n[2] - nichts kaufen; \n[3] - Rucksackinhalt überprüfen");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": // Wenn der Player Geld genug hat
                    if (MyPlayer.Money >= MyPlayer.CurrentPosition.Item.Costs)
                    {
                        MyPlayer.SpendMoney(MyPlayer.CurrentPosition.Item.Costs);
                        MyPlayer.PutIntoBackpack(MyPlayer.CurrentPosition.Item);
                        myPrinter.PrintBackpackContent();
                    }
                    else
                    {
                        // Zu wenig Geld
                        Console.WriteLine($"Zu wenig Geld um {MyPlayer.CurrentPosition.Item.Name} zu kaufen");
                    }

                    break;
                case "2":
                    // weiter laufen
                    break;
                case "3":
                    // Rucksackinhalt anschauen
                    myPrinter.PrintBackpackContent();
                    if (MyPlayer.myBackpack.GetAmountOfItemsInBackPack() > 0)
                    {
                        AskIfAnItemShouldBeUsed();
                    }

                    break;
                default: Console.WriteLine("Error"); break;
            }
        }

        // Beschreibe Spielbedingungen
        public void Play()
        {
            Console.WriteLine("Drucken Sie <Enter>, um das Spiel zu starten");
            string answer = Console.ReadLine();
            myPrinter.PrintStatus();
            myPrinter.PrintFieldInfo();
            
            while (answer == "")
            {
                Console.WriteLine("Möchten Sie jetzt: [1]-laufen [2]-Rucksack überprüfen [3]-Status anschauen?");
                string goOrUse = Console.ReadLine();
                switch (goOrUse)
                {
                    case "1":
                        Console.WriteLine("Wohin möchten Sie gehen: [u]p, [d]own, [l]inks, [r]echts?");
                        string myDirektion = Console.ReadLine();
                        MyPlayer.MoveTo(myDirektion);
                        myPrinter.PrintFieldInfo();

                        // Wenn das Item gesammelt werden kann
                        if (MyPlayer.CurrentPosition.Item != null && MyPlayer.CurrentPosition.Item.Collectable == true)
                        {
                            // Wenn das Item kostet etw
                            if (MyPlayer.CurrentPosition.Item.Costs > 0)
                            {
                                Console.WriteLine($"Was möchten Sie als nächstes tun?\n[1] - {MyPlayer.CurrentPosition.Item.Name} kaufen; \n[2] - nichts kaufen; \n[3] - Rucksackinhalt überprüfen");
                                string choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1": // Wenn der Player Geld genug hat
                                        if (MyPlayer.Money >= MyPlayer.CurrentPosition.Item.Costs)
                                        {
                                            MyPlayer.SpendMoney(MyPlayer.CurrentPosition.Item.Costs);
                                            MyPlayer.PutIntoBackpack(MyPlayer.CurrentPosition.Item);
                                            myPrinter.PrintBackpackContent();
                                        }
                                        else
                                        {
                                            // Zu wenig Geld
                                            Console.WriteLine($"Zu wenig Geld um {MyPlayer.CurrentPosition.Item.Name} zu kaufen");
                                        }

                                        break;
                                    case "2":
                                        // weiter laufen
                                        break;
                                    case "3":
                                        // Rucksackinhalt anschauen
                                        myPrinter.PrintBackpackContent();
                                        if (MyPlayer.myBackpack.GetAmountOfItemsInBackPack() > 0)
                                        {
                                            AskIfAnItemShouldBeUsed();
                                        }

                                        break;
                                    default: Console.WriteLine("Error"); break;
                                }
                            }
                            // Item ist gratis
                            else
                            {
                                Console.WriteLine($"Wollen Sie : {MyPlayer.CurrentPosition.Item.Name} in den Rücksack legen?: [y]es, [n]o ?");
                                string getItem = Console.ReadLine();
                                if (getItem == "y")
                                {
                                    // Wenn das Item ein Schlüssel ist
                                    if (MyPlayer.CurrentPosition.Item.Name == "Schlüssel (rot)" || MyPlayer.CurrentPosition.Item.Name == "Schlüssel (weiss)")
                                    {
                                        MyPlayer.PutIntoBackpack(MyPlayer.CurrentPosition.Item);
                                        MyPlayer.CurrentPosition.Item = null;
                                        myPrinter.PrintBackpackContent();
                                    }
                                    else
                                    {
                                        // Jeder andere Gegenstand ausser Schlüssel kann wieder auf dem jeweiligen Feld gekauft/gegessen/gekriegt werden
                                        MyPlayer.PutIntoBackpack(MyPlayer.CurrentPosition.Item);
                                        myPrinter.PrintBackpackContent();
                                    }
                                }
                            }
                        }
                        // Wenn das Item nur sofort gegessen werden kann
                        else if (MyPlayer.CurrentPosition.Item != null && MyPlayer.CurrentPosition.Item.Collectable != true)
                        {
                            if (MyPlayer.CurrentPosition.Item.Costs != 0)
                            {
                                Console.WriteLine($"Wollen Sie {MyPlayer.CurrentPosition.Item.Name} kaufen: [y]es, [n]o?");
                                string buyOrNot = Console.ReadLine();
                                switch (buyOrNot)
                                {
                                    case "y":
                                        // wenn der Spieler genug Geld hat
                                        if (MyPlayer.Money >= MyPlayer.CurrentPosition.Item.Costs)
                                        {
                                            MyPlayer.SpendMoney(MyPlayer.CurrentPosition.Item.Costs);
                                            MyPlayer.GetEnergy((MyPlayer.CurrentPosition.Item as Food).Eat());
                                            Console.WriteLine($"Mmm.. {MyPlayer.CurrentPosition.Item.Name} war aber lecker!");                                           
                                        }
                                        else
                                        {
                                            // Zu wenig Geld
                                            Console.WriteLine($"Zu wenig Geld um {MyPlayer.CurrentPosition.Item.Name} zu kaufen");
                                        }
                                        break;
                                    case "n":
                                        // weiter laufen
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                // Gratisbier
                                MyPlayer.GetEnergy((MyPlayer.CurrentPosition.Item as Food).Eat());
                                Console.WriteLine($"Mmm.. {MyPlayer.CurrentPosition.Item.Name} war aber lecker!");
                            }                           

                        }
                        if (MyPlayer.CurrentPosition is DangerousArea)
                        {
                            Console.WriteLine("Wollen Sie sich verteidigen: [y]es [n]o?");
                            string wantToFight = Console.ReadLine();
                            if (wantToFight == "y")
                            {
                                Console.WriteLine("Wählen Sie den Gegenstand");
                                string item = Console.ReadLine();
                                Item chosenItem = MyPlayer.myBackpack.ChooseItem(item);
                                MyPlayer.UseWeapontToFight(chosenItem);
                            }
                            else
                            {
                                Console.WriteLine("Pech gehabt..Ihr ganzes Geld ist weg..Sie wurden ausgeraubt");
                                MyPlayer.Money = 0;
                            }
                        }
                        break;
                    case "2":
                        AskIfAnItemShouldBeUsed();
                        break;
                    case "3":
                        myPrinter.PrintStatus();
                        break;
                    default:
                        Console.WriteLine("Falsche Eingabe");
                        break;
                }
                
                // Derfiniere das Spielende
                if (MyPlayer.CurrentPosition.Type == Field.FieldType.FINISH)
                {
                    Console.WriteLine("**~Game over~**\nGreat job!");
                    break;
                }
                else if (MyPlayer.Energy <= 0)
                {
                    Console.WriteLine($"**~Game over~**\nDer Player ist erschöpft... Energiestand: {MyPlayer.Energy}");
                    break;
                }                
            }          
        }
    }      
}
