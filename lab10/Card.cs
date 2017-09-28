using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    internal class Card : IComparable<Card>
    {
        public CardSuit CardSuit { get; private set; }
        public CardValue CardValue { get; private set; }
        public Card(CardValue cardValue, CardSuit cardSuit)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
        }

        public char GetCardSuitChar()
        {           
            switch (CardSuit)
            {
                default:
                case CardSuit.Hearts:
                    return '♥';
                case CardSuit.Clubs:
                    return '♣';
                case CardSuit.Diamonds:
                    return '♦';
                case CardSuit.Spades:
                    return '♠';               
            }
        }

        //10 - это T
        public char GetCardValueChar()
        {
            switch (CardValue)
            {
                default:
                case CardValue.Ace:
                    return 'A';
                case CardValue.King:
                    return 'K';
                case CardValue.Queen:
                    return 'Q';
                case CardValue.Jack:
                    return 'J';
                case CardValue.Ten:
                    return 'T';
                case CardValue.Nine:
                    return '9';
                case CardValue.Eight:
                    return '8';
                case CardValue.Seven:
                    return '7';
                case CardValue.Six:
                    return '6';
            }
        }

        public override string ToString()
        {
            return $"|‾‾‾‾‾‾|\n|      |\n|  {GetCardValueChar()}{GetCardSuitChar()}  |\n|      |\n|______| ";
        }

        public int CompareTo(Card other)
        {
            return ((int)CardValue).CompareTo((int)other.CardValue);
        }
    }
}
