namespace LeetcodeGrind.Solutions;

// 2335. Minimum Amount of Time to Fill Cups
public class P2335
{
    public int FillCups(int[] amount)
    {
        var pq = new PriorityQueue<int, int>();
        for (int i = 0; i < amount.Length; i++)
        {
            if (amount[i] > 0)
                pq.Enqueue(amount[i], -amount[i]);
        }

        var time = 0;

        while (pq.Count > 1)
        {
            var one = pq.Dequeue();
            var two = pq.Dequeue();

            time++;

            one--;
            if (one > 0)
                pq.Enqueue(one, -one);
            
            two--;
            if (two > 0)
                pq.Enqueue(two, -two);
        }

        if (pq.Count > 0)
            time += pq.Dequeue();

        return time;
    }
}
