using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var prices = new int[] { 7, 1, 5, 3, 6, 4 };
        var ah = new ArraysAndHashing.ArraysAndHashing();
        var res = ah.MaxProfit(prices);
        Console.WriteLine(res);
        // Console.WriteLine(string.Join(",",res));
    }
}