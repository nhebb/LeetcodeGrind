namespace LeetcodeGrind.Solutions;

// 18. 4Sum
public class P0018
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var ans = new List<IList<int>>();
        if (nums.Length < 4)
            return ans;

        Array.Sort(nums);
        var indices = new HashSet<string>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                int k = j + 1;
                int l = nums.Length - 1;
                while (k < l)
                {
                    long diff = (long)nums[i] + nums[j] + nums[k] + nums[l] - target;
                    if (diff == 0)
                    {
                        if (indices.Add($"{nums[i]},{nums[j]},{nums[k]},{nums[l]}"))
                        {
                            ans.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                        }
                        k++;
                        l--;
                    }
                    else if (diff < 0)
                        k++;
                    else
                        l--;
                }
            }
        }

        return ans;
    }
}
