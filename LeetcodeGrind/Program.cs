namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new int[] { 2, 2, 3, 3, 2, 4, 4, 4, 4, 4 };
            var ah = new ArraysAndHashing.ArraysAndHashing();
            var res = ah.MinimumRounds(tasks);
            Console.WriteLine(res);
        }   
    }
}