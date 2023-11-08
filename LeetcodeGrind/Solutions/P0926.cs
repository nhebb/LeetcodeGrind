namespace LeetcodeGrind.Solutions;

// 926. Flip String to Monotone Increasing
public class P0926
{
    public int MinFlipsMonoIncr(string s)
    {
        var numZeroes = s.Count(c => c == '0');
        var numOnes = s.Length - numZeroes;
        var minFlips = Math.Min(numZeroes, numOnes);
        var rightZeroes = numZeroes;
        var leftOnes = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
                rightZeroes--;
            else
                leftOnes++;

            minFlips = Math.Min(minFlips, leftOnes + rightZeroes);
        }

        return minFlips;
    }
}
