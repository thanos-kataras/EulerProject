using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject.Problems_51_60
{
    class Problem54 : AbstractProblem, IProblem
    {
        private string[] lines;
        public Problem54() : base(54)
        {
            //this.lines = new string[] { "1C 1D 1H 2D 3H 1C 1D 1H 2D 3H"};
            this.lines = System.IO.File.ReadAllLines(@"..\..\FileResources\p054_poker.txt");
        }

        public void Run()
        {
            int hand1wins = 0;
            foreach(String line in this.lines)
            {
                Hand hand1 = new Hand(line.Substring(0, 14));
                Hand hand2 = new Hand(line.Substring(15));
                int result = hand1.CompareHands(hand2);
                if (result > 0)
                {
                    hand1wins++;
                }
                else if (result == 0)
                {
                    Console.WriteLine("Draw");
                }
            }

            this.result = hand1wins.ToString();
        }

        private class Hand
        {
            private List<Card> handCards = new List<Card>();
            private int highNumber = 0, onePairHigh = 0;

            public List<Card> HandCards { get{ return this.handCards; } }

            public int OnePairHigh { get { return this.onePairHigh; } }

            public Hand(String hand)
            {
                string[] cards = hand.Split(' ');
                foreach (string card in cards)
                {
                    handCards.Add(new Card(card));
                }
                handCards.Sort();
            }

            public HandResult getResult()
            {
                Card previous = null;
                HandResult maxResult = HandResult.HighCard;

                int sameConsecutive = 1, consecutives = 1, sameColor = 1;

                for(int i = 0; i < 5; i++)
                {
                    Card card = handCards[i];
                    highNumber = card.Numeric;
                    if (previous != null)
                    {
                        if (previous.Color == card.Color)
                            sameColor++;
                        if (previous.Numeric == card.Numeric)
                            sameConsecutive++;
                        if (previous.Numeric == card.Numeric - 1)
                            consecutives++;

                        if (sameConsecutive == 5 || previous.Numeric != card.Numeric)
                        {
                            switch (sameConsecutive)
                            {
                                case 1:
                                    break;
                                case 2:
                                    switch (maxResult)
                                    {
                                        case HandResult.HighCard:
                                            maxResult = HandResult.OnePair;
                                            this.onePairHigh = previous.Numeric;
                                            break;
                                        case HandResult.OnePair:
                                            maxResult = HandResult.TwoPairs;
                                            break;
                                        case HandResult.ThreeOfAKind:
                                            maxResult = HandResult.FullHouse;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (maxResult)
                                    {
                                        case HandResult.HighCard:
                                            maxResult = HandResult.ThreeOfAKind;
                                            break;
                                        case HandResult.OnePair:
                                            maxResult = HandResult.FullHouse;
                                            break;
                                    }
                                    break;
                                case 4:
                                    maxResult = HandResult.FourOfAKind;
                                    break;
                            }
                            sameConsecutive = 0;
                        }
                    }
                    
                    if (sameColor == 5)
                    {
                        maxResult = maxResult > HandResult.Flush ? maxResult : HandResult.Flush;
                    }

                    if (consecutives >= 5)
                    {
                        if (sameColor == 5)
                            maxResult = HandResult.StraightFlush;
                        else
                        {
                            maxResult = maxResult > HandResult.Straight ? maxResult : HandResult.Straight;
                        }
                    }

                    previous = card;
                }

                return maxResult;
            }

            public int CompareHands(Hand hand)
            {
                HandResult thisResult = this.getResult();
                HandResult otherResult = hand.getResult();
                if (thisResult > otherResult)
                    return 1;
                else if (thisResult == otherResult) { 
                    switch (thisResult)
                    {
                        case HandResult.HighCard:
                            for (int i = 4; i> 0; i--)
                            {
                                if (this.HandCards[i].Numeric > hand.HandCards[i].Numeric)
                                    return 1;
                                else if (this.HandCards[i].Numeric < hand.HandCards[i].Numeric)
                                    return -1;
                            }
                            break;
                        case HandResult.OnePair:
                            if (this.OnePairHigh > hand.OnePairHigh)
                                return 1;
                            else
                                return -1;
                    }

                    return 0;
                }
                else
                    return -1;
            }
        }

        private enum HandResult {
            HighCard = 0,
            OnePair = 1,
            TwoPairs = 2,
            ThreeOfAKind = 3,
            Straight = 4,
            Flush = 5,
            FullHouse = 6,
            FourOfAKind = 7,
            StraightFlush = 8,
            RoyalFlush = 9
        }

        private class Card : IComparable<Card>
        {
            int numeric;
            CardColor color;

            public CardColor Color { get { return this.color; } }
            public int Numeric { get {return this.numeric; } }

            public Card(String card)
            {
                char num = card[0];
                switch (num)
                {
                    case 'T':
                        this.numeric = 10;
                        break;
                    case 'J':
                        this.numeric = 11;
                        break;
                    case 'Q':
                        this.numeric = 12;
                        break;
                    case 'K':
                        this.numeric = 13;
                        break;
                    case 'A':
                        this.numeric = 14;
                        break;
                    default:
                        this.numeric = Int32.Parse(card[0].ToString());
                        break;
                }

                char color = card[1];
                switch (color)
                {
                    case 'S':
                        this.color = CardColor.Spades;
                        break;
                    case 'H':
                        this.color = CardColor.Hearts;
                        break;
                    case 'C':
                        this.color = CardColor.Clubs;
                        break;
                    case 'D':
                        this.color = CardColor.Diamonds;
                        break;
                }
            }

            public int CompareTo(Card other)
            {
                if (this.numeric < other.numeric)
                    return -1;
                else if (this.numeric == other.numeric)
                    return 0;
                else
                    return 1;
            }
        }

        private enum CardColor
        {
            Spades, Hearts, Diamonds, Clubs
        }
    }
}
