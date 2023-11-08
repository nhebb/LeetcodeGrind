namespace LeetcodeGrind.Solutions;

// 347. Top K Frequent Elements
public class P0347
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (d.ContainsKey(nums[i]))
                d[nums[i]]++;
            else
                d[nums[i]] = 1;
        }

        var pq = new PriorityQueue<int, long>();
        foreach (var kvp in d)
        {
            pq.Enqueue(kvp.Key, Int32.MaxValue - kvp.Value);
        }

        var topk = new int[k];
        int j = 0;
        while (j < k)
        {
            topk[j] = pq.Dequeue();
            j++;
        }

        return topk;
    }
}
