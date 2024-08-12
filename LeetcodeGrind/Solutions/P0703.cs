namespace LeetcodeGrind.Solutions;

// 703. Kth Largest Element in a Stream
public class KthLargest
{
    // Slow
    private PriorityQueue<int, int> pq;
    private int _k;

    public KthLargest(int k, int[] nums)
    {
        pq = new PriorityQueue<int, int>(k);
        _k = k;

        foreach (var num in nums)
            pq.Enqueue(num, num);

        while (pq.Count > k)
            _ = pq.Dequeue();
    }

    public int Add(int val)
    {
        pq.Enqueue(val, val);

        while (pq.Count > _k)
            _ = pq.Dequeue();

        return pq.Peek();
    }
}
