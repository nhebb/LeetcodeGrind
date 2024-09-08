namespace LeetcodeGrind.Solutions;

// 624. Maximum Distance in Arrays
public class P0624
{
    public int MaxDistance(IList<IList<int>> arrays)
    {
        var pqMin = new PriorityQueue<(int val, int index), int>(arrays.Count);
        var pqMax = new PriorityQueue<(int val, int index), int>(arrays.Count);

        for (int i = 0; i < arrays.Count; i++)
        {
            var min = arrays[i][0];
            pqMin.Enqueue((min, i), min);

            var max = arrays[i][^1];
            pqMax.Enqueue((max, i), -max);
        }

        var max1 = pqMax.Dequeue();
        var min1 = pqMin.Dequeue();
        if (max1.index != min1.index)
        {
            return max1.val - min1.val;
        }

        var max2 = pqMax.Dequeue();
        var min2 = pqMin.Dequeue();
        var diff1 = max2.val - min1.val;
        var diff2 = max1.val- min2.val;

        return Math.Max(diff1, diff2);
    }
}
