namespace LeetcodeGrind.Solutions;

// 3270. Find the Key of the Numbers
public class P3270
{
    public int GenerateKey(int num1, int num2, int num3)
    {
        var s1 = num1.ToString("0000");
        var s2 = num2.ToString("0000");
        var s3 = num3.ToString("0000");

        var result = 0;
        for (int i = 0; i < 4; i++)
        {
            var val = Math.Min(s1[i] - '0', Math.Min(s2[i] - '0', s3[i] - '0'));
            result = 10 * result + val;
        }

        return result;
    }
}
