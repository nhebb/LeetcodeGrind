namespace LeetcodeGrind.Solutions;

// 2558. Take Gifts From the Richest Pile
public class P2558
{
    public long PickGifts(int[] gifts, int k)
    {
        var pq = new PriorityQueue<int, int>();
        foreach (var gift in gifts)
            pq.Enqueue(gift, -gift);

        while (k > 0)
        {
            var qty = pq.Dequeue();
            var putback = (int)(Math.Floor(Math.Sqrt(qty)));
            pq.Enqueue(putback, -putback);
            k--;
        }

        long remaining = 0;
        while (pq.Count > 0)
            remaining += pq.Dequeue();

        return remaining;
    }
}
