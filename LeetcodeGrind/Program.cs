using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var fruits = new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 };
        var sw = new SlidingWindow.SlidingWindow();
        var res = sw.TotalFruit(fruits);

        Console.WriteLine(res);
    }
}