namespace LeetcodeGrind.Solutions;

// 455. Assign Cookies
public class P0455
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        var count = 0;
        var i = g.Length - 1;
        var j = s.Length - 1;

        while (i >= 0 && j >= 0)
        {
            if (s[j] >= g[i])
            {
                count++;
                i--;
                j--;
            }
            else
            {
                i--;
            }
        }

        return count;
    }
}
