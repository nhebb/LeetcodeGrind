using System.Text;

namespace LeetcodeGrind.Solutions;

// 767. Reorganize String
public class P0767
{
    public string ReorganizeString(string s)
    {
        var chars = new int[26];
        foreach (var c in s)
        {
            chars[c - 'a']++;
        }

        var pq = new PriorityQueue<int, int>();
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] > 0)
                pq.Enqueue(i, -chars[i]);
        }

        var sb = new StringBuilder();
        var lastVal = -1;
        while (pq.Count > 0)
        {
            var val = pq.Dequeue();
            if (val == lastVal)
            {
                if (pq.Count == 0)
                {
                    return "";
                }
                else
                {
                    var temp = val;
                    val = pq.Dequeue();
                    pq.Enqueue(temp, -chars[temp]);
                }
            }
            lastVal = val;
            sb.Append((char)('a' + val));
            chars[val]--;
            if (chars[val] > 0)
                pq.Enqueue(val, -chars[val]);
        }
        return sb.ToString();
    }
}
