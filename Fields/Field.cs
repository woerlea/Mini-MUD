using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Field
    {
        #region Eigenschaften
        public enum FieldType
        {
            START,
            NORMAL,
            FINISH
        }
        public FieldType Type = FieldType.NORMAL;
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public Field North { get; set; }
        public Field South { get; set; }
        public Field East { get; set; }
        public Field West { get; set; }
        public Item Item { get; set; }
        public bool IsPassable { get; set; } = true;
        public int EntryPrice { get; set; } = 0;
        #endregion

        #region Konstruktor
        public Field (int nr, string name, FieldType type)
        {
            this.Number = nr;
            this.Name = name;
            this.Type = type;
        }
        #endregion

        #region Methoden
        // Felder miteinander verbinden
        public void ConnectField (Field up, Field down, Field left, Field right)
        {
            this.North = up;
            this.South = down;
            this.West = left;
            this.East = right;
        }
        #endregion
    }
}
