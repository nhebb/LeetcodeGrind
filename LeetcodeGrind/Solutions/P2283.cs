namespace LeetcodeGrind.Solutions;

// 2283. Check if Number Has Equal Digit Count and Digit Value
public class P2283
{
    public bool DigitCount(string num)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < num.Length; i++)
        {
            var number = num[i] - '0';
            if (d.TryGetValue(number, out int count))
                d[number] = count + 1;
            else
                d[number] = 1;
        }

        for (int i = 0; i < num.Length; i++)
        {
            var count = d.ContainsKey(i) ? d[i] : 0;
            var val = num[i] - '0';
            if (val != count)
                return false;
        }
        return true;
    }
}
