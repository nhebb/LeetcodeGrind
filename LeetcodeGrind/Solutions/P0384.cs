namespace LeetcodeGrind.Solutions.ShuffleArray;

// 384. Shuffle an Array
public class Solution
{
    int[] _nums;
    Random _rand;

    public Solution(int[] nums)
    {
        _nums = nums;
        _rand = new Random();
    }

    public int[] Reset()
    {
        return _nums;
    }

    // Fisher-Yates shuffle
    public int[] Shuffle()
    {
        var ans = new int[_nums.Length];
        _nums.CopyTo(ans, 0);
        var n = ans.Length;

        while (n > 1)
        {
            n--;
            var k = _rand.Next(n + 1);
            (ans[k], ans[n]) = (ans[n], ans[k]);
        }

        return ans;
    }
}