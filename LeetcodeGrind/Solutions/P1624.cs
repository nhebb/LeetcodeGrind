namespace LeetcodeGrind.Solutions;

// 1624. Largest Substring Between Two Equal Characters
public class P1624
{
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        var list = Enumerable.Range(0, 26)
                             .Select(x => new List<int>())
                             .ToList();

        for (int i = 0; i < s.Length; i++)
        {
            list[s[i] - 'a'].Add(i);
        }

        var max = -1;

        for (int i = 0; i < list.Count; i++)
        {
            if(list[i].Count>0)
            {
                max = Math.Max(list[i][^1] - list[i][0] - 1, max);
            }
        }

        return max;
    }
}
