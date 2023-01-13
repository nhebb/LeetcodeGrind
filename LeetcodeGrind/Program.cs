using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // { 0, 1 },[0, 2],[1, 4],[1, 5],[2, 3],[2, 6]
            //var g = new Greedy.Greedy();
            //var edges = new int[6][];
            //edges[0] = new int[] { 0, 1 };
            //edges[1] = new int[] { 0, 2 };
            //edges[2] = new int[] { 1, 4 };
            //edges[3] = new int[] { 1, 5 };
            //edges[4] = new int[] { 2, 3 };
            //edges[5] = new int[] { 2, 6 };

            //var labels = "abaedcd";

            //var res = g.CountSubTrees(7, edges, labels);

            var trees = new Trees.Trees();
            var parent = new int[] { -1, 0, 0, 0 };
            var s = "aabc";
            var res = trees.LongestPath(parent, s);
            Console.WriteLine(string.Join(", ", res));
        }
    }
}