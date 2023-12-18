namespace LeetcodeGrind.Solutions;

// 2200. Find All K-Distant Indices in an Array
public class P2200
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        var hs = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == key)
            {
                for (int j = i - k; j <= i + k; j++)
                {
                    hs.Add(j);
                }
            }
        }

        return hs.OrderBy(x => x)
                 .Where(x => x >= 0 && x < nums.Length)
                 .ToList();
    }
}
