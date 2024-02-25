namespace LeetcodeGrind.Solutions;

// 547. Number of Provinces
public class P0547
{
    public int FindCircleNum(int[][] isConnected)
    {
        var n = isConnected.Length;
        var count = n;

        var rank = new int[n];
        var parent = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            while (x != parent[x])
            {
                // path compression by halving
                parent[x] = parent[parent[x]];
                x = parent[x];
            }
            return x;
        }

        void Union(int x, int y)
        {
            var p = Find(x);
            var q = Find(y);
            if (p == q)
                return;

            if (rank[q] > rank[p])
            {
                parent[p] = q;
            }
            else
            {
                parent[q] = p;
                if (rank[p] == rank[q])
                {
                    rank[p]++;
                }
            }
            count--;
        }


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j && isConnected[i][j] == 1)
                {
                    Union(i, j);
                }
            }
        }

        return count;
    }
}
