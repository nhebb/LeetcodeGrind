using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 472. Concatenated Words
public class P0472
{
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        var ans = new List<string>();
        var root = new TrieNode();
        var hs = new HashSet<string>();

        void AddWord(string word)
        {
            var node = root;
            for (int i = 0; i < word.Length; i++)
            {
                var index = word[i] - 'a';
                if (node.Children[index] == null)
                    node.Children[index] = new TrieNode();

                node = node.Children[index];

                if (i == word.Length - 1)
                    node.EndOfWord = true;
            }
        }

        foreach (var word in words)
            AddWord(word);

        void Backtrack(string word, TrieNode node, int startIndex, int wordCount)
        {
            if (startIndex == word.Length)
                return;

            for (int i = startIndex; i < word.Length; i++)
            {
                var index = word[i] - 'a';
                if (node.Children[index] == null)
                    return;

                node = node.Children[index];

                if (i == word.Length - 1 && node.EndOfWord && wordCount > 0)
                {
                    if (hs.Add(word))
                        ans.Add(word);
                }

                if (node.EndOfWord)
                    Backtrack(word, root, i + 1, wordCount + 1);
            }

        }

        foreach (var word in words)
            Backtrack(word, root, 0, 0);

        return ans;
    }
}
