using LeetcodeGrind.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Graphs;

public class Graphs
{
    // 1971. Find if Path Exists in Graph
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            if (vertex == destination)
                return true;

            visited.Add(vertex);

            foreach (var neighbor in graph[vertex])
            {
                if (!visited.Contains(neighbor))
                    queue.Enqueue(neighbor);
            }
        }

        return false;
    }


    // 841. Keys and Rooms
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var visited = new bool[rooms.Count];

        var q = new Queue<int>();
        q.Enqueue(0);

        while (q.Count > 0)
        {
            var room = q.Dequeue();
            visited[room] = true;
            foreach (var key in rooms[room])
            {
                if (!visited[key])
                    q.Enqueue(key);
            }
        }

        var hasUnvisited = visited.Any(x => x == false);
        return !hasUnvisited;
    }


    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        var dict = new Dictionary<int, List<int>>();

        // set up parent array for union find
        var parent = new int[n + 1];
        for (int i = 0; i < parent.Length; i++)
            parent[i] = i;

        // local functions for union find
        void Union(int x, int y)
        {
            parent[Find(x)] = parent[Find(y)];
        }

        int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);

            return parent[x];
        }

        // Add key-value entries for both indices of ith dislikes
        foreach (var dislike in dislikes)
        {
            if (dict.TryGetValue(dislike[0], out var list1))
                list1.Add(dislike[1]);
            else
                dict[dislike[0]] = new List<int> { dislike[1] };

            if (dict.TryGetValue(dislike[1], out var list2))
                list2.Add(dislike[0]);
            else
                dict[dislike[1]] = new List<int> { dislike[0] };
        }

        // iterate over the possible people values (1 to n) ...
        for (int person = 1; person <= n; person++)
        {
            if (!dict.ContainsKey(person))
                continue;

            // ... and then check if dislikes are in the same union set
            foreach (var enemy in dict[person])
            {
                if (Find(person) == Find(enemy))
                    return false;

                Union(dict[person][0], enemy);
            }
        }

        return true;
    }


    // 1557. Minimum Number of Vertices to Reach All Nodes
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var destination = new bool[n];

        // Mark destination nodes as true
        foreach (var edge in edges)
            destination[edge[1]] = true;

        // If node hasn't been marked as a destination,
        // then it's a root
        var result = new List<int>();
        for (int i = 0; i < destination.Length; i++)
        {
            if (!destination[i])
                result.Add(i);
        }

        return result;
    }
    public IList<int> FindSmallestSetOfVertices2(int n, IList<IList<int>> edges)
    {
        var hs = Enumerable.Range(0, n).ToHashSet();

        foreach (var edge in edges)
            hs.Remove(edge[1]);

        return hs.ToList();
    }


    // 207. Course Schedule
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // Create a dictionary initialize from 0 to
        // numCourses-1 with an empty list
        var d = new Dictionary<int, List<int>>();
        for (int i = 0; i < numCourses; i++)
            d[i] = new List<int>();

        foreach (var prereq in prerequisites)
            d[prereq[0]].Add(prereq[1]);

        // HashSet to detect cycle
        var visited = new HashSet<int>();

        bool Dfs(int vertex)
        {
            // cycle detected
            if (visited.Contains(vertex))
                return false;

            // course has no prerequisites
            if (d[vertex].Count == 0)
                return true;

            // iterate through vertex neighbors
            visited.Add(vertex);
            foreach (var neighbor in d[vertex])
            {
                if (!Dfs(neighbor))
                    return false;
            }
            d[vertex].Clear();
            visited.Remove(vertex);

            return true;
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (!Dfs(i))
                return false;
        }

        return true;
    }


    // 261. Graph Valid Tree (locked)
    public bool ValidTree(int n, int[][] edges)
    {
        if (n == 0) return true;

        var adj = new List<List<int>>(n);
        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        bool Dfs(int i, int prev)
        {
            if (!visited.Add(i))
                return false;

            foreach (var neighbor in adj[i])
            {
                if (neighbor != prev)
                {
                    if (!Dfs(neighbor, i))
                        return false;
                }
            }
            return true;
        }

        return Dfs(0, -1) && visited.Count == n;
    }


    // 1443. Minimum Time to Collect All Apples in a Tree
    public int MinTime(int n, int[][] edges, IList<bool> hasApple)
    {
        if (!hasApple.Any(x => x == true))
            return 0;

        var children = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            if (children.TryGetValue(edge[0], out var list1))
                list1.Add(edge[1]);
            else
                children[edge[0]] = new List<int>() { edge[1] };

            if (children.TryGetValue(edge[1], out var list2))
                list2.Add(edge[0]);
            else
                children[edge[1]] = new List<int>() { edge[0] };
        }

        if (children[0].Count == 0)
            return 0;

        var time = 0;
        var visited = new HashSet<int>();

        bool Dfs(int node, int dist)
        {
            visited.Add(node);
            var result = false;
            if (hasApple[node])
            {
                time += dist;
                dist = 0;
                result = true;
            }

            if (children.ContainsKey(node))
            {
                foreach (var child in children[node])
                {
                    if (visited.Contains(child))
                        continue;

                    if (Dfs(child, dist + 1))
                    {
                        time += 1;
                        result = true;
                        dist = 0;
                    }
                }
            }
            visited.Remove(node);
            return result;
        }

        _ = Dfs(0, 0);

        return time;
    }


    // 2421. Number of Good Paths
    public int NumberOfGoodPaths(int[] vals, int[][] edges)
    {
        // Sort edges lowest to highest
        Array.Sort(edges, (a, b) => Math.Max(vals[a[0]], vals[a[1]]) -
                                    Math.Max(vals[b[0]], vals[b[1]]));

        // Because a node is its own subtree, we initialize 
        // the result with the number of nodes.
        var result = vals.Length;

        var parent = new int[result];
        var count = new int[result];

        for (int i = 0; i < vals.Length; i++)
            parent[i] = i;

        // local functions for Union-Find
        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        bool Union(int a, int b)
        {
            int p = Find(a);
            int q = Find(b);

            // skip equal node parents
            if (p == q)
                return false;

            // if values are equal, update the result and the count
            if (vals[p] == vals[q])
            {
                result += (count[p] + 1) * (count[q] + 1);
                count[p] += count[q] + 1;
                parent[q] = p;
                return true;
            }

            // set the lower value as the parent
            if (vals[p] > vals[q])
                parent[q] = p;
            else
                parent[p] = q;

            return true;
        }

        foreach (int[] edge in edges)
            Union(edge[0], edge[1]);

        return result;
    }


    // 323. Number of Connected Components in an Undirected Graph
    public int CountComponents(int n, int[][] edges)
    {
        var parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;

        foreach (var edge in edges)
        {
            var p = edge[0];
            while (p != parent[p])
                p = parent[p];

            var q = edge[1];
            while (q != parent[q])
                q = parent[q];

            if (p == q) continue;

            if (p < q)
                (p, q) = (q, p);

            parent[p] = q;
        }

        var count = 0;
        for (int i = 0; i < parent.Length; i++)
        {
            if (parent[i] == i)
                count++;
        }

        return count;
    }


    // 417. Pacific Atlantic Water Flow
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        // pac = left & top
        var pac = new bool[heights.Length][];
        for (int i = 0; i < pac.Length; i++)
            pac[i] = new bool[heights[0].Length];

        // atl = right & bottom
        var atl = new bool[heights.Length][];
        for (int i = 0; i < atl.Length; i++)
            atl[i] = new bool[heights[0].Length];

        // initialize top / left edges
        Array.Fill(pac[0], true);
        for (int r = 1; r < pac.Length; r++)
            pac[r][0] = true;

        // initialize bottom / right edges
        Array.Fill(atl[atl.Length - 1], true);
        for (int r = 0; r < atl.Length - 1; r++)
            atl[r][atl[0].Length - 1] = true;

        // set pacific flow
        for (int r = 1; r < pac.Length; r++)
        {
            // first pass - check above
            for (int c = 1; c < pac[r].Length; c++)
            {
                pac[r][c] = pac[r - 1][c] &&
                            heights[r][c] >= heights[r - 1][c];
            }

            // second pass - scan left to right
            for (int c = 1; c < pac[r].Length; c++)
            {
                if (pac[r][c]) continue;

                pac[r][c] = pac[r][c - 1] &&
                            heights[r][c - 1] <= heights[r][c];
            }

            // third pass - scan right to left
            for (int c = pac[r].Length - 2; c >= 0; c--)
            {
                if (pac[r][c]) continue;

                pac[r][c] = c < pac[r].Length - 1 && pac[r][c + 1] &&
                            heights[r][c + 1] <= heights[r][c];
            }
        }

        // set atlantic flow
        for (int r = atl.Length - 2; r >= 0; r--)
        {
            // first pass - check below
            for (int c = 0; c < atl[r].Length - 1; c++)
            {
                atl[r][c] = atl[r + 1][c] &&
                            heights[r][c] >= heights[r + 1][c];
            }

            // second pass - check left to right
            for (int c = 1; c < atl[r].Length - 1; c++)
            {
                if (atl[r][c]) continue;

                atl[r][c] = atl[r][c - 1] &&
                            heights[r][c - 1] <= heights[r][c];
            }

            // second pass - check left and right
            for (int c = atl[r].Length - 2; c >= 0; c--)
            {
                if (atl[r][c]) continue;

                atl[r][c] = atl[r][c + 1] &&
                            heights[r][c + 1] <= heights[r][c];
            }
        }

        var ans = new List<IList<int>>();
        for (int r = 0; r < heights.Length; r++)
        {
            for (int c = 0; c < heights[r].Length; c++)
            {
                if (pac[r][c] && atl[r][c])
                    ans.Add(new List<int>() { r, c });
            }
        }

        return ans;
    }
    public IList<IList<int>> PacificAtlantic2(int[][] heights)
    {
        var result = new List<IList<int>>();

        var rows = heights.Length;
        var cols = heights[0].Length;

        // track visited
        var pac = new bool[rows, cols];
        var atl = new bool[rows, cols];

        void Dfs(int r, int c, int lastHeight, bool[,] visited)
        {
            if (r < 0 || c < 0 ||
                r == rows || c == cols ||
                visited[r, c] ||
                heights[r][c] < lastHeight)
            {
                return;
            }

            visited[r, c] = true;
            lastHeight = heights[r][c];
            Dfs(r + 1, c, lastHeight, visited);
            Dfs(r - 1, c, lastHeight, visited);
            Dfs(r, c + 1, lastHeight, visited);
            Dfs(r, c - 1, lastHeight, visited);
        }

        // scan from top and bottom rows
        for (var col = 0; col < cols; col++)
        {
            Dfs(0, col, heights[0][col], pac);
            Dfs(rows - 1, col, heights[rows - 1][col], atl);
        }

        // scan from left and right columns
        for (var r = 0; r < rows; r++)
        {
            Dfs(r, 0, heights[r][0], pac);
            Dfs(r, cols - 1, heights[r][cols - 1], atl);
        }

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (pac[r, c] && atl[r, c])
                    result.Add(new List<int>() { r, c });
            }
        }

        return result;
    }
}
