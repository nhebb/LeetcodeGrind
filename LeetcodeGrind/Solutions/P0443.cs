namespace LeetcodeGrind.Solutions;

// 443. String Compression
public class P0443
{
    public int Compress(char[] chars)
    {
        var i = 0;
        var j = 1;
        var k = 0;

        while (j < chars.Length)
        {
            chars[k] = chars[i];
            k++;

            while (j < chars.Length && chars[i] == chars[j])
                j++;
            var numDigits = j - i;
            if (numDigits > 1)
            {
                var digits = numDigits.ToString();
                var len = digits.Length;
                for (int m = 0; m < len; m++)
                {
                    chars[k] = digits[m];
                    k++;
                }
            }

            i = j;
            j = i + 1;
        }

        if (i == chars.Length - 1)
        {
            chars[k] = chars[i];
            k++;
        }

        return k;
    }
}
