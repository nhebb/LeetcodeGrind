namespace LeetcodeGrind.Solutions;

// 1962. Remove Stones to Minimize the Total
public class P1962
{
    public int MinStoneSum(int[] piles, int k)
    {
        var pq = new PriorityQueue<int, int>();
        for (int i = 0; i < piles.Length; i++)
        {
            pq.Enqueue(i, -piles[i] / 2);
        }

        while (k > 0 && pq.Count > 0)
        {
            var index = pq.Dequeue();
            var removed = piles[index] / 2;
            piles[index] -= removed;
            if (piles[index] > 0)
                pq.Enqueue(index, -piles[index] / 2);

            k--;
        }
        return piles.Sum();
    }
}
