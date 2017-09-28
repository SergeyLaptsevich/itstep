using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    //он должен иметь метод вывода карт, но мне кажется, что он ни к чему
    public class Player
    {
        public String Name { get; private set; }
        public int CardsCount { get { return Cards.Count; } }
        private Queue<Card> Cards { get; set; } = new Queue<Card>();

        public Player(String name)
        {
            Name = name;
        }

        internal Card PutCard()
        {
            return Cards.Dequeue();
        }

        internal void GetCard(Card card)
        {
            Cards.Enqueue(card);
        }

        internal void GetCards(IEnumerable<Card> _cards)
        {
            foreach (var card in _cards)
                GetCard(card);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
