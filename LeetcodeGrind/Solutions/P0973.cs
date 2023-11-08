namespace LeetcodeGrind.Solutions;

// 973. K Closest Points to Origin
public class P0973
{
    public int[][] KClosest(int[][] points, int k)
    {
        var pq = new PriorityQueue<int[], double>();

        foreach (var pt in points)
        {
            double rSquared = pt[0] * pt[0] + pt[1] * pt[1];
            pq.Enqueue(pt, rSquared);
        }

        var result = new int[k][];
        for (int i = 0; i < k; i++)
            result[i] = pq.Dequeue();

        return result;
    }

    // Easy solution w/o PQ
    public int[][] KClosestLinq(int[][] points, int k)
    {
        return points.OrderBy(p => p[0] * p[0] + p[1] * p[1])
                     .Take(k)
                     .ToArray();
    }
}
