namespace LeetcodeGrind.Solutions;

// 131. Palindrome Partitioning
public class P0131
{
    public IList<IList<string>> Partition(string s)
    {
        var ans = new List<IList<string>>();
        var substrs = new List<string>();

        bool IsPalindrome(int i, int j)
        {
            while (i <= j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }

        void Backtrack(int i)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (IsPalindrome(i, j))
                {
                    substrs.Add(s.Substring(i, j - i + 1));
                    if (j == s.Length - 1)
                        ans.Add(new List<string>(substrs));
                    else
                        Backtrack(j + 1);
                    substrs.RemoveAt(substrs.Count - 1);
                }
            }
        }
        Backtrack(0);

        return ans;
    }
}
