namespace LeetcodeGrind.Solutions;

// 1945. Sum of Digits of String After Convert
public class P1945
{
    public int GetLucky(string s, int k)
    {
        var nums = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            nums[i] = s[i] - 'a' + 1;
        }

        var numStr = new string[k + 1];
        numStr[0] = string.Join("", nums);

        var sum = 0;
        for (int i = 0; i < numStr.Length - 1; i++)
        {
            sum = 0;
            for (int j = 0; j < numStr[i].Length; j++)
            {
                sum += numStr[i][j] - '0';
            }
            numStr[i + 1] = sum.ToString();
        }

        return sum;
    }
}
