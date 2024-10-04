namespace LeetcodeGrind.Solutions;

// 2416. 
public class P2416
{
    private class CountTrie
    {
        public int Count { get; set; }
        public CountTrie[] Children { get; set; }
        public CountTrie()
        {
            Children = new CountTrie[26];
        }
    }

    public int[] SumPrefixScores(string[] words)
    {
        var root = new CountTrie();

        foreach (var w in words)
        {
            var node = root;

            foreach (var c in w)
            {
                var index = c - 'a';
                if (node.Children[index] == null)
                {
                    node.Children[index] = new CountTrie();
                }
                node = node.Children[index];
                node.Count++;
            }
        }

        var ans = new int[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            var node = root;
            var count = 0;
            foreach (var c in words[i])
            {
                var index = c - 'a';
                if (node.Children[index] == null)
                {
                    break; // this shouldn't be needed
                }
                node = node.Children[index];
                count += node.Count;
            }

            ans[i] = count;
        }

        return ans;
    }
}

