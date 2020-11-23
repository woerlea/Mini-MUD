using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Museum : Field, IEnter
    {      

        #region Konstruktor
        public Museum (int nr, string name, FieldType type) : base(nr, name, type)
        {
            this.Name = name;
            this.Number = nr;
            this.Type = type;
            this.EntryPrice = 5;
        }
        #endregion

        #region Methoden
        public Field Enter()
        {
            return this;
        }
        #endregion
    }
}
