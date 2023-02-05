using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var s = "abacbabc";
        var p = "abc";
        var ah = new ArraysAndHashing.ArraysAndHashing();
        var res = ah.FindAnagrams(s, p);

        Console.WriteLine(string.Join(",",res));
    }
}