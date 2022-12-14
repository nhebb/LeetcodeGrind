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
                if(!Dfs(neighbor))
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

            var result = true;
            foreach (var neighbor in adj[i])
            {
                if (neighbor != prev)
                {
                    if(! Dfs(neighbor, i))
                        return false;
                }
            }
            return true;
        }

        return Dfs(0, -1) && visited.Count == n;
        
    }
}
