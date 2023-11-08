namespace LeetcodeGrind.Solutions;

// 78. Subsets
public class P0078
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var subsets = new List<IList<int>>();
        var subset = new List<int>();

        void Backtrack(int i)
        {
            if (i == nums.Length)
            {
                subsets.Add(new List<int>(subset));
                return;
            }

            subset.Add(nums[i]);
            Backtrack(i + 1);
            subset.RemoveAt(subset.Count - 1);

            Backtrack(i + 1);
        }

        Backtrack(0);
        return subsets;
    }

}
