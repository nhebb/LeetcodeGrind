namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var greedy = new Greedy.Greedy();
            var nums = new int[] { 2, 3, 1, 1, 4 };
            Console.WriteLine(greedy.Jump(nums));
        }
    }
}