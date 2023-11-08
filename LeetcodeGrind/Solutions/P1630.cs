namespace LeetcodeGrind.Solutions;

// 1630. Arithmetic Subarrays
public class P1630
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        var ans = new List<bool>();

        for (int i = 0; i < l.Length; i++)
        {
            var isArithmetic = true;
            var segment = nums.Skip(l[i]).Take(r[i] - l[i] + 1).OrderBy(x => x).ToArray();
            var delta = segment[1] - segment[0];
            for (int j = 1; j < segment.Count() - 1; j++)
            {
                if (segment[j + 1] - segment[j] != delta)
                {
                    isArithmetic = false;
                    break;
                }
            }
            ans.Add(isArithmetic);
        }

        return ans;
    }
}
