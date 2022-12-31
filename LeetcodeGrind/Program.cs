namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bt = new Backtracking.Backtracking();
            var res1 = bt.Combine(6, 3);
            var res2 = bt.Combine2(6, 3);

            Console.WriteLine(res1.Count + " " + res2.Count);

            for (int i = 0; i < res1.Count; i++)
            {
                Console.WriteLine($"{string.Join(",", res1[i])}\t\t{string.Join(",", res2[i])}");

            }
        }
    }
}