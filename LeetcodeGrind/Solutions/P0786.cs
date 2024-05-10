namespace LeetcodeGrind.Solutions;

// 786. K-th Smallest Prime Fraction
public class P0786
{
    public int[] KthSmallestPrimeFraction(int[] arr, int k)
    {
        var pq = new PriorityQueue<(int idx1, int idx2), double>();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                var val = arr[i] / (double)(arr[j]);
                pq.Enqueue((i, j), val);
            }
        }

        while (k > 1)
        {
            _ = pq.Dequeue();
            k--;
        }

        var indexes = pq.Dequeue();

        return new int[] { arr[indexes.idx1], arr[indexes.idx2] };
    }
}
