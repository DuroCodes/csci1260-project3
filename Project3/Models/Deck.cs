namespace Project3.Models;

public class Deck
{
    private readonly Random _random = new();
    private Stack<Card> Cards { get; } = new();

    public Deck(int count)
    {
        for (var i = 0; i < count; i++)
            Cards.Push(new Card(
                (Suit)_random.Next(0, 4),
                (Rank)_random.Next(2, 15)
            ));
    }

    public void Shuffle()
    {
        var cards = Cards.ToList();
        Cards.Clear();
        cards.OrderBy(_ => _random.Next()).ToList().ForEach(c => Cards.Push(c));
    }

    public void DistributeCards(Dictionary<string, Hand> playerHands)
    {
        var players = playerHands.Keys.ToList();
        Cards
            .Select((card, i) => new { card, player = players[i % players.Count] })
            .ToList()
            .ForEach(x => playerHands[x.player].Cards.Enqueue(x.card));
        Cards.Clear();
    }
}