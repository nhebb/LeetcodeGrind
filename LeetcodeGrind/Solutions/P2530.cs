namespace LeetcodeGrind.Solutions;

// 2530. Maximal Score After Applying K Operations
public class P2530
{
    public long MaxKelements(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>(nums.Length);
        foreach (var num in nums)
        {
            pq.Enqueue(num, -num);
        }

        var score = 0;

        while (k > 0)
        {
            var val = pq.Dequeue();
            score += val;
            val = (int)(Math.Ceiling((double)val / 3.0));
            pq.Enqueue(val, -val);
            k--;
        }

        return score;
    }
}
