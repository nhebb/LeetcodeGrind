namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "Hello", "Alaska", "Dad", "Peace" };
            var strings = new Strings.Strings();
            var res = string.Join(", ", strings.FindWords(words));
            Console.WriteLine(res);
        }
    }
}