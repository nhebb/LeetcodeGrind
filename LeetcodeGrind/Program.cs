using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "catsanddog";
            var wordDict = new string[] { "cat", "cats", "and", "sand", "dog" };
            var tries = new Tries.Tries();
            var res = tries.WordBreakII(s, wordDict);
            Console.WriteLine(string.Join(", ", res));
        }
    }
}