namespace LeetcodeGrind.Solutions;

// 752. Open the Lock
public class P0752
{
    public int OpenLock(string[] deadends, string target)
    {
        var deadset = deadends.ToHashSet();
        if (deadset.Contains("0000"))
            return -1;

        var q = new Queue<string>();
        q.Enqueue("0000");

        var visited = new HashSet<string>();
        visited.Add("0000");

        var count = 0;

        while (q.Count > 0)
        {
            var qCount = q.Count;

            for (int i = 0; i < qCount; i++)
            {
                var combo = q.Dequeue();

                if (combo.Equals(target))
                    return count;

                for (int j = 0; j < 4; j++)
                {
                    var chars = combo.ToCharArray();
                    var nextDigit = chars[j] == '9' ? '0' : (char)(chars[j] + 1);
                    char prevDigit = chars[j] == '0' ? '9' : (char)(chars[j] - 1);

                    chars[j] = nextDigit;
                    var next = new string(chars);
                    if (!visited.Contains(next) && !deadset.Contains(next))
                    {
                        q.Enqueue(next);
                        visited.Add(next);
                    }

                    chars[j] = prevDigit;
                    var prev = new string(chars);
                    if (!visited.Contains(prev) && !deadset.Contains(prev))
                    {
                        q.Enqueue(prev);
                        visited.Add(prev);
                    }
                }
            }

            count++;
        }

        return -1;
    }

}
