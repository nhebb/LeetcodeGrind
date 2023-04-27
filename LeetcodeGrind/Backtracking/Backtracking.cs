using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Backtracking;

public class Backtracking
{
    // 17. Letter Combinations of a Phone Number
    public IList<string> LetterCombinations(string digits)
    {
        List<string> combos = new List<string>();

        if (string.IsNullOrWhiteSpace(digits))
            return combos;

        var lookup = new Dictionary<char, List<string>>
        {
            { '2', new List<string>() { "a", "b", "c" } },
            { '3', new List<string>() { "d", "e", "f" } },
            { '4', new List<string>() { "g", "h", "i" } },
            { '5', new List<string>() { "j", "k", "l" } },
            { '6', new List<string>() { "m", "n", "o" } },
            { '7', new List<string>() { "p", "q", "r", "s" } },
            { '8', new List<string>() { "t", "u", "v" } },
            { '9', new List<string>() { "w", "x", "y", "z" } }
        };

        void ProcessDigits(string substr, int i)
        {
            if (i == digits.Length)
            {
                combos.Add(substr);
            }
            else
            {
                var letters = lookup[digits[i]];
                foreach (var letter in letters)
                {
                    ProcessDigits(substr + letter, i + 1);
                }
            }
        }

        foreach (var letter in lookup[digits[0]])
        {
            ProcessDigits(letter, 1);
        }

        return combos.OrderBy(x => x).Distinct().ToList();
    }


    // 39. Combination Sum
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var ans = new List<IList<int>>();
        var combo = new List<int>();

