namespace LeetcodeGrind.Solutions;

// 1436. Destination City
public class P1436
{
    public string DestCity(IList<IList<string>> paths)
    {
        var hs = new HashSet<string>();
        foreach (var path in paths)
            hs.Add(path[0]);

        foreach (var path in paths)
            if (!hs.Contains(path[1]))
                return path[1];

        return string.Empty;
    }
}
