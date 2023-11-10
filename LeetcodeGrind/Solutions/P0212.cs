using LeetcodeGrind.Common;
using System.Text;

namespace LeetcodeGrind.Solutions;

// 212. Word Search II
public class P0212
{
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var ans = new List<string>();
        var root = new TrieNode();
        var sb = new StringBuilder();
        var hs = new HashSet<string>();

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

        void Backtrack(int r, int c, TrieNode node)
        {
            if (r < 0 || r >= board.Length ||
                c < 0 || c >= board[r].Length ||
                visited[r][c])
                return;

            var letter = board[r][c];
            var index = letter - 'a';
            if (node.Children[index] == null)
                return;

            node = node.Children[index];

            visited[r][c] = true;
            sb.Append(board[r][c]);

            if (node.EndOfWord)
            {
                var word = sb.ToString();
                if (hs.Add(word))
                    ans.Add(word);
            }

            Backtrack(r - 1, c, node);
            Backtrack(r + 1, c, node);
            Backtrack(r, c - 1, node);
            Backtrack(r, c + 1, node);

            sb.Remove(sb.Length - 1, 1);
            visited[r][c] = false;
        }

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                Backtrack(r, c, root);
            }
        }

        return ans;
    }
}
