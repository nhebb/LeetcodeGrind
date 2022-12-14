using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.DynamicProgramming;

public class DynamicProgramming
{
    // 5. Longest Palindromic Substring
    public string LongestPalindrome(string s)
    {
        var oddSubString = GetLongestOddSubstring(s);
        var evenSubString = GetLongestEvenSubstring(s);
        return oddSubString.Length >= evenSubString.Length
            ? oddSubString
            : evenSubString;
    }

    private string GetLongestEvenSubstring(string s)
    {
        var substr = "";
        var len = 0;
        for (int i = 0; i + 1 < s.Length; i++)
        {
            var offset = 0;
            while (i - offset >= 0 && i + 1 + offset < s.Length)
            {
                if (s[i - offset] != s[i + 1 + offset])
                    break;

                var numchars = (2 * offset) + 2;
                if (numchars > len)
                {
                    len = numchars;
                    substr = s.Substring(i - offset, numchars);
                }
                offset++;
            }
        }

        return substr;
    }
    private string GetLongestOddSubstring(string s)
    {
        var substr = "";
        var len = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var offset = 0;
            while (i - offset >= 0 && i + offset < s.Length)
            {
                if (s[i - offset] != s[i + offset])
                    break;

                var numchars = (2 * offset) + 1;
                if (numchars > len)
                {
                    len = numchars;
                    substr = s.Substring(i - offset, numchars);
                }

                offset++;
            }
        }

        return substr;
    }


    // 198. House Robber
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        var dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
        }

        return dp[^1];
    }


    // 213. House Robber II
    public int RobII(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int RobDp(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            return dp[^1];
        }

        var arr1 = new ArraySegment<int>(nums, 0, nums.Length - 1).ToArray();
        var arr2 = new ArraySegment<int>(nums, 1, nums.Length - 1).ToArray();

        return Math.Max(RobDp(arr1), RobDp(arr2));
    }


    // 91. Decode Ways
    public int NumDecodings(string s)
    {
        if (s[0] == '0') return 0;
        if (s.Length == 1) return 1;

        var dp = new int[s.Length];

        dp[0] = 1;
        var num = (s[0] - '0') * 10 + s[1] - '0';
        if (num >= 10 && num <= 26)
            dp[1] = 1;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == '0')
                dp[i - 1] = 0;
            else
                dp[i] += dp[i - 1];

            if (i + 1 < s.Length)
            {
                num = (s[i] - '0') * 10 + s[i + 1] - '0';
                if (num >= 10 && num <= 26)
                    dp[i + 1] += dp[i - 1];
            }
        }

        return dp[^1];
    }


    // 300. Longest Increasing Subsequence
    public int LengthOfLIS(int[] nums)
    {
        // Bottom up solution - iterates backwards through the array
        // and sets the dp[i] value by checking every index of nums[]
        // to the right of i. If the current nums[i] value is less than
        // the checked nums[j] value, then the current LIS is set to
        // 1 + dp[j] if it's longer the existing LIS.
        var dp = new int[nums.Length];
        dp[^1] = 1;
        var maxLIS = 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            var curLIS = 1;
            for (int j = i + 1; j < dp.Length; j++)
            {
                if (nums[i] < nums[j])
                    curLIS = Math.Max(curLIS, 1 + dp[j]);
            }
            dp[i] = curLIS;
            maxLIS = Math.Max(maxLIS, curLIS);
        }

        return maxLIS;
    }


    // 1143. Longest Common Subsequence
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var dp = new int[text1.Length + 1, text2.Length + 1];

        for (int i = text1.Length - 1; i >= 0; i--)
        {
            for (int j = text2.Length - 1; j >= 0; j--)
            {
                if (text1[i] == text2[j])
                    dp[i, j] = 1 + dp[i + 1, j + 1];
                else
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
            }
        }

        return dp[0, 0];
    }

    // 62. Unique Paths
    public int UniquePaths(int m, int n)
    {
        var dp = new int[m, n];

        for (int i = 0; i < n; i++)
            dp[m - 1, i] = 1;

        for (int i = 0; i < m; i++)
            dp[i, n - 1] = 1;

        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                dp[i, j] = dp[i + 1, j] + dp[i, j + 1];
            }
        }

        return dp[0, 0];
    }


    // 63. Unique Paths II
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var lastRow = obstacleGrid.Length - 1;
        var lastCol = obstacleGrid[0].Length - 1;

        if (obstacleGrid[lastRow][lastCol] == 1 ||
            obstacleGrid[0][0] == 1)
            return 0;

        // NB: a 1 in the dp matrix represents a path count -
        // not an obstacle
        var dp = new int[lastRow + 1, lastCol + 1];
        dp[lastRow, lastCol] = 1;

        // set each cell in last column to 1 if there are no
        // obstacles defined below it
        for (int r = lastRow - 1; r >= 0; r--)
        {
            if (dp[r + 1, lastCol] == 1 && obstacleGrid[r][lastCol] == 0)
                dp[r, lastCol] = 1;
        }

        // set each cell in last row to 1 if there are no
        // obstacles defined to the right of it
        for (int c = lastCol - 1; c >= 0; c--)
        {
            if (dp[lastRow, c + 1] == 1 && obstacleGrid[lastRow][c] == 0)
                dp[lastRow, c] = 1;
        }

        for (int r = lastRow - 1; r >= 0; r--)
        {
            for (int c = lastCol - 1; c >= 0; c--)
            {
                if (obstacleGrid[r][c] == 1)
                {
                    // if there's an obstacle, the cell has no path
                    dp[r, c] = 0;
                }
                else
                {
                    // otherwise it's the sum of the path to
                    // the right plus the path down
                    dp[r, c] = dp[r + 1, c] + dp[r, c + 1];
                }
            }
        }

        return dp[0, 0];
    }


    // TODO: Finish this.
    // 834. Sum of Distances in Tree
    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        var d = new Dictionary<int, int[]>();
        var counts = new int[n];
        var totalCount = 0;
        var targetCount = n * (n - 1);

        for (int i = 0; i < n; i++)
            d[i] = new int[n];


        foreach (var edge in edges)
        {
            d[edge[0]][edge[1]] = 1;
            d[edge[1]][edge[0]] = 1;
            counts[edge[0]]++;
            counts[edge[1]]++;
            totalCount += 2;
        }

        while (totalCount < targetCount)
        {

        }

        // sum up arrays for each of the nodes
        var ans = new int[n];
        for (int i = 0; i < n; i++)
            ans[i] = d[i].Sum();

        return ans;
    }


    // 64. Minimum Path Sum
    public int MinPathSum(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var dp = new int[rows][];
        for (int r = 0; r < rows; r++)
            dp[r] = new int[cols];

        dp[rows - 1][cols - 1] = grid[rows - 1][cols - 1];

        for (int r = rows - 2; r >= 0; r--)
            dp[r][cols - 1] = grid[r][cols - 1] + dp[r + 1][cols - 1];

        for (int c = cols - 2; c >= 0; c--)
            dp[rows - 1][c] = grid[rows - 1][c] + dp[rows - 1][c + 1];

        for (int r = rows - 2; r >= 0; r--)
        {
            for (int c = cols - 2; c >= 0; c--)
            {
                dp[r][c] = Math.Min(dp[r + 1][c], dp[r][c + 1]) +
                           grid[r][c];
            }
        }

        return dp[0][0];
    }
}
