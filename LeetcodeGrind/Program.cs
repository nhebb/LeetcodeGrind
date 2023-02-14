using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 2, 4, 6 };
        var operations = new int[3][];
        operations[0] = new int[] { 1, 3 };
        operations[1] = new int[] { 4, 7 };
        operations[2] = new int[] { 6, 1 };
        var ah = new ArraysAndHashing.ArraysAndHashing();
        var res = ah.ArrayChange(nums, operations);
        //Console.WriteLine(res);
        Console.WriteLine(string.Join(",", res));

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