using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Solutions;

// 3090. Maximum Length Substring With Two Occurrences
public class P3090
{
    public int MaximumLengthSubstring(string s)
    {
        var d = new Dictionary<char, int>();
        var i = 0;
        var max = 0;

        for (int j = 0; j < s.Length; j++)
        {
            if (d.TryGetValue(s[j], out int value))
            {
                d[s[j]] = ++value;
            }
            else
            {
                d[s[j]] = 1;
            }

            while (d[s[j]] > 2)
            {

                d[s[i]]--;
                i++;
            }
            max = Math.Max(max, j - i + 1);
        }

        return max;
    }
}
