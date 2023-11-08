namespace LeetcodeGrind.Solutions;

// 797. All Paths From Source to Target
public class P0797
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var ans = new List<IList<int>>();
        var target = graph.Length - 1;

        void Dfs(List<int> path, int index)
        {
            foreach (var idx in graph[index])
            {
                path.Add(idx);
                if (idx == target)
                    ans.Add(new List<int>(path));
                else
                    Dfs(path, idx);
                path.RemoveAt(path.Count - 1);
            }
        }

        Dfs(new List<int>() { 0 }, 0);

        return ans;
    }
}
