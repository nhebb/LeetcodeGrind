using System;
using System.Collections.Generic;
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

        void BackTrackSum(List<int> combo, int start, int sum)
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
                    BackTrackSum(combo, i, sum);
                }
            }
            sum -= candidates[start];
            combo.RemoveAt(combo.Count - 1);
        }

        for (int i = 0; i < candidates.Length; i++)
        {
            var sum = 0;
            var combo = new List<int>();
            BackTrackSum(combo, i, sum);
        }

        return ans.Distinct().ToList(); ;
    }


    // 46. Permutations
    public IList<IList<int>> Permute(int[] nums)
    {
        var permutations = new List<IList<int>>();
        var permutation = new List<int>();
        var chosen = new bool[nums.Length];

        void Backtrack()
        {
            if (permutation.Count == nums.Length)
            {
                permutations.Add(new List<int>(permutation));
                return;
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (chosen[i])
                        continue;

                    permutation.Add(nums[i]);
                    chosen[i] = true;
                    Backtrack();
                    chosen[i] = false;
                    permutation.RemoveAt(permutation.Count - 1);
                }
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
}
