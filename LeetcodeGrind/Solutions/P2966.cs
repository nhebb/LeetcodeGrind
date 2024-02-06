namespace LeetcodeGrind.Solutions;

// 2966. Divide Array Into Arrays With Max Difference
public class P2966
{
    public int[][] DivideArray(int[] nums, int k)
    {
        var ans = new int[nums.Length / 3][];

        Array.Sort(nums);
        var j = 0;

        for (int i = 0; i <= nums.Length - 3; i += 3)
        {
            ans[j] = new int[] { nums[i], nums[i + 1], nums[i + 2] };

            if (ans[j][2] - ans[j][0] > k)
            {
                return [];
            }

            j++;
        }

        return ans;
    }

    // LINQ - slower than original
    public int[][] DivideArrayLINQ(int[] nums, int k)
    {
        var ans = new List<int[]>(nums.Length / 3);

        Array.Sort(nums);
        var skip = 0;
        while (skip <= nums.Length - 3)
        {
            ans.Add(nums.Skip(skip).Take(3).ToArray());
            if (ans[^1][2] - ans[^1][0] > k)
            {
                return [];
            }
            skip += 3;
        }

        return [.. ans];
    }
}
