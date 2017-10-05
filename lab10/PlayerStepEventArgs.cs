using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class PlayerStepEventArgs : PlayerEventArgs
    {
        public String Card { get; private set; }
        public int CardsCount { get; private set; }
        public PlayerStepEventArgs(String name, int cards_count, String card) : base(name)
        {
            CardsCount = cards_count;
            Card = card;
        }
    }
}
