namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var g = new Graphs.Graphs();
            var edges = new int[6][];
            edges[0] = new int[] { 0, 1 };
            edges[1] = new int[] { 0, 2 };
            edges[2] = new int[] { 1, 4 };
            edges[3] = new int[] { 1, 5 };
            edges[4] = new int[] { 2, 3 };
            edges[5] = new int[] { 2, 6 };

            var hasApple = new List<bool>()
            {
                false, false, true, false, true, true, false
            };

            var res = g.MinTime(7, edges, hasApple);

            Console.WriteLine(res);
        }
    }
}