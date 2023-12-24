namespace LeetcodeGrind.Solutions;

// 1758. Minimum Changes To Make Alternating Binary String
public class P1758
{
    public int MinOperations(string s)
    {
        var ops1 = 0;
        var ops2 = 0;
        var needOne = true;
        var needZero = true;

        for (int i = 0; i < s.Length; i++)
        {
            // One-first track
            var isOne = s[i] == '1';
            if (needOne && !isOne || !needOne && isOne)
            {
                ops1++;
            }

            // Zero-first track
            var isZero = !isOne;
            if (needZero && !isZero || !needZero && isZero)
            {
                ops2++;
            }

            needOne = !needOne;
            needZero = !needZero;
        }

        return Math.Min(ops1, ops2);
    }
}
