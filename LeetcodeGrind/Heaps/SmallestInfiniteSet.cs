using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Heaps;

// 2336. Smallest Number in Infinite Set
public class SmallestInfiniteSet
{
    HashSet<int> removed;
    PriorityQueue<int, int> pq;

    public SmallestInfiniteSet()
    {
        removed = new HashSet<int>();
        pq = new PriorityQueue<int, int>();
        for (int i = 1; i <= 1001; i++)
            pq.Enqueue(i, i);
    }

    public int PopSmallest()
    {
        var num = pq.Dequeue();
        removed.Add(num);
        return num;
    }

    public void AddBack(int num)
    {
        if (removed.Contains(num))
        {
            removed.Remove(num);
            pq.Enqueue(num, num);
        }
    }
}
