using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        // [[0,1],[0,2],[0,3]]
        var roads = new int[3][];
        roads[0] = new int[] { 0, 1 };
        roads[1] = new int[] { 0, 2 };
        roads[2] = new int[] { 0, 3 };
        var g = new Graphs.Graphs();
        var res = g.MinimumFuelCost(roads, 5);
        //Console.WriteLine(res);
        // Console.WriteLine(string.Join(",",res));
    }
}