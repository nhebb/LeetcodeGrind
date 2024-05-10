namespace LeetcodeGrind.Solutions;

// 165. Compare Version Numbers
public class P0165
{
    public int CompareVersion(string version1, string version2)
    {
        var v1 = version1.Split('.');
        var v2 = version2.Split('.');

        var len = Math.Max(v1.Length, v2.Length);
        for (int i = 0; i < len; i++)
        {
            var n1 = i < v1.Length ? int.Parse(v1[i]) : 0;
            var n2 = i < v2.Length ? int.Parse(v2[i]) : 0;
            if (n1 < n2)
                return -1;
            if (n1 > n2)
                return 1;
        }
        return 0;
    }
}
