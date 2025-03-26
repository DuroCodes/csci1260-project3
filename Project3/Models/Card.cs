namespace Project3.Models;

public record Card(Suit Suit, Rank Rank) : IComparable<Card>
{
    public string ImagePath => $"images/card_{Suit.ToString().ToLower()}_{Rank.DisplayString()}.png";

    public int CompareTo(Card? other) => Rank.CompareTo(other?.Rank);
    public override string ToString() => $"{Rank} of {Suit}";
}