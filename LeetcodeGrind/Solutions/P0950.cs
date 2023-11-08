namespace LeetcodeGrind.Solutions;

// 950. Reveal Cards in Increasing Order
public class P0950
{
    public int[] DeckRevealedIncreasing(int[] deck)
    {
        Array.Sort(deck);
        var q = new Queue<int>(Enumerable.Range(0, deck.Length));
        var res = new int[deck.Length];

        foreach (var card in deck)
        {
            res[q.Dequeue()] = card;
            if (q.Count > 0)
                q.Enqueue(q.Dequeue());
        }
        return res;
    }
}
