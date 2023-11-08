namespace LeetcodeGrind.Solutions;

// 39. Combination Sum
public class P0039
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var ans = new List<IList<int>>();
        var combo = new List<int>();

        void BackTrackSum(int start, int sum)
        {
            combo.Add(candidates[start]);
            sum += candidates[start];
            if (sum == target)
            {
                ans.Add(new List<int>(combo));
            }
            else if (sum < target)
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    BackTrackSum(i, sum);
                }
            }
            sum -= candidates[start];
            combo.RemoveAt(combo.Count - 1);
        }

        for (int i = 0; i < candidates.Length; i++)
        {
            BackTrackSum(i, 0);
        }

        return ans;
    }
}
