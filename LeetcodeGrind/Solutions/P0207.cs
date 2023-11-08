namespace LeetcodeGrind.Solutions;

// 207. Course Schedule
public class P0207
{
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
}
