using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {

        var nums = new int[] { 7,4,3,9,1,8,5,2,6};
        var k = 3;
        var sw = new SlidingWindow.SlidingWindow();
        var res = sw.GetAverages(nums,k);
        //Console.WriteLine(res);

        Console.WriteLine(string.Join(", ", res));

        //CalcLCPerDay();
    }


    private static char[] Leetcode1DCharArray(string s)
    {
        var sq = "'";
        var dq = "\"";
        s = s.Replace("[", "").Replace("]", "");
        s = s.Replace(dq, sq).Replace(" ", ""); ;
        return s.ToCharArray();
    }

    private static int[] Leetcode1DIntArray(string s)
    {
        s = s.Replace("[", "").Replace("]", "");
        var parts = s.Split(',', StringSplitOptions.RemoveEmptyEntries);

        var result = new List<int>();
        foreach (var part in parts)
            result.Add(int.Parse(part));
        return result.ToArray();
    }

    private static int[][] ConvertTo2DIntArray(string s)
    {
        s = s.Replace("[[", "");
        s = s.Replace("]]", "");
        s = s.Replace("],[", ";");

        var parts = s.Split(';');
        var res = new int[parts.Length][];
        for (int i = 0; i < parts.Length; i++)
        {
            var vals = parts[i].Split(",");
            res[i] = new int[vals.Length];
            for (int j = 0; j < vals.Length; j++)
                res[i][j] = int.Parse(vals[j]);
        }

        return res;
    }

    private static void Print2DIntArray(int[][] arr)
    {
        foreach (var row in arr)
        {
            Console.WriteLine(string.Join(",", row));
        }
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