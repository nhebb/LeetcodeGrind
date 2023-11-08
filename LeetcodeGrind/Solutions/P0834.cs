namespace LeetcodeGrind.Solutions;

// 834. Sum of Distances in Tree
// TODO: Finish this.
public class P0834
{
    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        var d = new Dictionary<int, int[]>();
        var counts = new int[n];
        var totalCount = 0;
        var targetCount = n * (n - 1);

        for (int i = 0; i < n; i++)
            d[i] = new int[n];


        foreach (var edge in edges)
        {
            d[edge[0]][edge[1]] = 1;
            d[edge[1]][edge[0]] = 1;
            counts[edge[0]]++;
            counts[edge[1]]++;
            totalCount += 2;
        }

        while (totalCount < targetCount)
        {

        }

        // sum up arrays for each of the nodes
        var ans = new int[n];
        for (int i = 0; i < n; i++)
            ans[i] = d[i].Sum();

        return ans;
    }
}
