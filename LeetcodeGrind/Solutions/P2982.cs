namespace LeetcodeGrind.Solutions;

// 2982. Find Longest Special Substring That Occurs Thrice II
public class P2982
{
    public int MaximumLength(string s)
    {
        var specials = new List<List<int>>(26);
        for (int i = 0; i < 26; i++)
        {
            specials.Add(new List<int>());
        }

        var index = 0;
        var start = 0;
        for (int end = 1; end < s.Length; end++)
        {
            if (s[end - 1] != s[end])
            {
                index = s[start] - 'a';
                specials[index].Add(end - start);
                start = end;
            }
        }
        index = s[start] - 'a';
        specials[index].Add(s.Length - start);

        var max = -1;
        for (int i = 0; i < specials.Count; i++)
        {
            if (specials[i].Count == 0)
            {
                continue;
            }

            var curMax = -1;
            if (specials[i].Count == 1)
            {
                curMax = specials[i][0] - 2;
            }
            else if (specials[i].Count == 2)
            {
                specials[i].Sort();
                curMax = specials[i][^1] - 2;
                if (specials[i][^1] > specials[i][^2])
                {
                    curMax = Math.Max(curMax, specials[i][^2]);
                }
                else if (specials[i][^1] == specials[i][^2])
                {
                    curMax = specials[i][^1] - 1;
                }
            }
            else
            {
                specials[i].Sort();
                var option1 = specials[i][^1] - 2;
                var option2 = -1;
                if (specials[i][^1] > specials[i][^2])
                {
                    option2 = Math.Max(curMax, specials[i][^2]);
                }
                else if (specials[i][^1] == specials[i][^2])
                {
                    option2 = specials[i][^1] - 1;
                }
                var option3 = specials[i][^3];
                curMax = Math.Max(Math.Max(option1, option2), option3);
            }
            max = Math.Max(max, curMax);
        }

        return max > 0 ? max : -1;
    }
}
