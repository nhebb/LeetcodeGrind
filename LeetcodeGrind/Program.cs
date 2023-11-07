using LeetcodeGrind.Solutions;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var dist = "[3]".To1DIntArray();
        var speed = "[5]".To1DIntArray();
        var sln = new P1921();
        var res = sln.EliminateMaximum(dist, speed);
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