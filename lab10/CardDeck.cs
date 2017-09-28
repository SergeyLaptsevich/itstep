using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    internal class CardDeck
    {
        private Queue<Card> deck;

        public int Size { get { return deck.Count; } }
        public CardDeck()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            List<Card> tmp_deck = new List<Card>();
            for(int i = (int)CardSuit.Hearts; i <= (int)CardSuit.Spades; i++)
                for(int j = (int)CardValue.Six; j <= (int)CardValue.Ace; j++)
                    tmp_deck.Add(new Card((CardValue)j, (CardSuit)i));

            deck = new Queue<Card>(ShuffleList(tmp_deck));
        }

        public Card GetCard()
        {
            return deck.Dequeue();
        }

        public void Shuffle()
        {
            deck = new Queue<Card>(ShuffleList(new List<Card>(deck)));
        }

        //интересные реализации с использованием orderby или sort (со своими предикатами/делегатами) плохо тусуют колоду
        private List<Card> ShuffleList(List<Card> inputList)
        {
            List<Card> randomList = new List<Card>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }

            return randomList;
        }
    }
}
