using System.Text;

namespace LeetcodeGrind.Solutions;

// 2765. Longest Alternating Subarray
public class P2765
{
    public int AlternatingSubarray(int[] nums)
    {
        var signs = new char[nums.Length - 1];
        for (int i = 1; i < nums.Length; i++)
        {
            var diff = nums[i] - nums[i - 1];
            if (diff == 1)
                signs[i - 1] = '+';
            else if (diff == -1)
                signs[i - 1] = '-';
            else
                signs[i - 1] = ';';
        }

        var result = string.Join("", signs);
        while (result.Contains("++"))
        {
            result = result.Replace("++", "+;+");
        }
        while (result.Contains("--"))
        {
            result = result.Replace("--", "-;");
        }
        var parts = result.Split(';', StringSplitOptions.RemoveEmptyEntries);

        var max = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            var len = parts[i].Length;
            if (parts[i][0] == '-')
            {
                len--;
            }
            max = Math.Max(max, len);
        }
        max++;

        return max > 1 ? max : -1;
    }
}
