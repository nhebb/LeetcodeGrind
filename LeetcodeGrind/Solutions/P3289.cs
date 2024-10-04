namespace LeetcodeGrind.Solutions;

// 3289. The Two Sneaky Numbers of Digitville
public class P3289
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        var hs = new HashSet<int>(nums.Length - 2);
        var i = 0;
        var ans = new int[2];
        foreach (var num in nums)
        {
            if (!hs.Add(num))
            {
                ans[i] = num;
                i++;
            }
        }

        return ans;
    }
}
