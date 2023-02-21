using LeetcodeGrind.Trees;
using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        //var input = "[[1,4],[4,7],[3,6]]";
        //var intervals = Leetcode2DArray(input);
        //var iv = new Intervals.Intervals();
        //var res = iv.RemoveCoveredIntervals(intervals);
        //Console.WriteLine(res);
        //Console.WriteLine(string.Join(",", res));

        CalcLCPerDay();

    }

    private static int[][] Leetcode2DArray(string s)
    {
        //[[1,4],[3,6],[2,8]]

        s = s.Replace("[[", "");
        s = s.Replace("]]", "");
        s = s.Replace("],[", ";");

        var parts = s.Split(';');
        var res = new int[parts.Length][];
        for (int i = 0; i < parts.Length; i++)
        {
            res[i] = new int[parts[i].Length];
            var vals = parts[i].Split(",");
            for (int j = 0; j < vals.Length; j++)
                res[i][j] = int.Parse(vals[j]);
        }

        return res;
    }


    // Calculate the number of Leetcode problems / day 
    // to hit the 1000 problems nilestone 1 year after
    // starting the current session.
    private static void CalcLCPerDay()
    {
        var today = DateTime.Now;
        var lcAnniversary = new DateTime(2023, 7, 27);
        var ts = lcAnniversary - today;

        Console.WriteLine("Input the number of LC problems solved:");
        if (!int.TryParse(Console.ReadLine(), out var solved))
        {
            Console.WriteLine("Invalid entry.");
            return;
        }

        var problemsPerDay = Math.Round((1000 - solved) / (double)ts.Days, 2);
        var problemsPerMonth = Math.Round(30 * (1000 - solved) / ((double)ts.Days), 2);
        var message = $"You must solve {problemsPerDay} problems per day" +
            $" ({problemsPerMonth} per month) to meet the target.";
        Console.WriteLine(message);
    }
}