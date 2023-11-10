namespace LeetcodeGrind.Common;

public class TrieNode
{
    public bool EndOfWord { get; set; }
    public TrieNode[] Children { get; set; }
    public TrieNode()
    {
        Children = new TrieNode[26];
    }
}
