using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._09._27_HomeWork
{
    public class Game
    {
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }

        public Game()
        {
            Deck = new Deck();
            Deck.FillDeck();
            Deck.ShuffleDeck();            
        }

        public void HowPlayers()
        {
            string countStr;
            Console.WriteLine("Please, enter player (2 - 4): ");
            countStr = Console.ReadLine();
            int count = int.Parse(countStr);

            Players = new List<Player>(count);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter name player {0}", i + 1);
                countStr = Console.ReadLine();
                Players.Add(new Player(countStr));
            }
        }

        public void DistributeCards()
        {
            do
            {
                for (int i = 0; i < Players.Count(); i++)
                {                    
                    Players[i].AddCard(Deck.deck[0]);
                    Deck.deck.Remove(Deck.deck[0]);                    
                }
            } while (Deck.deck.Count != 0);            
        }

        public void ShowCardPlayer()
        {
            foreach(var pl in Players)
            {
                pl.ShowCard();
            }
        }

        public void Play()
        {
            int[] buff = new int[Players.Count];
            List<Card> cards = new List<Card>();
            int i = 0;
            int indexWinner = 0;
            do
            {
                foreach(var pl in Players)
                {
                    if (pl.DeckPlayer.deck.Count > 0)
                    {
                        Console.WriteLine(pl.Name);
                        Console.WriteLine(pl.DeckPlayer.deck[0].Key);
                        buff[i++] = pl.DeckPlayer.deck[0].Value;
                        cards.Add(new Card(pl.DeckPlayer.deck[0].Key, pl.DeckPlayer.deck[0].Value));                        
                    }                    
                }
                i = 0;
                                                
                for (int j = 0; j < Players.Count; j++)
                {
                    if (Players[j].DeckPlayer.deck.Count > 0)
                    {
                        if (Players[j].DeckPlayer.deck[0].Value == buff.Max())
                        {
                            indexWinner = j;
                            break;
                        }                        
                    }                    
                }

                foreach (var pl in Players)
                {
                    if (pl.DeckPlayer.deck.Count > 0)
                    {                        
                        pl.DeckPlayer.deck.Remove(pl.DeckPlayer.deck[0]);
                    }
                }
                

                for (int j = 0; j < Players.Count; j++)
                {
                    if (Players[j].DeckPlayer.deck.Count > 0)
                    {
                        if (j == indexWinner)
                        {
                            foreach (var card in cards)
                            {
                                Players[j].AddCard(card);
                            }
                            break;
                        }
                    }                        
                }
                indexWinner = 0;
                cards.Clear();
                foreach(var pl in Players)
                {
                    Console.WriteLine("\nPlayer {0} have {1} cards", pl.Name, pl.DeckPlayer.deck.Count);
                }
                
                Console.ReadKey();
            } while (!CheckCountCard());
        }

        private bool CheckCountCard()
        {
            foreach(var pl in Players)
            {
                if (pl.DeckPlayer.deck.Count == 30)
                {
                    return true;
                }
            }
            return false;
        }

        public void PrintWinner()
        {
            foreach (var pl in Players)
            {
                if (pl.DeckPlayer.deck.Count == 30)
                {
                    Console.WriteLine("Winner {0}", pl.Name);
                }
            }
        }
    }
}
