using System.ComponentModel.Design;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var wd = new Tries.WordDictionary();

        wd.AddWord("bad");
        wd.AddWord("dad");
        wd.AddWord("mad");

        var res1 = wd.Search("pad");
        var res2 = wd.Search("bad");
        var res3 = wd.Search(".ad");
        var res4 = wd.Search("b..");

        Console.WriteLine(res1);
        Console.WriteLine(res2);
        Console.WriteLine(res3);
        Console.WriteLine(res4);
    }
}