        void BackTrackSum(int start, int sum)
        {
            combo.Add(candidates[start]);
            sum += candidates[start];
            if (sum == target)
            {
                ans.Add(new List<int>(combo));
            }
            else if (sum < target)
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    BackTrackSum(i, sum);
                }
            }
            sum -= candidates[start];
            combo.RemoveAt(combo.Count - 1);
        }

        for (int i = 0; i < candidates.Length; i++)
        {
            BackTrackSum(i, 0);
        }

        return ans;
    }


    // 40. Combination Sum II
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);

        var ans = new List<IList<int>>();
        var combo = new List<int>();

        void BackTrackSum(int i, int sum)
        {
            for (int j = i; j < candidates.Length; j++)
            {
                if (j > i && candidates[j] == candidates[j - 1])
                    continue;

                combo.Add(candidates[j]);
                sum += candidates[j];

                if (sum == target)
                    ans.Add(new List<int>(combo));
                else if (sum < target)
                    BackTrackSum(j + 1, sum);

                sum -= candidates[j];
                combo.RemoveAt(combo.Count - 1);
            }
        }

        BackTrackSum(0, 0);
        return ans;
    }


    // 46. Permutations
    public IList<IList<int>> Permute(int[] nums)
    {
        var permutations = new List<IList<int>>();
        var permutation = new List<int>();
        var chosen = new bool[nums.Length];

        void Backtrack()
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (chosen[i])
                    continue;

                permutation.Add(nums[i]);
                if (permutation.Count == nums.Length)
                {
                    permutations.Add(new List<int>(permutation));
                }
                else
                {
                    chosen[i] = true;
                    Backtrack();
                    chosen[i] = false;
                }
                permutation.RemoveAt(permutation.Count - 1);
            }
        }

        Backtrack();
        return permutations;
    }


    // 47. Permutations II
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var permutations = new List<IList<int>>();
        var hs = new HashSet<string>();
        var permutation = new List<int>();
        var chosen = new bool[nums.Length];

        void Backtrack()
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (chosen[i])
                    continue;

                permutation.Add(nums[i]);
                if (permutation.Count == nums.Length)
                {
                    var hash = string.Join(" ", permutation);
                    if (hs.Add(hash))
                        permutations.Add(new List<int>(permutation));
                }
                else
                {
                    chosen[i] = true;
                    Backtrack();
                    chosen[i] = false;
                }
                permutation.RemoveAt(permutation.Count - 1);
            }
        }

        Backtrack();
        return permutations;
    }


    // 51. N-Queens
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>(n);

        var board = new char[n][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        var hsCols = new HashSet<int>();  // col #
        var hsDownDiag = new HashSet<int>(); // r + c
        var hsUpDiag = new HashSet<int>(); // r - c

        void Backtrack(int r)
        {
            if (r == n)
            {
                var currentBoard = new List<string>();
                foreach (var row in board)
                    currentBoard.Add(string.Join("", row));
                result.Add(currentBoard);
                return;
            }

            for (int c = 0; c < board[r].Length; c++)
            {
                if (hsCols.Contains(c) ||
                    hsDownDiag.Contains(r + c) ||
                    hsUpDiag.Contains(r - c))
                    continue;

                hsCols.Add(c);
                hsDownDiag.Add(r + c);
                hsUpDiag.Add(r - c);
                board[r][c] = 'Q';

                Backtrack(r + 1);

                board[r][c] = '.';
                hsCols.Remove(c);
                hsDownDiag.Remove(r + c);
                hsUpDiag.Remove(r - c);
            }
        }

        Backtrack(0);

        return result;
    }


    // 52. N-Queens II
    public int TotalNQueens(int n)
    {
        var total = 0;
        var board = new char[n][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        var hsCols = new HashSet<int>();  // col #
        var hsDownDiag = new HashSet<int>(); // r + c
        var hsUpDiag = new HashSet<int>(); // r - c

        void Backtrack(int r)
        {
            if (r == n)
            {
                total++;
                return;
            }

            for (int c = 0; c < board[r].Length; c++)
            {
                if (hsCols.Contains(c) ||
                    hsDownDiag.Contains(r + c) ||
                    hsUpDiag.Contains(r - c))
                    continue;

                hsCols.Add(c);
                hsDownDiag.Add(r + c);
                hsUpDiag.Add(r - c);
                board[r][c] = 'Q';

                Backtrack(r + 1);

                board[r][c] = '.';
                hsCols.Remove(c);
                hsDownDiag.Remove(r + c);
                hsUpDiag.Remove(r - c);
            }
        }

        Backtrack(0);

        return total;
    }


    // 77. Combinations
    public IList<IList<int>> Combine(int n, int k)
    {
        var ans = new List<IList<int>>();
        var combo = new List<int>();

        void Backtrack(int i)
        {
            for (int j = i; j <= n - k + combo.Count + 1; j++)
            {
                combo.Add(j);

                if (combo.Count == k)
                    ans.Add(new List<int>(combo));
                else if (j < n - k + combo.Count + 1)
                    Backtrack(j + 1);

                combo.RemoveAt(combo.Count - 1);
            }
        }

        Backtrack(1);

        return ans;
    }

    public IList<IList<int>> Combine2(int n, int k)
    {
        var iterations = 0;
        var result = new List<IList<int>>();
        for (var startNum = 1; startNum <= n - k + 1; startNum++)
        {
            FindCombinations(new List<int> { startNum });
        }

        Console.WriteLine($"Combine2: {iterations}");
        return result;

        void FindCombinations(IList<int> acc)
        {
            if (acc.Count == k)
            {
                result.Add(new List<int>(acc));
                return;
            }

            var lastNum = acc[^1];
            for (var num = lastNum + 1; num <= n - (k - acc.Count - 1); num++)
            {
                acc.Add(num);
                iterations++;
                FindCombinations(acc);
                acc.RemoveAt(acc.Count - 1);
            }
        }
    }


    // 797. All Paths From Source to Target
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var ans = new List<IList<int>>();
        var target = graph.Length - 1;

        void Dfs(List<int> path, int index)
        {
            foreach (var idx in graph[index])
            {
                path.Add(idx);
                if (idx == target)
                    ans.Add(new List<int>(path));
                else
                    Dfs(path, idx);
                path.RemoveAt(path.Count - 1);
            }
        }

        Dfs(new List<int>() { 0 }, 0);
        return ans;
    }


    // 79. Word Search
    public bool Exist(char[][] board, string word)
    {
        if (board == null)
            return false;

        if (string.IsNullOrEmpty(word))
            return true;

        var visited = new bool[board.Length, board[0].Length];

        bool BackTrack(int r, int c, int i)
        {
            if (i >= word.Length ||
                r < 0 || r == board.Length ||
                c < 0 || c == board[r].Length)
            {
                return false;
            }

            if (visited[r, c])
                return false;

            visited[r, c] = true;
            var result = false;

            if (board[r][c] == word[i])
            {
                if (i == word.Length - 1)
                {
                    result = true;
                }
                else
                {
                    result = BackTrack(r - 1, c, i + 1) ||
                        BackTrack(r + 1, c, i + 1) ||
                        BackTrack(r, c - 1, i + 1) ||
                        BackTrack(r, c + 1, i + 1);
                }
            }
            visited[r, c] = false;
            return result;
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (BackTrack(i, j, 0))
                    return true;
            }
        }
        return false;
    }


    // 93. Restore IP Addresses
    public IList<string> RestoreIpAddresses(string s)
    {
        var ans = new List<string>();
        var ip = new int[4];
        var hs = new HashSet<string>();

        bool AddDigit(char c, int block)
        {
            if (ip[block] == -1)
            {
                ip[block] = c - '0';
                return true;
            }

            var newVal = ip[block] * 10 + c - '0';
            if (newVal <= 255)
            {
                ip[block] = newVal;
                return true;
            }

            return false;
        }

        void RemoveDigit(int block)
        {
            if (ip[block] >= 10)
                ip[block] /= 10;
            else
                ip[block] = -1;
        }


        void Backtrack(int i, int blockNum, int blockVal, int pos)
        {
            if (i >= s.Length) return;

            if (blockNum == 3)
            {
                if (pos == 2)
                {
                }
            }
        }

        Backtrack(0, 0, -1, 0);

        return ans;
    }
    public IList<string> RestoreIpAddresses2(string s)
    {
        var ans = new List<string>();
        var segments = new List<int>();

        if (s.Length > 12)
            return ans;

        void Backtrack(int i)
        {
            if (i == s.Length && segments.Count == 4)
            {
                string ip = string.Join(".", segments);
                ans.Add(ip);
                return;
            }
            else
            {
                for (int len = 1; len <= 3; len++)
                {
                    var num = int.Parse(s.Substring(i, len));
                    if (num >= 0 && num <= 255)
                    {
                        segments.Add(num);
                        Backtrack(len + i);
                        segments.RemoveAt(segments.Count - 1);
                    }
                }
            }
        }

        Backtrack(0);
        return ans;
    }

    public IList<string> RestoreIpAddresses3(string s)
    {
        var li = new List<string>();
        var ans = new List<string>();
        if (s.Length > 12)
            return ans;

        bool IsValid(string str)
        {
            if (str.Length > 3)
                return false;

            int num = int.Parse(str);

            if (num < 0 || num > 255 || str.Length != num.ToString().Length)
                return false;

            return true;
        }

        void Backtrack(int st)
        {
            if (st == s.Length && li.Count == 4)
            {
                string ip = string.Join(".", li);
                ans.Add(ip);
                return;
            }

            for (int len = 1; len <= s.Length - st; len++)
            {
                string str = s.Substring(st, len);

                if (IsValid(str))
                {
                    li.Add(str);
                    Backtrack(st + len);
                    li.RemoveAt(li.Count - 1);
                }
            }
        }

        Backtrack(0);
        return ans;
    }



    // 131. Palindrome Partitioning
    public IList<IList<string>> Partition(string s)
    {
        var ans = new List<IList<string>>();
        var substrs = new List<string>();

        bool IsPalindrome(int i, int j)
        {
            while (i <= j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }

        void Backtrack(int i)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (IsPalindrome(i, j))
                {
                    substrs.Add(s.Substring(i, j - i + 1));
                    if (j == s.Length - 1)
                        ans.Add(new List<string>(substrs));
                    else
                        Backtrack(j + 1);
                    substrs.RemoveAt(substrs.Count - 1);
                }
            }
        }
        Backtrack(0);

        return ans;
    }


    // 491. Non-decreasing Subsequences
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var ans = new List<IList<int>>();
        var seq = new List<int>();
        var hs = new HashSet<string>();

        void Backtrack(int i)
        {
            for (int j = i; j < nums.Length; j++)
            {
                if (seq.Count == 0 || nums[j] >= seq[seq.Count - 1])
                {
                    seq.Add(nums[j]);
                    if (seq.Count >= 2)
                    {
                        var hash = string.Join(",", seq);
                        if (hs.Add(hash))
                            ans.Add(new List<int>(seq));
                    }
                    Backtrack(j + 1);
                    seq.RemoveAt(seq.Count - 1);
                }
            }
        }

        Backtrack(0);
        return ans;
    }


    // 78. Subsets
    public IList<IList<int>> Subsets(int[] nums)
    {
        var subsets = new List<IList<int>>();
        var subset = new List<int>();

        void Backtrack(int i)
        {
            if (i == nums.Length)
            {
                subsets.Add(new List<int>(subset));
                return;
            }

            subset.Add(nums[i]);
            Backtrack(i + 1);
            subset.RemoveAt(subset.Count - 1);

            Backtrack(i + 1);
        }

        Backtrack(0);
        return subsets;
    }


    // 2572. Count the Number of Square-Free Subsets
    public int SquareFreeSubsets(int[] nums)
    {
        var squareFreeNums = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if ((nums[i] & (nums[i] - 1)) != 0)
                squareFreeNums.Add(nums[i]);
        }

        var subset = new List<int>();
        var count = 0;

        void Backtrack(int i)
        {
            if (i == squareFreeNums.Count)
            {
                if (subset.Count > 0)
                    count++;
                return;
            }

            subset.Add(squareFreeNums[i]);
            Backtrack(i + 1);
            subset.RemoveAt(subset.Count - 1);

            Backtrack(i + 1);
        }

        Backtrack(0);
        return count;
    }


    // 980. Unique Paths III
    public int UniquePathsIII(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var startR = -1;
        var startC = -1;
        var obs = 0;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == -1)
                {
                    obs++;
                }
                else if (grid[r][c] == 1)
                {
                    startR = r;
                    startC = c;
                }
            }
        }

        // number of empty squares
        var numEmpty = rows * cols - obs;
        var count = 0;
        var visited = new bool[rows][];
        for (int r = 0; r < rows; r++)
            visited[r] = new bool[cols];

        void Backtrack(int r, int c, int numVisited)
        {
            if (r < 0 || r == rows) return;
            if (c < 0 || c == cols) return;
            if (visited[r][c] || grid[r][c] == -1) return;

            numVisited++;
            if (grid[r][c] == 2)
            {
                if (numVisited == numEmpty)
                    count++;
                numVisited--;
                return;
            }

            visited[r][c] = true;

            Backtrack(r - 1, c, numVisited);
            Backtrack(r + 1, c, numVisited);
            Backtrack(r, c - 1, numVisited);
            Backtrack(r, c + 1, numVisited);

            visited[r][c] = false;
            numVisited--;
        }

        Backtrack(startR, startC, 0);

        return count;
    }


    // 1079. Letter Tile Possibilities
    public int NumTilePossibilities(string tiles)
    {
        var visited = new bool[tiles.Length];
        var hs = new HashSet<string>();
        var sb = new StringBuilder();

        void Backtrack(int index)
        {
            if (sb.Length > 0)
                hs.Add(sb.ToString());

            if (index == tiles.Length)
                return;

            for (int i = 0; i < tiles.Length; i++)
            {
                if (visited[i])
                    continue;

                visited[i] = true;
                sb.Append(tiles[i]);
                Backtrack(index + 1);
                sb.Length--;
                visited[i] = false;
            }
        }

        Backtrack(0);

        return hs.Count;
    }
}
