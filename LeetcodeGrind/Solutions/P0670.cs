namespace LeetcodeGrind.Solutions;

// 670. Maximum Swap
public class P0670
{
    public int MaximumSwap(int num)
    {
        var max = num;
        var digits = num.ToString().ToCharArray();

        for (int i = 0; i < digits.Length - 1; i++)
        {
            var maxDigit = digits[i];
            for (int j = i + 1; j < digits.Length; j++)
            {
                if (digits[j] > digits[i])
                {
                    (digits[i], digits[j]) = (digits[j], digits[i]);
                    var curMax = int.Parse(string.Join("", digits));
                    max = Math.Max(max, curMax);
                    (digits[j], digits[i]) = (digits[i], digits[j]);
                }
            }

        }

        return max;
    }
}
