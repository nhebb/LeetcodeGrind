using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetcodeGrind.Tries;

public class Tries
{
    // 472. Concatenated Words
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


    // 140. Word Break II
    public IList<string> WordBreakII(string s, IList<string> wordDict)
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

        void Backtrack(TrieNode node, int startIndex, List<string> words)
        {
            if (startIndex == s.Length)
                return;

            for (int i = startIndex; i < s.Length; i++)
            {
                if (i == 9)
                    Console.WriteLine("break");

                var index = s[i] - 'a';
                if (node.Children[index] == null)
                    return;

                node = node.Children[index];

                if (node.EndOfWord)
                {
                    var word = s.Substring(startIndex, i - startIndex + 1);
                    words.Add(word);
                    if (i == s.Length - 1 && words.Count > 0)
                    {
                        var phrase = string.Join(" ", words);
                        if (hs.Add(phrase))
                            ans.Add(phrase);
                    }
                    else
                    {
                        Backtrack(root, i + 1, words);
                    }
                    words.RemoveAt(words.Count - 1);
                }
            }

        }

        foreach (var word in wordDict)
            AddWord(word);

        Backtrack(root, 0, new List<string>());

        return ans;
    }


    // 212. Word Search II
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var ans = new List<string>();
        var root = new TrieNode();
        var visited = new bool[board.Length][];
        for (int r = 0; r < board.Length; r++)
            visited[r] = new bool[board[r].Length];

        foreach (var word in words)
            AddWord(word);

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

        bool Backtrack(int i, int j)
        {


            return false;
        }

        return ans;
    }
}
