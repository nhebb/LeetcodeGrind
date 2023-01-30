using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Tries;

// 208. Implement Trie (Prefix Tree)
public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        if (string.IsNullOrEmpty(word)) return;

        var node = _root;
        foreach (var c in word)
        {
            var index = c - 'a';
            if (node.Children[index] == null)
                node.Children[index] = new TrieNode();

            node = node.Children[index];
        }
        node.EndOfWord = true;
    }

    public bool Search(string word)
    {
        var node = _root;
        foreach (var c in word)
        {
            var index = c - 'a';
            if (node.Children[index] == null)
                return false;

            node = node.Children[index];
        }
        return node != null && node.EndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var node = _root;
        foreach (var c in prefix)
        {
            var index = c - 'a';
            if (node.Children[index] == null)
                return false;

            node = node.Children[index];
        }
        return true;
    }
}
