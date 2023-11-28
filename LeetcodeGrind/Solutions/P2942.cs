namespace LeetcodeGrind.Solutions;

// 2942. Find Words Containing Character
public class P2942
{
    public IList<int> FindWordsContaining(string[] words, char x)
    {
        var ans = new List<int>();

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Contains(x))
                ans.Add(i);
        }

        return ans;
    }
}
