namespace LeetcodeGrind.Solutions;

// 1675. Minimize Deviation in Array
public class P1675
{
    public int MinimumDeviation(int[] nums)
    {
        var pqMax = new PriorityQueue<int, int>();
        var pqMin = new PriorityQueue<int, int>();

        // multiply the odds by 2. Now the odd / even
        // problem becomes an even-only  problem at
        // the low end and you can focus on the high end
        for (int i = 0; i < nums.Length; i++)
        {
            var val = nums[i] % 2 == 0
                ? nums[i]
                : nums[i] * 2;
            pqMax.Enqueue(val, -val);
            pqMin.Enqueue(val, val);
        }

        var max = pqMax.Dequeue();
        var result = max - pqMin.Peek();

        // if the max is odd, then you cannout divide
        // by 2 and it will always be the max. However,
        // as the numbers converge, a max even divided
        // by 2 could become the new min.
        while (max % 2 == 0)
        {
            max /= 2;
            pqMax.Enqueue(max, -max);
            pqMin.Enqueue(max, max);
            max = pqMax.Dequeue();
            result = Math.Min(result, max - pqMin.Peek());
        }

        return result;
    }
}
