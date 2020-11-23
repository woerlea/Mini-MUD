using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Mini_MUD
{
    interface IItemConsumer
    {
        public bool UseItem(Item item);
    }
}
