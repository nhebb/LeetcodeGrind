namespace LeetcodeGrind.Solutions;

// 1790. Check if One String Swap Can Make Strings Equal
public class P1790
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        if (s1 == s2)
            return true;

        var diff = new List<int>();

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                diff.Add(i);
            }
        }

        if (diff.Count != 2)
            return false;

        if(s1[diff[0]] == s2[diff[1]] &&
           s1[diff[1]] == s2[diff[0]])
            return true;

        return false;
    }
}
