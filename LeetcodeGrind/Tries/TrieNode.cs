using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Tries;

public class TrieNode
{
    public bool EndOfWord { get; set; }
    public TrieNode[] Children { get; set; }
    public TrieNode()
    {
        Children = new TrieNode[26];
    }
}
