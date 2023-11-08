namespace LeetcodeGrind.Solutions;

// 2572. Count the Number of Square-Free Subsets
public class P2572
{
    public int SquareFreeSubsets(int[] nums)
    {
        var squareFreeNums = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if ((nums[i] & (nums[i] - 1)) != 0)
                squareFreeNums.Add(nums[i]);
        }

        var subset = new List<int>();
        var count = 0;

        void Backtrack(int i)
        {
            if (i == squareFreeNums.Count)
            {
                if (subset.Count > 0)
                    count++;
                return;
            }

            subset.Add(squareFreeNums[i]);
            Backtrack(i + 1);
            subset.RemoveAt(subset.Count - 1);

            Backtrack(i + 1);
        }

        Backtrack(0);
        return count;
    }
}
