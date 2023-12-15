namespace LeetcodeGrind.Solutions;

// 2839. Check if Strings Can be Made Equal With Operations I
public class P2839
{
    public bool CanBeEqual(string s1, string s2)
    {
        for (int i = 0; i < s1.Length - 2; i++)
        {
            if ((s1[i] == s2[i] && s1[i + 2] == s2[i + 2]) ||
                (s1[i] == s2[i + 2] && s1[i + 2] == s2[i]))
            {
                continue;
            }

            return false;
        }

        return true;
    }
}
