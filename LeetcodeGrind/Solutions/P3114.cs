using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Solutions;


// 3114. Latest Time You Can Obtain After Replacing Characters
public class P3114
{
    public string FindLatestTime(string s)
    {
        var time = s.ToCharArray();

        if (time[0] == '?')
        {
            if (time[1] == '?' || time[1] == '0' || time[1] == '1')
                time[0] = '1';
            else
                time[0] = '0';
        }
        if (time[1] == '?')
        {
            if (time[0] == '1')
                time[1] = '1';
            else
                time[1] = '9';
        }
        if (time[3] == '?')
        {
            time[3] = '5';
        }
        if (time[4] == '?')
        {
            time[4] = '9';
        }

        return new string(time);
    }
}
