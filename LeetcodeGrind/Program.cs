using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var mat = new int[3][];
        mat[0] = new int[] { 1, 2, 3 };
        mat[1] = new int[] { 4, 5, 6 };
        mat[2] = new int[] { 7, 8, 9 };

        var m = new Matrices.Matrices();
        var res = m.FindDiagonalOrder2(mat);

        Console.WriteLine(string.Join(",", res));
    }
}