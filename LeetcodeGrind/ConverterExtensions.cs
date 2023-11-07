using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind;

public static class ConverterExtensions
{
    public static char[] To1DCharArray(this string s)
    {
        var sq = "'";
        var dq = "\"";

        return s.Replace("[", "")
                .Replace("]", "")
                .Replace(dq, sq)
                .Replace(" ", "")
                .ToCharArray();
    }

    public static int[] To1DIntArray(this string s)
    {
        var values = s.Replace("[", "")
                      .Replace("]", "")
                      .Split(',', StringSplitOptions.RemoveEmptyEntries);

        return Array.ConvertAll<string, int>(values, int.Parse);
    }

    public static int[][] To2DIntArray(this string s)
    {
        var rows = s.Replace("[[", "")
                    .Replace("]]", "")
                    .Split("],[");

        var array2D = new int[rows.Length][];

        for (int i = 0; i < rows.Length; i++)
        {
            var columnValues = rows[i].Split(",");
            array2D[i] = Array.ConvertAll<string, int>(columnValues, int.Parse);
        }

        return array2D;
    }

}
