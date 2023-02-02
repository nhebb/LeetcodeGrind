using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        //var words = new string[] { "kuvp", "q" };
        //var order = "ngxlkthsjuoqcpavbfdermiywz";
        //var ah = new ArraysAndHashing.ArraysAndHashing();
        //var res = ah.IsAlienSorted(words, order);
        var s = new Strings.Strings();
        var res = s.ThousandSeparator(685);
        Console.WriteLine(res);
    }
}