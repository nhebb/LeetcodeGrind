namespace LeetcodeGrind.Solutions;

// 2269. Find the K-Beauty of a Number
public class P2269
{
    public int DivisorSubstrings(int num, int k)
    {
        var count = 0;
        var sNum = num.ToString();

        for (int i = 0; i <= sNum.Length - k; i++)
        {
            var subStr = sNum.Substring(i, k);
            var val = int.Parse(subStr);
            if (val != 0 && num % val == 0)
            {
                count++;
            }
        }

        return count;
    }
}
