using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    interface IConsume
    {
        // Anhand des Strings (Name, Passwort etc) soll erkannt werden, welcher Gegenstand angewendet wird
        string Consume();
    }
}
