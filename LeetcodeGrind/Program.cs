using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var edges = new int[] { 1, 2, -1 };
            var node1 = 0;
            var node2 = 2;

            var g = new Graphs.Graphs();
            var res = g.ClosestMeetingNode(edges, node1, node2);
            Console.WriteLine(res);
        }
    }
}