using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 648. Replace Words
public class P0648
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        var root = new TrieNode();
        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();

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

        bool HasRoot(string s)
        {
            var node = root;
            for (int i = 0; i < s.Length; i++)
            {
                var index = s[i] - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }

                sb.Append(s[i]);
                if (node.Children[index].EndOfWord)
                {
                    return true;
                }
                node = node.Children[index];
            }
            return false;
        }

        foreach (var s in dictionary)
        {
            AddWord(s);
        }

        for (int i = 0; i < words.Length; i++)
        {
            if (HasRoot(words[i]))
            {
                words[i] = sb.ToString();
            }
            sb.Clear();
        }

        return string.Join(' ', words);
    }
}
