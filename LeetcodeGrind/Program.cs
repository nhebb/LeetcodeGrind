using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" };
            var tries = new Tries.Tries();
            var res = tries.FindAllConcatenatedWordsInADict(words);
            Console.WriteLine(string.Join(", ", res));
        }
    }
}