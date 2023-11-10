using LeetcodeGrind.Solutions;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var s = "abbcccaa";
        var sln = new P1759();
        var res = sln.CountHomogenous(s);
        Console.WriteLine(res);
    }

    private static void Print2DIntArray(int[][] arr)
    {
        foreach (var row in arr)
        {
            Console.WriteLine(string.Join(",", row));
        }
    }

    // TIP: Use this for jagged array declaration:
    // var array2D = Enumerable.Range(0, m).Select(x => new int[n]).ToArray();


}