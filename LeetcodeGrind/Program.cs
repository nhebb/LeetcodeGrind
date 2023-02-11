using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var nums = new int[] { 3, 1, 5, 8 };

        var dp = new DynamicProgramming.DynamicProgramming();
        var res = dp.MaxCoins(nums);
        Console.WriteLine(res);
        // Console.WriteLine(string.Join(",",res));
    }
}