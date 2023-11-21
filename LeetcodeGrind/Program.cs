using LeetcodeGrind.Solutions;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {

        // problem 2642
        //var edges =
        //"[[7,2,131570],[9,4,622890],[9,1,812365],[1,3,399349],[10,2,407736],[6,7,880509],[1,4,289656],[8,0,802664],[6,4,826732],[10,3,567982],[5,6,434340],[4,7,833968],[12,1,578047],[8,5,739814],[10,9,648073],[1,6,679167],[3,6,933017],[0,10,399226],[1,11,915959],[0,12,393037],[11,5,811057],[6,2,100832],[5,1,731872],[3,8,741455],[2,9,835397],[7,0,516610],[11,8,680504],[3,11,455056],[1,0,252721]]".To2DIntArray();

        //var sln = new P2642.Graph(n, edges);

        //Console.WriteLine(sln.ShortestPath(9, 3));
        //sln.AddEdge(new int[] { 11, 1, 873094 });
        //Console.WriteLine(sln.ShortestPath(3, 10));
        //sln.AddEdge(new int[] { 0, 9, 601498 });
        //sln.AddEdge(new int[] { 12, 0, 824080 });
        //sln.AddEdge(new int[] { 12, 4, 459292 });
        //sln.AddEdge(new int[] { 6, 9, 7876 });
        //sln.AddEdge(new int[] { 11, 7, 5479 });
        //sln.AddEdge(new int[] { 11, 12, 802 });
        //Console.WriteLine(sln.ShortestPath(2, 9));
        //Console.WriteLine(sln.ShortestPath(2, 6));
        //sln.AddEdge(new int[] { 0, 11, 441770 });
        //Console.WriteLine(sln.ShortestPath(3, 7));
        //sln.AddEdge(new int[] { 11, 0, 393443 });
        //Console.WriteLine(sln.ShortestPath(4, 2));
        //sln.AddEdge(new int[] { 10, 5, 338 });
        //sln.AddEdge(new int[] { 6, 1, 305 });
        //sln.AddEdge(new int[] { 5, 0, 154 });
    }

    private static void Print2DIntArray(int[][] arr)
    {
        foreach (var row in arr)
        {
            Console.WriteLine(string.Join(",", row));
        }
    }

    // TIP: Use this for jagged array declaration:
    // var array2D = Enumerable.Range(0, m).Select(x => new int[n]).ToArray();


}