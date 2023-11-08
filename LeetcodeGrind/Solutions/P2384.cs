using System.Text;

namespace LeetcodeGrind.Solutions;

// 2384. Largest Palindromic Number
public class P2384
{
    public string LargestPalindromic(string num)
    {
        var nums = new int[10];
        foreach (var c in num)
            nums[c - '0']++;

        var maxSingle = -1;
        var sb = new StringBuilder();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            while (nums[i] > 1)
            {
                if (i > 0)
                    sb.Append(i);
                else
                    break;

                nums[i] -= 2;
            }

            if (nums[i] > 0)
                maxSingle = Math.Max(maxSingle, i);
        }

        if (sb.Length == 0)
            return maxSingle.ToString();

        var sVal = sb.ToString();

        if (maxSingle >= 0)
            sVal = sVal + maxSingle.ToString() + string.Join("", sVal.Reverse());
        else
            sVal = sVal + string.Join("", sVal.Reverse());

        return sVal;
    }
}
