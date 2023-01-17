using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heights = new int[5][];
            heights[0] = new int[] { 1, 2, 2, 3, 5 };
            heights[1] = new int[] { 3, 2, 3, 4, 4 };
            heights[2] = new int[] { 2, 4, 5, 3, 1 };
            heights[3] = new int[] { 6, 7, 1, 4, 5 };
            heights[4] = new int[] { 5, 1, 1, 2, 4 };

            var g = new Graphs.Graphs();
            var res = g.PacificAtlantic(heights);

            Console.WriteLine(string.Join(",", res));
        }
    }
}