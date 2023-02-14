using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var n = 9;

        var res = 1;
        while (n > 0)
        {
            res *= n;
            n--;
        }
        //int[] nums = { 1,2,12 };
        //var ah = new ArraysAndHashing.ArraysAndHashing();
        //var res = ah.CheckSubarraySum(nums, 7);
        Console.WriteLine(res);
        // Console.WriteLine(string.Join(",",res));

        //CalcLCPerDay();
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
        Console.WriteLine($"You must solve {problemsPerDay} problems per day to meet the target.");
    }
}