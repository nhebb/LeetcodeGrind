using LeetcodeGrind.LinkedLists;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


    // 23. Merge k Sorted Lists
    public ListNode MergeKLists(ListNode[] lists)
    {

        if (lists == null || lists.Length == 0) { return null; }

        var pq = new PriorityQueue<ListNode, int>();

        foreach (var enqueNode in lists)
        {
            if (enqueNode != null)
            {
                pq.Enqueue(enqueNode, enqueNode.val);
            }
        }

        var prev = new ListNode(0);
        var node = prev;

        while (pq.Count > 0)
        {
            node.next = pq.Dequeue();
            if (node.next != null)
            {
                pq.Enqueue(node.next, node.next.val);
            }
            node = node.next;
        }

        return prev.next;
    }


    // 463. Island Perimeter
    public int IslandPerimeter(int[][] grid)
    {
        var count = 0;

        for (int r = 0; r < grid.Length; r++)
        {
            for (int c = 0; c < grid[r].Length; c++)
            {
                if (grid[r][c] == 0)
                    continue;

                if (r == 0 || (r > 0 && grid[r - 1][c] == 0))
                    count++;

                if (r == grid.Length - 1 ||
                    (r < grid.Length - 1 && grid[r + 1][c] == 0))
                    count++;

                if (c == 0 || (c > 0 && grid[r][c - 1] == 0))
                    count++;

                if (c == grid[r].Length - 1 ||
                    (c < grid[r].Length - 1 && grid[r][c + 1] == 0))
                    count++;
            }
        }

        return count;
    }


    // 621. Task Scheduler
    public int LeastInterval(char[] tasks, int n)
    {
        var d = new Dictionary<char, int>();
        var arr = new int[26];

        foreach (var c in tasks)
            arr[c - 'A']++;

        // Approach:
        // create an array of task counts

        return 0;

    }


    // 1464. Maximum Product of Two Elements in an Array
    public int MaxProduct(int[] nums)
    {
        var pq = new PriorityQueue<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Store the index in the pq using the
            // negated value as the priority
            pq.Enqueue(i, -1 * (nums[i] - 1));
        }

        var max1 = nums[pq.Dequeue()] - 1;
        var max2 = nums[pq.Peek()] - 1;

        return max1 * max2;
    }


    // 1962. Remove Stones to Minimize the Total
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


    // 2279. Maximum Bags With Full Capacity of Rocks
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


    // 2418. Sort the People
    public string[] SortPeople(string[] names, int[] heights)
    {
        var pq = new PriorityQueue<string, int>();
        for (int i = 0; i < names.Length; i++)
        {
            pq.Enqueue(names[i], -heights[i]);
        }

        var ans = new List<string>(names.Length);
        while (pq.Count > 0)
        {
            ans.Add(pq.Dequeue());
        }
        return ans.ToArray();
    }


    // 2512. Reward Top K Students
    private class Student
    {
        public int Id { get; private set; }
        public int Score { get; private set; }
        public Student(int id, int score)
        {
            Id = id;
            Score = score;
        }
    }
    public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
    {
        var hsPos = positive_feedback.ToHashSet();
        var hsNeg = negative_feedback.ToHashSet();
        var students = new List<Student>();

        for (int i = 0; i < report.Length; i++)
        {
            var words = report[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var score = 0;
            foreach (var word in words)
            {
                if (hsPos.Contains(word))
                    score += 3;
                else if (hsNeg.Contains(word))
                    score--;
            }
            students.Add(new Student(student_id[i], score));
        }

        return students.OrderByDescending(x => x.Score)
                       .ThenBy(x => x.Id)
                       .Select(x => x.Id)
                       .Take(k)
                       .ToList();
    }


    // 378. Kth Smallest Element in a Sorted Matrix
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


    // 2558. Take Gifts From the Richest Pile
    public long PickGifts(int[] gifts, int k)
    {
        var pq = new PriorityQueue<int, int>();
        foreach (var gift in gifts)
            pq.Enqueue(gift, -gift);

        while (k > 0)
        {
            var qty = pq.Dequeue();
            var putback = (int)(Math.Floor(Math.Sqrt(qty)));
            pq.Enqueue(putback, -putback);
            k--;
        }

        long remaining = 0;
        while (pq.Count > 0)
            remaining += pq.Dequeue();

        return remaining;
    }


    // 658. Find K Closest Elements
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        return arr.OrderBy(a => Math.Abs(x - a))
                  .ThenBy(a => a)
                  .Take(k)
                  .OrderBy(a => a)
                  .ToList();
    }
}
