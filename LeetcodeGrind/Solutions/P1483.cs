namespace LeetcodeGrind.Solutions;

// TOTO: 1483. Kth Ancestor of a Tree Node
// TLE
public class TreeAncestor
{
    Dictionary<int, int> d;

    public TreeAncestor(int n, int[] parent)
    {
        d = new(n);
        for (int i = 0; i < parent.Length; i++)
        {
            d[i] = parent[i];
        }
    }

    public int GetKthAncestor(int node, int k)
    {
        while (k > 0)
        {
            if (d.TryGetValue(node, out int value))
            {
                node = value;
            }
            else
            {
                return -1;
            }
            k--;
        }
        return node;
    }
}