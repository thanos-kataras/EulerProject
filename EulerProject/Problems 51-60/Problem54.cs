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
            private int onePairHigh = 0;

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
                if (IsRoyalFlush())
                    return HandResult.RoyalFlush;
                else if (IsStraightFlush())
                    return HandResult.StraightFlush;
                else if (IsFourOfAKind())
                    return HandResult.FourOfAKind;
                else if (IsFullHouse())
                    return HandResult.FullHouse;
                else if (IsFlush())
                    return HandResult.Flush;
                else if (IsStraight())
                    return HandResult.Straight;
                else if (IsThreeOfAKind())
                    return HandResult.ThreeOfAKind;
                else if (IsTwoPairs())
                    return HandResult.TwoPairs;
                else if (IsOnePair())
                    return HandResult.OnePair;

                return HandResult.HighCard;
            }

            private bool IsRoyalFlush()
            {
                if (handCards[4].Numeric != 14)
                    return false;
                for(int i=3; i>=0; i--)
                {
                    if (handCards[i + 1].Numeric != handCards[i].Numeric + 1)
                        return false;
                    if (handCards[i + 1].Color != handCards[i].Color)
                        return false;
                }
                return true;
            }

            private bool IsStraightFlush()
            {
                for (int i = 3; i >= 0; i--)
                {
                    if (handCards[i + 1].Numeric != handCards[i].Numeric + 1)
                        return false;
                    if (handCards[i + 1].Color != handCards[i].Color)
                        return false;
                }
                return true;
            }

            private bool IsFourOfAKind()
            {
                int consecSame=1;
                Card previous = null;
                foreach (Card card in handCards)
                {
                    if (previous == null)
                        previous = card;
                    else
                    {
                        if (previous.Numeric == card.Numeric)
                            consecSame++;
                        else if (consecSame!=4)
                            consecSame = 1;
                        previous = card;
                    }
                }

                if (consecSame == 4)
                    return true;
                else
                    return false;       
            }

            private bool IsFullHouse()
            {
                return (handCards[0].Numeric == handCards[1].Numeric
                    && handCards[2].Numeric == handCards[3].Numeric
                    && handCards[3].Numeric == handCards[4].Numeric) ||
                    (handCards[0].Numeric == handCards[1].Numeric
                    && handCards[1].Numeric == handCards[2].Numeric
                    && handCards[3].Numeric == handCards[4].Numeric);
            }

            private bool IsFlush()
            {
                for (int i=0;i<4;i++)
                {
                    if (handCards[i].Color != handCards[i + 1].Color)
                        return false;
                }
                return true;
            }

            private bool IsStraight()
            {
                for (int i = 0; i < 4; i++)
                {
                    if (handCards[i].Numeric != handCards[i + 1].Numeric -1)
                        return false;
                }
                return true;
            }

            private bool IsThreeOfAKind()
            {
                int consecSame = 1;
                Card previous = null;
                foreach (Card card in handCards)
                {
                    if (previous == null)
                        previous = card;
                    else
                    {
                        if (previous.Numeric == card.Numeric)
                            consecSame++;
                        else if (consecSame!=3)
                            consecSame = 1;
                        previous = card;
                    }
                }

                if (consecSame == 3)
                    return true;
                else
                    return false;
            }

            private bool IsTwoPairs()
            {
                int pairs = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (handCards[i].Numeric == handCards[i + 1].Numeric)
                    {
                        pairs++;
                        //skip next for checking
                        i++;
                    }
                }
                if (pairs == 2)
                    return true;
                return false;
            }

            private bool IsOnePair()
            {
                int pairs = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (handCards[i].Numeric == handCards[i + 1].Numeric)
                    {
                        this.onePairHigh = handCards[i].Numeric;
                        pairs++;
                        //skip next for checking
                        i++;
                    }
                }
                if (pairs == 1)
                    return true;
                this.onePairHigh = 0;
                return false;
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
                            else if (this.OnePairHigh == hand.OnePairHigh)
                            {
                                List<Card> remHighPair1 = this.HandCards.Where(x => x.Numeric != this.OnePairHigh).ToList();
                                List<Card> remHighPair2 = hand.HandCards.Where(x => x.Numeric != this.OnePairHigh).ToList();
                                for (int i = 2; i > 0; i--)
                                {
                                    if (remHighPair1[i].Numeric > remHighPair2[i].Numeric)
                                        return 1;
                                    else if (remHighPair1[i].Numeric < remHighPair2[i].Numeric)
                                        return -1;
                                }
                            }
                            else
                                return -1;
                            break;
                    }

                    return 0;
                }
                else
                    return -1;
            }
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

        private enum HandResult
        {
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
        private enum CardColor
        {
            Spades, Hearts, Diamonds, Clubs
        }
    }
}
