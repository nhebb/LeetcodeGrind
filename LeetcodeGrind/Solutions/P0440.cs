namespace LeetcodeGrind.Solutions;

// TODO: 440. K-th Smallest in Lexicographical Order
// Original LINQ solution failed with out of memory error.
// Re-do with Trie.
public class P0440
{
    public int FindKthNumber(int n, int k)
    {
        // 2D array to act as a trie, holding the count of each
        // successive digit in the set of numbers.
        var trie = new int[10][];

        // As we populate the trie array, we will re-use digits
        // as a placeholder for each digit in the current number
        // from 1 to n.
        var digits = new int[10];

        // Initialize the trie.
        for (int row = 0; row < trie.Length; row++)
        {
            trie[row] = new int[10];
        }

        // Populate the trie.
        for (int i = 1; i <= n; i++)
        {
            // Temporarily store the digits in 'digits'
            // in order from least significant to most
            // significant digit.
            var val = i;
            var index = -1;
            while (val > 0)
            {
                index++;
                digits[index] = val % 10;
                val /= 10;
            }

            // Traverse digits in reverse order to increment
            // each trie level (r) at the index (c) matching
            // the current digit.
            var r = 0;
            while (index >= 0)
            {
                var c = digits[index];
                trie[r][c]++;

                index--;
                r++;
            }
        }

        int Dfs(int value, int r)
        {
            var c = 0;
            if (trie[r][c] == 0)
                while (trie[r][c] < k)
                {
                    k -= trie[r][c];
                    c++;
                }

            value = value * 10 + trie[r][c - 1];

            // Almost there. Figure out when to return and
            // when to call Dfs().
            value = Dfs(value, r + 1);
            return value;
        }

        return Dfs(0, 0); 
    }
}
