using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    class Key : Item 
    {
        public string Passwort { get; set; }
        public Key (string name, bool ifCollectable, string passwort): base(name, ifCollectable)
        {
            this.Passwort = passwort;
        }
    }
}
