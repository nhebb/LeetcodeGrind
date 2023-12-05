namespace LeetcodeGrind.Solutions;

// 821. Shortest Distance to a Character
public class P0821
{
    public int[] ShortestToChar(string s, char c)
    {
        var cIndexes = new List<int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == c)
                cIndexes.Add(i);
        }

        var ans = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            var min = int.MaxValue;
            foreach (var index in cIndexes)
            {
                min = Math.Min(min, Math.Abs(i - index));
            }
            ans[i] = min;
        }

        return ans;
    }
}
