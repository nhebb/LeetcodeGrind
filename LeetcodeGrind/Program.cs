namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var edges = new List<IList<int>>();
            edges.Add(new List<int>() { 0, 1 });
            edges.Add(new List<int>() { 0, 2 });
            edges.Add(new List<int>() { 2, 5 });
            edges.Add(new List<int>() { 3, 4 });
            edges.Add(new List<int>() { 4, 2 });
            var n = 6;
            var graphs = new Graphs.Graphs();
            var ans = graphs.FindSmallestSetOfVertices(n, edges);
            Console.WriteLine(string.Join(", ", ans));
        }
    }
}