namespace LeetcodeGrind.Solutions;

// 1736. Latest Time by Replacing Hidden Digits
public class P1736
{
    public string MaximumTime(string time)
    {
        var result = new char[5];
        if (time[0] == '?')
        {
            if (time[1] == '?')
            {
                result[0] = '2';
                result[1] = '3';
            }
            else if (time[1] - '0' <= 3)
            {
                result[0] = '2';
                result[1] = time[1];
            }
            else
            {
                result[0] = '1';
                result[1] = time[1];

            }
        }
        else
        {
            result[0] = time[0];
            if (time[1] == '?')
            {
                if (result[0] == '2')
                {
                    result[1] = '3';
                }
                else
                {
                    result[1] = '9';
                }
            }
            else
            {
                result[1] = time[1];
            }
        }

        result[2] = ':';
        result[3] = time[3] == '?' ? '5' : time[3];
        result[4] = time[4] == '?' ? '9' : time[4];

        return string.Join("", result);
    }
}
