using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class FreeEntryFields : Field, IEnter
    {
        #region Konstruktor
        public FreeEntryFields (int nr, string name, FieldType type) : base(nr, name, type)
        {
            this.Name = name;
            this.Number = nr;
            this.Type = type;
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
