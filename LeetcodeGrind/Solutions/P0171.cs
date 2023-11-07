namespace LeetcodeGrind.Solutions;

// 171. Excel Sheet Column Number
public class P0171
{
    public int TitleToNumber(string columnTitle)
    {
        var number = 0;
        var pow = 1;
        for (int i = columnTitle.Length - 1; i >= 0; i--)
        {
            number += (columnTitle[i] - 'A' + 1) * pow;
            pow *= 26;
        }

        return number;
    }
}
