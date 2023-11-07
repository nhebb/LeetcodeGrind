using LeetcodeGrind.Solutions;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var input = "[2,1,3,5,4,6,7]";
        var arr = input.To1DIntArray();
        var sln = new P1535();
        var res = sln.GetWinner(arr, 2);
        Console.WriteLine(res);
    }

    private static void Print2DIntArray(int[][] arr)
    {
        foreach (var row in arr)
        {
            Console.WriteLine(string.Join(",", row));
        }
    }

}