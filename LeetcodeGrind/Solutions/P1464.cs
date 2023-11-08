namespace LeetcodeGrind.Solutions;

// 1464. Maximum Product of Two Elements in an Array
public class P1464
{
    public int MaxProduct(int[] nums)
    {
        var pq = new PriorityQueue<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Store the index in the pq using the
            // negated value as the priority
            pq.Enqueue(i, -1 * (nums[i] - 1));
        }

        var max1 = nums[pq.Dequeue()] - 1;
        var max2 = nums[pq.Peek()] - 1;

        return max1 * max2;
    }
}
