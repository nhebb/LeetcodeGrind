namespace LeetcodeGrind.Solutions;

// 65. Valid Number
public class P0065
{
    public bool IsNumber(string s)
    {
        if (string.IsNullOrEmpty(s))
            return false;

        s = s.ToLowerInvariant();
        if (s.Contains('e'))
        {
            var parts = s.Split('e');
            if (parts.Length > 2)
                return false;

            if (parts[0].Contains('.'))
                return IsValidFloat(parts[0]) && IsValidInteger(parts[1]);
            else if (parts[1].Contains('.'))
                return false;
            else
                return IsValidInteger(parts[0]) && IsValidInteger(parts[1]);
        }
        else if (s.Contains('.'))
        {
            return IsValidFloat(s);
        }
        else
        {
            return IsValidInteger(s);
        }
    }

    private static bool IsValidInteger(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return false;

        int numDigits = 0;
        int i = 0;

        if (s[0] == '-' || s[0] == '+')
            i++;

        while (i < s.Length)
        {
            if (char.IsDigit(s[i]))
                numDigits++;
            else
                return false;

            i++;
        }

        return numDigits > 0;
    }

    private static bool IsValidFloat(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return false;

        int numDigits = 0;
        int numDots = 0;
        int i = 0;

        if (s[0] == '-' || s[0] == '+')
            i++;

        while (i < s.Length)
        {
            if (char.IsDigit(s[i]))
                numDigits++;
            else if (s[i] == '.')
                numDots++;
            else
                return false;

            i++;
        }

        if (numDigits == 0 || numDots != 1)
            return false;

        return true;
    }
}
