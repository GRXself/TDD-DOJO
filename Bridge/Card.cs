using System;

namespace Bridge
{
    public class Card : IComparable<Card>
    {
        public Card(char suit, char number)
        {
            Suit = suit;
            Number = number;

            switch (number)
            {
                case 'T': Value = 10;break;
                case 'J': Value = 11;break;
                case 'Q': Value = 12;break;
                case 'K': Value = 13;break;
                case 'A': Value = 14;break;
                default: Value = short.Parse(number.ToString());
                    break;
            }
        }

        public char Number { get; }

        public char Suit { get; }

        public short Value { get; }

        public static Card Parse(string value)
        {
            return new Card(value[1], value[0]);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Card item))
            {
                return false;
            }

            return Number.Equals(item.Number);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode()^Suit.GetHashCode();
        }

        public int CompareTo(Card other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var numberComparison = Value.CompareTo(other.Value);
            return numberComparison;
        }
    }
}