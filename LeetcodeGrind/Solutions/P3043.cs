namespace LeetcodeGrind.Solutions;

public class P3043
{
    private class NumTrieNode
    {
        public NumTrieNode[] Children { get; set; }
        public NumTrieNode()
        {
            Children = new NumTrieNode[10];
        }
    }

    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        var root = new NumTrieNode();

        // Add arr1 to trie
        foreach (var num in arr1)
        {
            var node = root;
            var chars = num.ToString();
            foreach (var c in chars)
            {
                var index = c - '0';
                if (root.Children[index] == null)
                {
                    node.Children[index] = new NumTrieNode();
                }
                node = node.Children[index];
            }
        }

        // Check arr2 for longest prefix match
        var max = 0;

        foreach (var num in arr2)
        {
            var node = root;
            var chars = num.ToString();
            var len = 0;

            foreach (var c in chars)
            {
                var index = c - '0';
                if (node.Children[index] == null)
                {
                    break;
                }
                len++;
                node = node.Children[index];
            }

            max = Math.Max(max, len);
        }

        return max;
    }
}
