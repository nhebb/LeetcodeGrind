namespace LeetcodeGrind.Solutions;

// 1481. Least Number of Unique Integers after K Removals
public class P1481
{
    public int FindLeastNumOfUniqueInts(int[] arr, int k)
    {
        var counts = arr.GroupBy(x => x)
                        .OrderBy(g => g.Count())
                        .ToDictionary(g => g.Key, g => g.Count());

        var keys = counts.Keys.ToList();

        foreach (var key in keys)
        {
            while (k > 0 && counts[key] > 0)
            {
                k--;
                counts[key]--;
            }

            if (counts[key] == 0)
            {
                counts.Remove(key);
            }

            if (k == 0)
            {
                break;
            }
        }

        return counts.Keys.Count;
    }

    // With min heap 
    public int FindLeastNumOfUniqueInts2(int[] arr, int k)
    {
        var counts = arr.GroupBy(x => x)
                        .OrderBy(g => g.Count())
                        .ToDictionary(g => g.Key, g => g.Count());

        var pq = new PriorityQueue<int, int>();
        foreach (var kvp in counts)
        {
            pq.Enqueue(kvp.Value, kvp.Value);
        }

        while (pq.Count >= 0 && k > 0)
        {
            if (k >= pq.Peek())
            {
                k -= pq.Peek();
                _ = pq.Dequeue();
            }
            else
            {
                // Don't pop because we need to include partially
                // decremented values in the pq count for the result.
                k = 0;
            }
        }

        return pq.Count;
    }
}