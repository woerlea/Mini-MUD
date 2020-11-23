using System;

namespace _18_Mini_MUD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Erstelle Felder inkl. Beschreibung
            Field start = new FreeEntryFields(0, "Start", Field.FieldType.START);
            start.Description = "Startfeld";
            Field markt = new FreeEntryFields(1, "Dornbirner Markt", Field.FieldType.NORMAL);
            markt.Description = "Der Dornbirner Wochenmarkt liegt zentral vor der Martinskirche in der Fußgängerzone. Ein Regionalverkäufer bietet bio Bodenseeäpfel an.";
            Field inatura = new Museum(2, "Inatura", Field.FieldType.NORMAL);
            inatura.Description = "Auflösung der Ausstellung 'Mittelalter: Natur, Kultur und Krieg'. Sie können einen Schwert als Souvenir mitnehmen.";
            Field ebnit = new Mountain(3, "Ebnit", Field.FieldType.NORMAL);
            ebnit.Description = "Fortgeschrittene Skifahrer wie auch Skianfänger haben mit den zwei Liften und drei Kilometern Piste ausreichend Freiraum. Ups, da liegt ein weisser Schlüssel auf der Piste.";
            ebnit.IsPassable = false;
            (ebnit as Mountain).ItemNeededForMountain = "Ski"; 
            Field messepark = new FreeEntryFields(4, "Messepark", Field.FieldType.NORMAL);
            messepark.Description = "Schöne Dinge fürs kleine Glück. Sie haben bei der Verlosung von Berg- und Sportausrüstung von Intersport im Messepark gewonnen.";
            Field kika = new FreeEntryFields(5, "KIKA", Field.FieldType.NORMAL);
            kika.Description = "Willkommen in Ihrem kika Dornbirn. Viele neue Wohnideen. Inspirierende Möbel-Ausstellung. Top Einrichtungs-Beratung. Top Angebot: WmF Bestäckset um 20 Euro.";
            Field vMilch = new WorkingArea(6, "Vorarlberger Milch Filiale", Field.FieldType.NORMAL);
            vMilch.Description = "Vorarlberger Milch Filiale Dornbirn sucht Verkäufer. Vielen Dank für Ihren spontanen Einsatz. Sie bekommen Taschengeld: 25 Euro";
            Field mohren = new Museum(7, "Museum der Mohren Biererlebniswelt", Field.FieldType.NORMAL);
            mohren.Description = "Seit 1834 prägt die Mohrenbrauerei in Dornbirn die Vorarlberger Bierkultur. Ein Krug Bier auf das Haus.";
            Field dm = new FreeEntryFields(8, "DM Drogeriemarkt", Field.FieldType.NORMAL);
            dm.Description = "Ausverkauf von Schwimmflügel (Kosten: 5 Euro)";
            Field cafe21 = new FreeEntryFields(9, "Cafe 21", Field.FieldType.NORMAL);
            cafe21.Description = "Café 21 is mehr als ein Café! Hier wird nicht nur Kaffe und Tee angeboten, sondern auch ein saftiger Steak...";
            Field intersport = new FreeEntryFields(10, "Intersport", Field.FieldType.NORMAL);
            intersport.Description = "Intersprot Fischer in Dornbirn ist das grösste Sprotgeschäft in Vorarlberg. Sprotausrüstung zum Aktionspreis (15 Euro)";
            Field karren = new Mountain(11, "Karren", Field.FieldType.NORMAL);
            karren.Description = "Noch kurz auf den Karren zu gehen ist in Dornbirn ein häufiges Feierabendritual.­ Sie erhalten 15 Kcal Energie für gesunde Aktivitätien.";
            karren.IsPassable = false;
            (karren as Mountain).ItemNeededForMountain = "Ski";
            Field stadtbad = new Water(12, "Das Stadtbad", Field.FieldType.NORMAL);
            stadtbad.Description = "Das Dornbirner Stadthallenbad in einen besonderen Erlebnisraum mit allem, was ein Hallenbad sonst noch haben muss. Gesunde Aktivitäten verleihen mehr Energie (+15)";
            (stadtbad as Water).ItemNeededToSwimm = "Schwimmflügel";
            stadtbad.IsPassable = false;
            Field bahnhof = new DangerousArea(13, "Dornbirner Bahnhof", Field.FieldType.NORMAL);
            bahnhof.Description = "Eine Gruppe von Jugendlichen will Ihr ganzes Geld stehlen. Sie können entweder kämpfen oder das freiwillig Geld abgeben.";
            Field boedele = new Mountain(14, "Bödele", Field.FieldType.NORMAL);
            boedele.Description = "Familienfreundlich ist das Bödele nicht nur für Schifahrer, auch rodeln kann man hier bestens. 15 Energie für gesunde Aktivitätien";
            boedele.IsPassable = false;
            (boedele as Mountain).ItemNeededForMountain = "Ski";
            Field spar = new FreeEntryFields(15, "Spar", Field.FieldType.NORMAL);
            spar.Description = "Regionale, saisonale, Bio Lebensmittel, eigene Manufaktur: Lebensmittelmarkt in Dornbirn. Grüne Apfel im Ausverkauf (10 Euro)";
            Field redDoor = new Door(16, "rote Tür", Field.FieldType.NORMAL,"111");
            redDoor.IsPassable = false;
            Field rotesHaus = new FreeEntryFields(17, "Rotes Haus", Field.FieldType.NORMAL);
            rotesHaus.Description = "Heute auf der Speisekarte 'Französische Zwiebelsuppe mit Käse Croûtons*** Schweinerücken Steak an Pfefferrahmsauce mit Broccoli und Pommes frites'. Sensantionelle 20 Euro.";
            Field faerbegasse = new FreeEntryFields(18, "Färbegasse", Field.FieldType.NORMAL);
            faerbegasse.Description = "Ein Passant hat einen roten Schlüssel verloren.";
            Field aSchneiderStr = new DangerousArea(19, "Anton-Schneiderstrasse", Field.FieldType.NORMAL);
            aSchneiderStr.Description = "Rumänische Diebesbande auf Ihrem Weg.";         
            Field ach = new Water(20, "Dornbirnder Ach", Field.FieldType.NORMAL);
            ach.Description = "Die Dornbirner Ach ist neben der nördlicher verlaufenden Bregenzer Ach einer der wichtigsten Abflüsse für die kleineren Bäche des westlichen Bregenzerwaldgebirges und des unteren Rheintals im österreichischen Bundesland Vorarlberg. Gut, dass deine Schwimmflügel immer dabei sind!";
            (ach as Water).ItemNeededToSwimm = "Schwimmflügel";
            ach.IsPassable = false;
            Field whiteDoor = new Door(21, "Weisse Tür", Field.FieldType.NORMAL,"222");
            whiteDoor.IsPassable = false;
            Field finish = new FreeEntryFields(22, "Finish", Field.FieldType.FINISH);
            finish.Description = "Sie sind am Finish-Feld";


            // Verbinde die Felder miteinander
            markt.ConnectField(null, start, null, inatura);
            inatura.ConnectField(null, intersport, markt, ebnit);
            ebnit.ConnectField(null, cafe21, inatura, null);
            messepark.ConnectField(null, mohren, null, kika);
            kika.ConnectField(null, vMilch, messepark, null);
            vMilch.ConnectField(kika, null, mohren, null);
            mohren.ConnectField(messepark, null, dm, vMilch);
            dm.ConnectField(null, bahnhof, cafe21, mohren);
            cafe21.ConnectField(ebnit, null, intersport, dm);
            intersport.ConnectField(inatura, stadtbad, start, cafe21);
            start.ConnectField(markt, karren, null, intersport);
            karren.ConnectField(start, boedele, null, stadtbad);
            stadtbad.ConnectField(intersport, spar, karren, null);
            bahnhof.ConnectField(dm, rotesHaus, null, null);
            boedele.ConnectField(karren, faerbegasse, null, spar);
            spar.ConnectField(stadtbad, aSchneiderStr, boedele, redDoor);
            redDoor.ConnectField(null, null, spar, rotesHaus);
            rotesHaus.ConnectField(bahnhof, ach, redDoor, null);
            faerbegasse.ConnectField(boedele, null, null, aSchneiderStr);
            aSchneiderStr.ConnectField(spar, null, faerbegasse, null);
            ach.ConnectField(rotesHaus, null, null, whiteDoor);
            whiteDoor.ConnectField(null, null, ach, finish);
            finish.ConnectField(null, null, whiteDoor, null);

            // Erstelle Gegenstände und ordne diese zu den Feldern
            Item redKey = new Key("Schlüssel (rot)",true, "111");
            faerbegasse.Item = redKey;

            Item redApple = new Apple("Apfel (rot)",true);
            markt.Item = redApple;
            redApple.Costs = 10;
            (redApple as Apple).Kcal = 25;           
            
            Item sword = new Weapon("Schwert", true);
            inatura.Item = sword;

            Item whiteKey = new Key("Schlüssel (weiss)",true, "222");
            ebnit.Item = whiteKey;           

            Item sportItem = new SportItem("Ski",true);
            messepark.Item = sportItem;

            Item utensils = new Weapon("Besteck",true);
            kika.Item = utensils;
            utensils.Costs = 20;

            Item ski = new SportItem("Ski",true);
            intersport.Item = ski;
            ski.Costs = 15;

            Item swimmingWings = new SportItem("Schwimmflügel",true);
            dm.Item = swimmingWings;
            swimmingWings.Costs = 5;

            Item beer = new Food("Bier",false,30);
            mohren.Item = beer;

            Item greenApple = new Apple("Apfel (grün)",true);
            spar.Item = greenApple;
            greenApple.Costs = 10;
            (greenApple as Apple).Kcal = 15;

            Item steak = new Food("Steak",false,65);
            cafe21.Item = steak;
            steak.Costs = 40;

            Item meat = new Food("Schweinerücken Steak an Pfefferrahmsauce",false,90);
            rotesHaus.Item = meat;
            meat.Costs = 20;

            // Erzeuge einen Spieler und platziere ihn auf das Startfeld
            Player myPlayer = new Player(start);

            // instanziere GameAssistent
            GameAssistent game = new GameAssistent(myPlayer);
            game.Play();         
        }
    }
}
