namespace LeetcodeGrind.Solutions;

// 2824. Count Pairs Whose Sum is Less than Target
public class P2824
{
    public int CountPairs(IList<int> nums, int target)
    {
        var count = 0;

        // nums.Count <= 50, so O(n^2) is fine.
        for (int i = 0; i < nums.Count - 1; i++)
        {
            for (int j = i + 1; j < nums.Count; j++)
            {
                if (nums[i] + nums[j] < target)
                    count++;
            }
        }

        return count;
    }
}
