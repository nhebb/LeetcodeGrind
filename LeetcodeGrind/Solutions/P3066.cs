using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Solutions;

// 3066. Minimum Operations to Exceed Threshold Value II
public class P3066
{
    public int MinOperations(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>(nums.Length);
        foreach (var num in nums)
        {
            pq.Enqueue(num, num);
        }

        var ops = 0;
        while (pq.Count >= 2 && pq.Peek() < k)
        {
            var num1 = pq.Dequeue();
            var num2 = pq.Dequeue();
            var val = num1 * 2 + num2;
            pq.Enqueue(val, val);
            ops++;
        }

        return ops;
    }
}
