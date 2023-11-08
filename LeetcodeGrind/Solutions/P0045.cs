namespace LeetcodeGrind.Solutions;

// 45. Jump Game II
public class P0045
{
    public int Jump(int[] nums)
    {
        if (nums.Length == 1) return 0;

        var jumps = 0;
        var maxJumps = nums.Max();
        var target = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            var minIndex = Math.Max(0, i - maxJumps);
            var nextTarget = target;
            for (int j = i; j >= minIndex; j--)
            {
                if (nums[j] + j >= target)
                {
                    i = j;
                    nextTarget = j;
                }
            }
            target = nextTarget;
            jumps++;
        }
        return jumps;
    }
}
