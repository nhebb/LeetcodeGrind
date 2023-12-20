namespace LeetcodeGrind.Solutions;

// 1869. Longer Contiguous Segments of Ones than Zeros
public class P1869
{
    public bool CheckZeroOnes(string s)
    {
        var inOnes = false;
        var maxOnes = 0;
        var curOnes = 0;
        var maxZeros = 0;
        var curZeros = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                if (inOnes)
                {
                    curOnes++;
                }
                else
                {
                    inOnes = true;
                    curOnes = 1;
                }
                maxOnes = Math.Max(curOnes, maxOnes);
            }
            else
            {
                if (inOnes)
                {
                    inOnes = false;
                    curZeros = 1;
                }
                else
                {
                    curZeros++;
                }
                maxZeros = Math.Max(curZeros, maxZeros);
            }
        }

        return maxOnes > maxZeros;
    }
}
