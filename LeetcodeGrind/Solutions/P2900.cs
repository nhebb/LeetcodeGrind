namespace LeetcodeGrind.Solutions;

// 2900. Longest Unequal Adjacent Groups Subsequence I
public class P2900
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        var list1 = new List<string>();
        var list2 = new List<string>();
        var lastIsOne = false;
        var lastIsZero = false;

        for (int i = 0; i < words.Length; i++)
        {
            var isOne = groups[i] == 1;

            if (isOne)
            {
                if (!lastIsOne)
                {
                    list1.Add(words[i]);
                    lastIsOne = true;
                }

                if (lastIsZero)
                {
                    list2.Add(words[i]);
                    lastIsZero = false;
                }
            }
            else
            {
                if (lastIsOne)
                {
                    list1.Add(words[i]);
                    lastIsOne = false;
                }

                if (!lastIsZero)
                {
                    list2.Add(words[i]);
                    lastIsZero = true;
                }
            }
        }

        return list1.Count >= list2.Count
            ? list1
            : list2;
    }
}
