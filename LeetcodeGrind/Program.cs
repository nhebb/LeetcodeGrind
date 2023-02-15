using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var grid = new int[2][];
        grid[0] = new int[] { 20, 3, 20, 17, 2, 12, 15, 17, 4, 15 };
        grid[1] = new int[] { 20, 10, 13, 14, 15, 5, 2, 3, 14, 3 };
        var m = new Matrices.Matrices();
        var res = m.GridGame(grid);

        //var board = new string[] { "XXX", "OOX", "OOX" };
        //var ah = new ArraysAndHashing.ArraysAndHashing();
        //var res = ah.ValidTicTacToe(board);
        Console.WriteLine(res);
        //Console.WriteLine(string.Join(",", res));

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
        var problemsPerMonth = Math.Round(30 * (1000 - solved) / ((double)ts.Days), 2);
        var message = $"You must solve {problemsPerDay} problems per day" +
            $" ({problemsPerMonth} per month) to meet the target.";
        Console.WriteLine(message);
    }
}