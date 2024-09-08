namespace LeetcodeGrind.Solutions;

// 373. Find K Pairs with Smallest Sums
public class P0373
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var pq = new PriorityQueue<List<int>, int>();

        for (var i = 0; i < nums1.Length; i++)
        {
            var added = false;
            for (var j = 0; j < nums2.Length; j++)
            {
                var sum = nums1[i] + nums2[j];
                if (pq.Count < k)
                {
                    pq.Enqueue(new List<int> { nums1[i], nums2[j] }, -sum);
                    added = true;
                }
                else if (pq.Peek().Sum() > sum)
                {
                    _ = pq.Dequeue();
                    pq.Enqueue([nums1[i], nums2[j]], -sum);
                    added = true;
                }

                if (!added)
                    break;
            }

            if (!added)
                break;
        }

        var result = new List<IList<int>>();
        while (k > 0 && pq.Count > 0)
        {
            result.Add(pq.Dequeue());
            k--;
        }

        return result;
    }
}
