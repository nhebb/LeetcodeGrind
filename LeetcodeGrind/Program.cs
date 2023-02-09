using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var ideas = new string[] { "coffee", "donuts", "time", "toffee" };
        var ah = new ArraysAndHashing.ArraysAndHashing();
        var res = ah.DistinctNames(ideas);
        Console.WriteLine(res);
        // Console.WriteLine(string.Join(",",res));
    }
}