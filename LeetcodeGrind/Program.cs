using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var grid = new int[3][];
        grid[0] = new int[] { 1, 0, 0 };
        grid[1] = new int[] { 0, 0, 0 };
        grid[2] = new int[] { 0, 0, 0 };

        var dp = new DynamicProgramming.DynamicProgramming();
        var res = dp.MaxDistance(grid);
        Console.WriteLine(res);
        // Console.WriteLine(string.Join(",",res));
    }
}