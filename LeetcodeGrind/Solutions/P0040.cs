namespace LeetcodeGrind.Solutions;

// 40. Combination Sum II
public class P0040
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var ans = new List<IList<int>>();
        var combo = new List<int>();

        void BackTrackSum(int i, int sum)
        {
            for (int j = i; j < candidates.Length; j++)
            {
                if (j > i && candidates[j] == candidates[j - 1])
                    continue;

                combo.Add(candidates[j]);
                sum += candidates[j];

                if (sum == target)
                    ans.Add(new List<int>(combo));
                else if (sum < target)
                    BackTrackSum(j + 1, sum);

                sum -= candidates[j];
                combo.RemoveAt(combo.Count - 1);
            }
        }

        BackTrackSum(0, 0);
        return ans;
    }
}
