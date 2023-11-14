namespace LeetcodeGrind.Solutions;

// 8. String to Integer (atoi)
public class P0008
{
    public int MyAtoi(string str)
    {
        if (string.IsNullOrWhiteSpace(str)) { return 0; }

        str = str.TrimStart();

        var i = 0;
        bool neg = false;
        if (str[i] == '-')
        {
            neg = true;
            i++;
        }
        else if (str[i] == '+')
        {
            i++;
        }

        if (i >= str.Length || !char.IsDigit(str[i]))
            return 0;

        double num = (double)(str[i] - '0');
        i++;

        while (i < str.Length && char.IsDigit(str[i]))
        {
            num = (num * 10) + (str[i] - '0');
            i++;
        }

        if (neg)
        {
            num *= -1;
            return num < int.MinValue
                ? int.MinValue
                : (int)num;
        }

        return num > int.MaxValue
            ? int.MaxValue
            : (int)num;
    }
}
