namespace LeetcodeGrind.Solutions;

// 1345. Jump Game IV
public class P1345
{
    public int MinJumps(int[] arr)
    {
        var n = arr.Length;
        var dict = new Dictionary<int, HashSet<int>>();

        for (int i = 0; i < n; i++)
        {
            if (!dict.ContainsKey(arr[i]))
            {
                dict[arr[i]] = new HashSet<int>();
            }

            dict[arr[i]].Add(i);
        }

        var visited = new bool[n];
        visited[0] = true;
        var q = new Queue<(int, int)>();
        q.Enqueue((0, 0));

        while (q.Count > 0)
        {
            var (curIndex, count) = q.Dequeue();

            var curVal = arr[curIndex];

            if (curIndex == n - 1)
            {
                return count;
            }

            if (arr[^1] == curVal)
            {
                return count + 1;
            }

            if (curIndex > 0 && !visited[curIndex - 1])
            {
                visited[curIndex - 1] = true;
                q.Enqueue((curIndex - 1, count + 1));

                if (n - 1 == curIndex - 1)
                {
                    return count + 1;
                }
            }

            if (curIndex < n && !visited[curIndex + 1])
            {
                visited[curIndex + 1] = true;
                q.Enqueue((curIndex + 1, count + 1));

                if (n - 1 == curIndex + 1)
                {
                    return count + 1;
                }
            }

            foreach (var i in dict[curVal])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    q.Enqueue((i, count + 1));

                    if (n - 1 == i)
                    {
                        return count + 1;
                    }
                }
            }

            dict[curVal] = new HashSet<int>();
        }

        return n;
    }
}
