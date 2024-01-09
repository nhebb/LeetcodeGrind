namespace LeetcodeGrind.Solutions;

// 2099. Find Subsequence of Length K With the Largest Sum
public class P2099
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        var pq = new PriorityQueue<(int index, int val), int>();
        for (int i = 0; i < nums.Length; i++)
        {
            pq.Enqueue((i, nums[i]), -nums[i]);
        }

        var indexes = new int[k];
        var result = new int[k];
        for (int i = 0; i < k; i++)
        {
            var tuple = pq.Dequeue();
            indexes[i] = tuple.index;
            result[i] = tuple.val;
        }

        Array.Sort(indexes, result);
        return result;

    }
}
