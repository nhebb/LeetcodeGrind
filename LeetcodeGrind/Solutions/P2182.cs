using System.Text;

namespace LeetcodeGrind.Solutions;

// 2182. Construct String With Repeat Limit
public class P2182
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        var chars = new int[26];
        foreach (var c in s)
        {
            chars[c - 'a']++;
        }

        var pq = new PriorityQueue<int, int>();
        for (int i = 0; i < 26; i++)
        {
            if (chars[i] > 0)
            {
                pq.Enqueue(i, -i);
            }
        }

        var sb = new StringBuilder();
        var lastIndex = -1;

        while (pq.Count > 0)
        {
            var index = pq.Dequeue();
            var qty = Math.Min(chars[index], repeatLimit);
            chars[index] -= qty;

            if (pq.Count == 0 && index == lastIndex)
            {
                break;
            }
            else if (pq.Count > 0 && index == lastIndex)
            {
                index = pq.Dequeue();
                chars[index]--;
                if (chars[index] > 0)
                {
                    pq.Enqueue(index, -index);
                }

                char c = (char)(index + 'a');
                sb.Append(c);

                c = (char)(lastIndex + 'a');
                sb.Append(new string(c, qty));
                if (chars[lastIndex] > 0)
                {
                    pq.Enqueue(lastIndex, -lastIndex);
                }
            }
            else
            {
                char c = (char)(index + 'a');
                sb.Append(new string(c, qty));
                if (chars[index] > 0)
                {
                    pq.Enqueue(index, -index);
                }
                lastIndex = index;
            }
        }

        return sb.ToString();
    }
}
