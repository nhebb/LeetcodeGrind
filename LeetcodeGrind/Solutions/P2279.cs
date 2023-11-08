namespace LeetcodeGrind.Solutions;

// 2279. Maximum Bags With Full Capacity of Rocks
public class P2279
{
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
    {
        var pq = new PriorityQueue<int, int>();

        for (int i = 0; i < capacity.Length; i++)
        {
            var rocksNeeded = capacity[i] - rocks[i];
            pq.Enqueue(rocksNeeded, rocksNeeded);
        }

        var count = 0;

        while (pq.Count > 0 && additionalRocks > 0)
        {
            var numRocks = pq.Dequeue();
            if (numRocks <= additionalRocks)
            {
                additionalRocks -= numRocks;
                count++;
            }
            else
            {
                break;
            }
        }

        return count;
    }
}
