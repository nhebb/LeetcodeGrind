using System.Text;

namespace LeetcodeGrind.Solutions;

// 504. Base 7
public class P0504
{
    public string ConvertToBase7(int num)
    {
        if (num == 0)
            return "0";

        var sign =  "";
        if (num < 0)
        {
            sign = "-";
            num = -num;
        }

        var sb = new StringBuilder();
        while (num > 0)
        {
            sb.Insert(0, num % 7);
            num /= 7;
        }

        return sign + sb.ToString();
    }
}
