namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bt = new Backtracking.Backtracking();
            var candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            var target = 8;
            var res1 = bt.CombinationSum2(candidates, target);

            for (int i = 0; i < res1.Count; i++)
            {
                Console.WriteLine($"[{string.Join(",", res1[i])}]");
            }
        }
    }
}