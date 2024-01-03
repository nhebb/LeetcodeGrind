namespace LeetcodeGrind.Solutions;

// 2399. Check Distances Between Same Letters
public class P2399
{
    public bool CheckDistances(string s, int[] distance)
    {
        var found = new int[26];
        Array.Fill(found, -1);

        for (int i = 0; i < s.Length; i++)
        {
            var index = s[i] - 'a';
            if (found[index] == -1)
            {
                found[index] = i;
            }
            else
            {
                found[index] = i - found[index] - 1;
            }
        }

        for (int i = 0; i < found.Length; i++)
        {
            if (found[i] == -1)
            {
                continue;
            }

            if (found[i] != distance[i])
            {
                return false;
            }
        }

        return true;
    }
}
