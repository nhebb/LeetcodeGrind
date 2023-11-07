using System.Text;

namespace LeetcodeGrind.Solutions;

// 12. Integer to Roman
public class P0012
{
    public string IntToRoman(int num)
    {
        var thousands = new string[] { "", "M", "MM", "MMM" };
        var hundreds = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        var tens = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        var ones = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        var sb = new StringBuilder();

        sb.Append(thousands[num / 1000]);

        num %= 1000;
        sb.Append(hundreds[num / 100]);

        num %= 100;
        sb.Append(tens[num / 10]);

        num %= 10;
        sb.Append(ones[num]);

        return sb.ToString();
    }
}
