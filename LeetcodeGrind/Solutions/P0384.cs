namespace LeetcodeGrind.Solutions;

// 384. Shuffle an Array
public class Solution
{
    int[] _nums;
    int[] _ans;
    Random _rand;

    public Solution(int[] nums)
    {
        _nums = nums;
        _ans = new int[nums.Length];
        _rand = new Random();
    }

    public int[] Reset()
    {
        return _nums;
    }

    public int[] Shuffle()
    {
        var hs = new HashSet<int>();
        var i = 0;
        while (i < _nums.Length)
        {
            var index = _rand.Next(0, _nums.Length);
            while (hs.Contains(index))
            {
                index = _rand.Next(0, _nums.Length);
            }
            _ans[i] = _nums[index];
            hs.Add(index);
            i++;
        }
        return _ans;
    }
}