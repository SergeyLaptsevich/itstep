using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class PlayerEventArgs : EventArgs
    {
        public String Name { get; private set; }
        public PlayerEventArgs(String name)
        {
            Name = name;
        }
    }
}
