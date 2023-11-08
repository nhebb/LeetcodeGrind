namespace LeetcodeGrind.Solutions;

// 71. Simplify Path
public class P0071
{
    public string SimplifyPath(string path)
    {
        var stack = new Stack<string>();
        var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach (var segment in segments)
        {
            if (segment == ".")
                continue;

            if (segment != "..")
                stack.Push(segment);
            else if (stack.Count > 0)
                _ = stack.Pop();
        }

        return "/" + string.Join('/', stack.Reverse());
    }
}
