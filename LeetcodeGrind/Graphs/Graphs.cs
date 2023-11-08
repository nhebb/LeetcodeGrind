using LeetcodeGrind.Trees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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


    // 684. Redundant Connection
    public int[] FindRedundantConnection(int[][] edges)
    {
        var maxEdge = 0;
        foreach (var edge in edges)
        {
            if (edge[0] > maxEdge)
                maxEdge = edge[0];
            if (edge[1] > maxEdge)
                maxEdge = edge[1];
        }

        var parent = new int[maxEdge + 1];
        for (int i = 0; i < parent.Length; i++)
            parent[i] = i;

        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        void Union(int x, int y)
        {
            parent[Find(x)] = Find(y);
        }

        bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }

        var ans = new int[2];

        foreach (var edge in edges)
        {
            if (Connected(edge[0], edge[1]))
            {
                ans[0] = edge[0];
                ans[1] = edge[1];
            }
            else
            {
                Union(edge[0], edge[1]);
            }
        }

        return ans;
    }


    // 2359. Find Closest Node to Given Two Nodes
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        if (node1 == node2)
            return 0;
        else if (edges[node1] == -1)
            return HasPathToTarget(node2, node1);
        else if (edges[node2] == -1)
            return HasPathToTarget(node1, node2);


        int HasPathToTarget(int startNode, int targetNode)
        {
            var node = edges[startNode];
            while (node != -1)
            {
                if (node == targetNode)
                    return targetNode;
                node = edges[node];
            }
            return -1;
        }

        var v1 = new int[edges.Length];
        Array.Fill(v1, -1);
        var v2 = new int[edges.Length];
        Array.Fill(v2, -1);

        var minDist = int.MaxValue;
        var minNode = int.MaxValue;

        v1[node1] = 0;
        var next = edges[node1];
        var dist = 1;

        while (next != -1)
        {
            // cycle detected
            if (v1[next] != -1)
                break;

            v1[next] = dist;
            dist++;
            next = edges[next];
        }

        if (edges[node2] == -1)
        {
            return v1[node2] == -1
                ? -1
                : node2;
        }

        v2[node2] = 0;
        dist = 1;
        next = edges[node2];

        while (next != -1)
        {
            if (v1[next] != -1)
            {
                var localMax = Math.Max(v1[next], v2[next]);
                minDist = Math.Min(minDist, localMax);
                if (localMax < minDist)
                {
                    minDist = localMax;
                    minNode = next;
                }
                else if (localMax == minDist && next < minNode)
                {
                    minNode = next;
                }
            }

            if (v2[next] != -1)
            {
                break;
            }

            v2[next] = dist;

            next = edges[next];
            dist++;
        }

        if (minNode == int.MaxValue)
            return -1;
        return minNode;
    }
    public int ClosestMeetingNode2(int[] edges, int node1, int node2)
    {
        var dist1 = new int[edges.Length];
        int dist = 1;
        var node = node1;
        while (node != -1 && dist1[node] == 0)
        {
            dist1[node] = dist;
            node = edges[node];
            dist++;
        }

        var dist2 = new int[edges.Length];
        node = node2;
        while (node != -1 && dist2[node] == 0)
        {
            dist2[node] = dist;
            node = edges[node];
            dist++;
        }

        int minMaxDist = int.MaxValue;
        int meetingNode = -1;

        for (int i = 0; i < edges.Length; i++)
        {
            if (dist1[i] == 0 || dist2[i] == 0)
                continue;

            int localMax = Math.Max(dist1[i], dist2[i]);
            if (localMax < minMaxDist)
            {
                minMaxDist = localMax;
                meetingNode = i;
            }
        }

        return meetingNode;
    }
    public int ClosestMeetingNode3(int[] edges, int node1, int node2)
    {
        int[] n1Path = GetPath(node1);
        int[] n2Path = GetPath(node2);

        int distance = int.MaxValue;
        int result = -1;
        for (int i = 0; i < edges.Length; i++)
        {
            if (n1Path[i] == 0 || n2Path[i] == 0)
                continue;

            int max = Math.Max(n1Path[i], n2Path[i]);
            if (max < distance)
            {
                distance = max;
                result = i;
            }
        }
        return result;

        int[] GetPath(int node)
        {
            int[] path = new int[edges.Length];
            int steps = 1;
            while (node != -1 && path[node] == 0)
            {
                path[node] = steps++;
                node = edges[node];
            }
            return path;
        }
    }


    // TODO: Study this. It uses Dijkstra's algorithm
    // 787. Cheapest Flights Within K Stops
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        // flights[i] = [from_i, to_i, price_i]
        var adj = new Dictionary<int, List<int[]>>();
        foreach (var flight in flights)
        {
            if (!adj.ContainsKey(flight[0]))
                adj[flight[0]] = new List<int[]>();

            // key: from_i, value: int[to_i, price_i]
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        // record min # stops to arrive at each airport (node)
        var stops = new int[n];
        Array.Fill(stops, int.MaxValue);

        // 0 = total cost from src, 1 = airport, 2 = # stops from src
        var firstLeg = new int[] { 0, src, 0 };

        // custom comparer on index 0 - the price
        var pq = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[0] - b[0]));
        pq.Enqueue(firstLeg, firstLeg);

        while (pq.Count > 0)
        {
            var flight = pq.Dequeue();
            var price = flight[0];
            var airport = flight[1];
            var curStops = flight[2];

            // Current path costs more than the lowest,
            // or too many stops
            if (curStops > stops[airport] || curStops > k + 1)
                continue;

            stops[airport] = curStops;

            // the eagle has landed
            if (airport == dst)
                return price;

            // dead end
            if (!adj.ContainsKey(airport))
                continue;

            // BFS on neighboring flight legs
            foreach (var neighbor in adj[airport])
            {
                var nextLeg = new int[] { price + neighbor[1], neighbor[0], curStops + 1 };
                pq.Enqueue(nextLeg, nextLeg);
            }
        }

        return -1;
    }


    // 1129. Shortest Path with Alternating Colors
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        var redNodes = new List<int>[n];
        var blueNodes = new List<int>[n];

        for (var i = 0; i < n; i++)
        {
            redNodes[i] = new List<int>();
            blueNodes[i] = new List<int>();
        }

        foreach (var edge in redEdges)
            redNodes[edge[0]].Add(edge[1]);

        foreach (var edge in blueEdges)
            blueNodes[edge[0]].Add(edge[1]);

        var result = new int[n];
        new Span<int>(result).Fill(-1);

        var queue = new Queue<(int node, bool isBlue)>();
        queue.Enqueue((0, true));
        queue.Enqueue((0, false));

        var visited = new HashSet<(int node, bool isBlue)>();
        visited.Add((0, true));
        visited.Add((0, false));

        var level = 0;
        while (queue.Count > 0)
        {
            var count = queue.Count;
            for (var i = 0; i < count; i++)
            {
                var (node, isBlue) = queue.Dequeue();
                if (result[node] == -1)
                    result[node] = level;

                // if current node is blue, add unvisited red edges,
                // or if current node is red, add unvisited blue edges
                if (isBlue)
                {
                    foreach (var next in redNodes[node])
                        if (!visited.Contains((next, false)))
                        {
                            queue.Enqueue((next, false));
                            visited.Add((next, false));
                        }
                }
                else
                {
                    foreach (var next in blueNodes[node])
                        if (!visited.Contains((next, true)))
                        {
                            queue.Enqueue((next, true));
                            visited.Add((next, true));
                        }
                }
            }

            level++;
        }

        return result;
    }


    // 2477. Minimum Fuel Cost to Report to the Capital
    public long MinimumFuelCost(int[][] roads, int seats)
    {
        long fuel = 0;
        var adj = new Dictionary<int, List<int>>();

        // bidirectional roads == undirected graph
        foreach (var road in roads)
        {
            if (!adj.ContainsKey(road[0]))
                adj[road[0]] = new List<int>();
            adj[road[0]].Add(road[1]);

            if (!adj.ContainsKey(road[1]))
                adj[road[1]] = new List<int>();
            adj[road[1]].Add(road[0]);
        }

        long Dfs(int node, int parent)
        {
            long reps = 1; // city representatives. Current city has 1
            if (!adj.ContainsKey(node))
                return reps;

            foreach (var child in adj[node])
                if (child != parent)
                    reps += Dfs(child, node);

            if (node != 0)
                fuel += (long)Math.Ceiling(reps / (double)seats);

            return reps;
        }

        Dfs(0, -1);

        return fuel;
    }


    // 2492. Minimum Score of a Path Between Two Cities
    // TODO: Finish this.
    public int MinScore(int n, int[][] roads)
    {
        // create bidirectional adjacency list
        var adj = new Dictionary<int, List<(int, int)>>();
        foreach (var road in roads)
        {
            if (!adj.ContainsKey(road[0]))
                adj[road[0]] = new List<(int, int)>();
            adj[road[0]].Add((road[1], road[2]));

            if (!adj.ContainsKey(road[1]))
                adj[road[1]] = new List<(int, int)>();
            adj[road[1]].Add((road[0], road[2]));
        }

        // Create a disjoint set array to eliminate unneeded paths
        var parent = new int[n + 1];
        for (int i = 0; i < parent.Length; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            while (x != parent[x])
                x = parent[x];
            return x;
        }

        void Union(int x, int y)
        {
            var min = Find(x);
            var max = Find(y);
            if (min > max)
                (min, max) = (max, min);
            parent[max] = min;
        }

        bool Connected(int x, int y)
        {
            return Find(x) == Find(y);
        }

        var minpath = int.MaxValue;
        var q = new Queue<(int city, int dist)>();
        foreach (var edge in adj[1])
        {
            q.Enqueue(edge);
        }

        while (q.Count > 0) 
        {
            var count = q.Count;

        }

        return 0;
    }


    // 1254. Number of Closed Islands
    public int ClosedIsland(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var visited = new bool[rows][];
        for (int r = 0; r < rows; r++)
        {
            visited[r] = new bool[cols];
        }

        bool Dfs(int r, int c)
        {
            if (r < 0 || r == rows)
                return false;
            if (c < 0 || c == cols)
                return false;

            if (visited[r][c])
            {
                if (r == 0 || r == rows - 1 || c == 0 | c == cols - 1)
                    return false;
                else
                    return true;
            }

            if (grid[r][c] == 1)
                return true;

            visited[r][c] = true;

            var left = Dfs(r, c - 1);
            var right = Dfs(r, c + 1);
            var top = Dfs(r - 1, c);
            var bottom = Dfs(r + 1, c);

            return left && right && top && bottom;
        }

        var count = 0;
        for (int r = 1; r < rows - 1; r++)
        {
            for (int c = 1; c < cols - 1; c++)
            {
                if (grid[r][c] == 0 && !visited[r][c])
                {
                    if (Dfs(r, c))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }


    // 815. Bus Routes
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        var adj = new Dictionary<int, List<int>>();
        var visited = new HashSet<int>();
        var minBuses = int.MaxValue;

        // create adjacency list
        for (int i = 0; i < routes.Length; i++)
        {
            if (routes[i].Length == 0)
                continue;

            for (int j = 1; j < routes[i].Length; j++)
            {
                var key = routes[i][j - 1];
                var val = routes[i][j];
                if (!adj.ContainsKey(key))
                    adj[key] = new List<int>();
                adj[key].Add(val);
            }
            if (routes[i].Length > 1)
            {
                if (!adj.ContainsKey(routes[i][^1]))
                    adj[routes[i][^1]] = new List<int>();
                adj[routes[i][^1]].Add(routes[i][0]);
            }
        }

        void Bfs(int bus, int numBuses)
        {
            if (bus == target)
            {
                minBuses = Math.Min(minBuses, numBuses);
                return;
            }

            if (visited.Contains(bus))
                return;

            visited.Add(bus);
            foreach (var nextBus in adj[bus])
            {
                if (visited.Contains(nextBus))
                    continue;

                Bfs(nextBus, numBuses + 1);
            }
            visited.Remove(bus);
        }

        return minBuses == int.MaxValue ? -1 : minBuses;
    }


    // 1514. Path with Maximum Probability
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
    {
        // Create adjacency dictionary from src node to dest node,
        // with probability as edge weight
        var adj = new Dictionary<int, List<(int vertex, double probability)>>();
        for (int i = 0; i < edges.Length; i++)
        {
            if (!adj.ContainsKey(edges[i][0]))
                adj[edges[i][0]] = new List<(int vertex, double probability)>();
            adj[edges[i][0]].Add((edges[i][1], succProb[i]));

            if (!adj.ContainsKey(edges[i][1]))
                adj[edges[i][1]] = new List<(int vertex, double probability)>();
            adj[edges[i][1]].Add((edges[i][0], succProb[i]));
        }

        // Edge case where you are given a start or end node not in the adjacency list
        if (!adj.ContainsKey(start) || !adj.ContainsKey(end))
            return 0.0;

        // Max heap of the next available vetices, prioritized by the
        // edge probability (negated).
        var pq = new PriorityQueue<(int vertex, double probability), double>();
        pq.Enqueue((start, -1.0), -1.0);

        // Keep track of visited vertices
        var visited = new HashSet<int>();
        visited.Add(start);

        // Djikstra's algo
        while (pq.Count > 0)
        {
            var edge = pq.Dequeue();
            var src = edge.vertex;
            var curProbability = edge.probability;
            visited.Add(src);

            if (src == end)
                return -curProbability;

            foreach (var dest in adj[src])
            {
                if (!visited.Contains(dest.vertex))
                {
                    var nextProbability = curProbability * dest.probability;
                    pq.Enqueue((dest.vertex, nextProbability), nextProbability);  
                }
            }

        }

        return 0.0;
    }
}
