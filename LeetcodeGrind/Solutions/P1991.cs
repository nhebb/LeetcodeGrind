namespace LeetcodeGrind.Solutions;

// 1991. Find the Middle Index in Array
public class P1991
{
    public int FindMiddleIndex(int[] nums)
    {
        var n = nums.Length;
        if (n == 1)
            return 0;

        var pre = new int[nums.Length];
        var post = new int[nums.Length];

        pre[0] = nums[0];
        for (int i = 1; i < n; i++)
            pre[i] = pre[i - 1] + nums[i];

        post[^1] = nums[^1];
        for (int i = n - 2; i >= 0; i--)
            post[i] = post[i + 1] + nums[i];

        if (post[1] == 0)
            return 0;

        if (pre[^2] == 0)
            return n - 1;

        for (int i = 1; i < n - 1; i++)
            if (pre[i - 1] == post[i + 1])
                return i;

        return -1;
    }
}
