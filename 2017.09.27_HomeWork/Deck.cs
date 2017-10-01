using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2017._09._27_HomeWork
{
    public class Deck
    {
        public List<Card> deck { get; set; }

        public Deck()
        {
            deck = new List<Card>();
        }

        public void FillDeck()
        {
            List<string> suit = new List<string> { "D", "C", "H", "S" };            
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 6; j < 15; j++)
                {
                    if (j < 11)
                    {
                        deck.Add(new Card(j.ToString() + suit[index], j));                                              
                    }
                    else if (j == 11)
                    {
                        deck.Add(new Card("J" + suit[index], j));                                               
                    }
                    else if (j == 12)
                    {
                        deck.Add(new Card("Q" + suit[index], j));                        
                    }
                    else if (j == 13)
                    {
                        deck.Add(new Card("K" + suit[index], j));                       
                    }
                    else if (j == 14)
                    {
                        deck.Add(new Card("A" + suit[index], j));                        
                    }
                }
                ++index;
            }
        }

        public void ShuffleDeck()
        {
            deck = deck.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public void PrintDictionary()
        {
            foreach (var card in deck)
            {
                Console.WriteLine(card.Key);
            }
        }

        public void AddCardToPlayerDeck(Card pair)
        {
            deck.Add(new Card(pair.Key, pair.Value));
        }
    }
}
