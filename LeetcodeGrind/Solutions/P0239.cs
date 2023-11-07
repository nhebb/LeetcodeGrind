namespace LeetcodeGrind.Solutions;

// 239. Sliding Window Maximum
public class P0239
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (k == 1) return nums;

        var d = new Dictionary<int, int>();
        var pq = new PriorityQueue<int, long>();
        var res = new List<int>();

        for (int i = 0; i < k; i++)
        {
            if (!d.TryAdd(nums[i], 1))
                d[nums[i]]++;
            pq.Enqueue(nums[i], -nums[i]);
        }
        res.Add(pq.Peek());

        for (int i = 1, j = k; j < nums.Length; i++, j++)
        {
            d[nums[i - 1]]--;
            while (d[pq.Peek()] == 0)
                _ = pq.Dequeue();
            if (!d.TryAdd(nums[j], 1))
                d[nums[j]]++;
            pq.Enqueue(nums[j], -nums[j]);
            res.Add(pq.Peek());
        }

        return res.ToArray();
    }
}
