namespace LeetcodeGrind.Solutions;

// 13. Roman to Integer
public class P0013
{
    public int RomanToInt(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;

        var numerals = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

        var val = numerals[s[^1]];
        var maxVal = val;
        var i = s.Length - 2;

        while (i >= 0)
        {
            var numeralValue = numerals[s[i]];
            maxVal = Math.Max(maxVal, numeralValue);

            if (numeralValue >= maxVal)
                val += numeralValue;
            else
                val -= numeralValue;

            i--;
        }

        return val;
    }

    public int RomanToInt2(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;

        var numerals = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

        var val = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            var curVal = numerals[s[i]];
            var nextVal = numerals[s[i + 1]];

            if (curVal >= nextVal)
                val += curVal;
            else
                val -= curVal;
        }
        val += numerals[s[^1]];
        return val;
    }
}
