using System.Text;

namespace LeetcodeGrind.Solutions;

// 830. Positions of Large Groups
public class P0830
{
    public IList<IList<int>> LargeGroupPositions(string s)
    {
        var ans = new List<IList<int>>();
        var i = 0;
        while (i < s.Length)
        {
            var start = i;
            while (i < s.Length - 1 && s[i] == s[i + 1])
            {
                i++;
            }

            if (i - start >= 2)
            {
                ans.Add(new List<int>() { start, i });
            }
            else if (i == start)
            {
                i++;
            }
        }

        return ans;
    }
}
