namespace LeetcodeGrind.Solutions;

// 1652. Defuse the Bomb
public class P1652
{
    public int[] Decrypt(int[] code, int k)
    {
        var n = code.Length;
        var sums = new int[n];

        if (k > 0)
        {
            for (int i = 0; i < code.Length; i++)
            {
                var sum = 0;
                for (int j = i + 1; j <= i + k; j++)
                {
                    var index = j % n;
                    sum += code[index];
                }
                sums[i] = sum;
            }
        }
        else if (k < 0)
        {
            for (int i = 0; i < code.Length; i++)
            {
                var sum = 0;
                for (int j = i - 1; j >= i + k; j--)
                {
                    var index = j < 0 ? n + j : j;
                    sum += code[index];
                }
                sums[i] = sum;
            }
        }
        return sums;
    }
}

