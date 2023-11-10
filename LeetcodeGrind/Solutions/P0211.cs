namespace LeetcodeGrind.Solutions;

// 211. Design Add and Search Words Data Structure
public class WordDictionary
{
    private class WordTrie
    {
        public bool EndOfWord { get; set; }
        public WordTrie[] Children { get; set; }

        public WordTrie()
        {
            Children = new WordTrie[26];
        }
    }

    private WordTrie root;

    public WordDictionary()
    {
        root = new WordTrie();
    }

    public void AddWord(string word)
    {
        var node = root;
        for (int i = 0; i < word.Length; i++)
        {
            var index = word[i] - 'a';
            if (node.Children[index] == null)
            {
                node.Children[index] = new WordTrie();
            }

            node = node.Children[index];

            if (i == word.Length - 1)
            {
                node.EndOfWord = true;
            }
        }
    }

    public bool Search(string word)
    {
        return FindChar(word, 0, root);
    }

    private bool FindChar(string word, int i, WordTrie node)
    {
        if (i == word.Length)
        {
            return node.EndOfWord;
        }

        if (word[i] == '.')
        {
            var found = false;
            for (int j = 0; j < node.Children.Length; j++)
            {
                if (node.Children[j] == null)
                    continue;

                found = FindChar(word, i + 1, node.Children[j]);
                if (found)
                    return true;
            }
        }
        else
        {
            var index = word[i] - 'a';
            if (node.Children[index] == null)
                return false;

            node = node.Children[index];
            return FindChar(word, i + 1, node);
        }
        return false;
    }
}