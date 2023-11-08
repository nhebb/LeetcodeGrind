namespace LeetcodeGrind.Solutions;

// 2359. Find Closest Node to Given Two Nodes
public class P2359
{
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
}
