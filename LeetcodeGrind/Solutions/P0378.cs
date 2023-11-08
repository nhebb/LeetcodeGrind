namespace LeetcodeGrind.Solutions;

// 378. Kth Smallest Element in a Sorted Matrix
public class P0378
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var pq = new PriorityQueue<int, int>();
        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                pq.Enqueue(matrix[r][c], matrix[r][c]);
            }
        }

        while (k > 1)
        {
            _ = pq.Dequeue();
            k--;
        }

        return pq.Dequeue();
    }
}
