using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Heaps;

public class Heaps
{
    private class MaxDoubleComparer : IComparer<double>
    {
        public int Compare(double a, double b)
        {
            return b.CompareTo(a);
        }
    }

    // 973. K Closest Points to Origin
    public int[][] KClosest(int[][] points, int k)
    {
        // After review, this code sucks. I should have used a min heap
        // instead of a max heap. Calculating the sqrt wasn't necessary,
        // since it's used for comparison.
        var pq = new PriorityQueue<int[], double>(new MaxDoubleComparer());

        foreach (var pt in points)
        {
            double r = Math.Sqrt((double)(pt[0] * pt[0] + pt[1] * pt[1]));
            pq.Enqueue(pt, r);
        }

        while (pq.Count > k)
            _ = pq.Dequeue();

        var result = new int[k][];
        for (int i = 0; i < k; i++)
            result[i] = pq.Dequeue();

        return result;

    }
    // Better solution w/o PQ
    public int[][] KClosest2(int[][] points, int k)
    {
        return points.OrderBy(p => p[0] * p[0] + p[1] * p[1])
                     .Take(k)
                     .ToArray();
    }
}
