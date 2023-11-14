using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 476. Number Complement
public class P0476
{
    public int FindComplement(int num)
    {
        var sb = new StringBuilder();

        while (num > 0)
        {
            sb.Insert(0, (num & 1) == 1 ? 0 : 1);
            num /= 2;
        }

        return Convert.ToInt32(sb.ToString(), 2);
    }
}

