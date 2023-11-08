namespace LeetcodeGrind.Solutions;

// 2418. Sort the People
public class P2418
{
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
}
