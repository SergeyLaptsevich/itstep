using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._27_HomeWork
{
    public class Player
    {
        public string Name { get; set; }
        public Deck DeckPlayer { get; set; }

        public Player(string name)
        {
            Name = name;
            DeckPlayer = new Deck();
        }

        public void AddCard(Card pair)
        {
            DeckPlayer.AddCardToPlayerDeck(pair);
        }

        public void ShowCard()
        {
            DeckPlayer.PrintDictionary();
        }
    }
}
