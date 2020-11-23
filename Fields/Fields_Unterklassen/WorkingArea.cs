using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class WorkingArea : Field, IEnter
    {
        public int Earnings { get; } = 25;

        #region Konstruktor
        public WorkingArea(int nr, string name, FieldType type) : base(nr, name, type)
        {
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
