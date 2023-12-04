namespace LeetcodeGrind.Solutions;

// 2264. Largest 3-Same-Digit Number in String
public class P2264
{
    public string LargestGoodInteger(string num)
    {
        var largest = int.MinValue;

        for (int i = 0; i < num.Length - 2; i++)
        {
            if (num[i] == num[i + 1] && num[i] == num[i + 2])
            {
                var value = int.Parse(num.Substring(i, 3));
                largest = Math.Max(largest, value);
            }
        }

        return largest == int.MinValue
            ? ""
            : largest.ToString("000");
    }
}
