namespace LeetcodeGrind.Solutions;

// 491. Non-decreasing Subsequences
public class P0491
{
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var ans = new List<IList<int>>();
        var seq = new List<int>();
        var hs = new HashSet<string>();

        void Backtrack(int i)
        {
            for (int j = i; j < nums.Length; j++)
            {
                if (seq.Count == 0 || nums[j] >= seq[seq.Count - 1])
                {
                    seq.Add(nums[j]);
                    if (seq.Count >= 2)
                    {
                        var hash = string.Join(",", seq);
                        if (hs.Add(hash))
                            ans.Add(new List<int>(seq));
                    }
                    Backtrack(j + 1);
                    seq.RemoveAt(seq.Count - 1);
                }
            }
        }

        Backtrack(0);
        return ans;
    }
}
