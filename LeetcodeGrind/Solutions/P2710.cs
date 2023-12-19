namespace LeetcodeGrind.Solutions;

// 2710. Remove Trailing Zeros From a String
public class P2710
{
    public string RemoveTrailingZeros(string num)
    {
        var len = num.Length;
        while (len > 0 && num[len - 1] == '0')
            len--;

        return num.Substring(0, len);
    }
}
