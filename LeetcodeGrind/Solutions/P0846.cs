namespace LeetcodeGrind.Solutions;

// 846. Hand of Straights
public class P0846
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
            return false;

        var pq = new PriorityQueue<int, int>();
        var d = new Dictionary<int, int>();

        foreach (var card in hand)
        {
            if (d.ContainsKey(card))
            {
                d[card]++;
            }
            else
            {
                d[card] = 1;
                pq.Enqueue(card, card);
            }
        }

        var count = 0;
        while (pq.Count > 0)
        {
            count = 0;
            var nextCard = pq.Peek();
            while (count < groupSize)
            {
                if (!d.ContainsKey(nextCard))
                    return false;

                d[nextCard]--;
                if (d[nextCard] == 0)
                    _ = pq.Dequeue();

                count++;
                nextCard++;
            }
        }

        return true;
    }
}

