namespace LeetcodeGrind.Solutions;

// 1663. Smallest String With A Given Numeric Value
public class P1663
{
    public string GetSmallestString(int n, int k)
    {
        var chars = new char[n];
        Array.Fill(chars, 'a');
        var sum = chars.Length;

        for (int i = chars.Length - 1; i >= 0; i--)
        {
            while (chars[i] - 'a' < 25 && sum < k)
            {
                chars[i]++;
                sum++;
            }
            if (sum == k)
                break;
        }

        return new string(chars);
    }
}
