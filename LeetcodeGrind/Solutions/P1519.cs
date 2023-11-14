using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1519. Number of Nodes in the Sub-Tree With the Same Label
public class P1519
{
    public int[] CountSubTrees(int n, int[][] edges, string labels)
    {
        // Create answer array. Each node is its own suv=btree,
        // so initialize it with 1's
        var ans = new int[n];
        Array.Fill(ans, 1);

        // Create an adjacent list
        var adj = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
            adj[i] = new List<int>();
        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        // Create a visited labels map. Key: label.
        // Value: hashset of visited nodes with that label
        var lblMap = new Dictionary<char, HashSet<int>>();
        for (int i = 0; i < 26; i++)
            lblMap[(char)('a' + i)] = new HashSet<int>();

        void Dfs(int node, int parent)
        {
            // Lookup the current node's label in the visited
            // label to indices map and increment each answer
            // for the indices.
            foreach (var index in lblMap[labels[node]])
                ans[index]++;

            // Do backtracking on the lblMap and iterate through
            // the child nodes. Because the adjacency list is 2-way,
            // check that the child isn't the parent
            lblMap[labels[node]].Add(node);
            foreach (var child in adj[node])
            {
                if (child != parent)
                    Dfs(child, node);
            }
            lblMap[labels[node]].Remove(node);
        }

        Dfs(0, -1);

        return ans;
    }
}
