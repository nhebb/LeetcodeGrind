using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
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


    // 926. Flip String to Monotone Increasing
    public int MinFlipsMonoIncr(string s)
    {
        var numZeroes = s.Count(c => c == '0');
        var numOnes = s.Length - numZeroes;
        var minFlips = Math.Min(numZeroes, numOnes);
        var rightZeroes = numZeroes;
        var leftOnes = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
                rightZeroes--;
            else
                leftOnes++;

            minFlips = Math.Min(minFlips, leftOnes + rightZeroes);
        }

        return minFlips;
    }


    // 119. Pascal's Triangle II
    public IList<int> GetRow(int rowIndex)
    {
        // alternate solution using combinatorial math
        // cell val = r! / c!(r - c)!, where r and c
        // are the 0-based row and column indices.
        if (rowIndex == 0)
            return new List<int>() { 1 };

        if (rowIndex == 1)
            return new List<int>() { 1, 1 };

        var triangle = new int[rowIndex + 1][];
        triangle[0] = new int[1] { 1 };
        triangle[1] = new int[2] { 1, 1 };
        for (int row = 2; row <= rowIndex; row++)
        {
            triangle[row] = new int[row + 1];
            triangle[row][0] = 1;
            triangle[row][^1] = 1;

            for (int col = 1; col < triangle[row].Length - 1; col++)
            {
                triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
            }
        }

        return triangle[rowIndex];
    }


    // 120. Triangle
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var dp = new int[triangle.Count][];
        dp[dp.Length - 1] = new int[dp.Length];
        for (int c = 0; c < dp.Length; c++)
            dp[dp.Length - 1][c] = triangle[dp.Length - 1][c];

        for (int r = dp.Length - 2; r >= 0; r--)
        {
            dp[r] = new int[r + 1];
            for (int c = 0; c < r + 1; c++)
            {
                var val = triangle[r][c];
                dp[r][c] = Math.Min(val + dp[r + 1][c], val + dp[r + 1][c + 1]);
            }
        }

        return dp[0][0];
    }


    // 1626. Best Team With No Conflicts
    public int BestTeamScore(int[] scores, int[] ages)
    {
        var n = scores.Length;

        // sort scores by age then score
        var scores2 = Enumerable.Range(0, n)
                                .OrderBy(x => ages[x])
                                .ThenBy(x => scores[x])
                                .Select(x => scores[x])
                                .ToArray();

        int[] dp = new int[n];
        dp[^1] = scores2[^1];

        for (int i = n - 2; i >= 0; i--)
        {
            // Find the higher scores to the right of the current
            // score, select their dp[] values, and add the max
            // one to the current score
            dp[i] = scores2[i] +
                    Enumerable.Range(i + 1, n - i - 1)
                              .Where(x => scores2[x] >= scores2[i])
                              .Select(x => dp[x])
                              .DefaultIfEmpty(0)
                              .Max();
        }

        // return the highest team score in the dp tabulation
        return dp.Max();
    }


    // 334. Increasing Triplet Subsequence
    public bool IncreasingTriplet(int[] nums)
    {

        var mins = new int[nums.Length];
        var maxs = new int[nums.Length];

        // Create prefix array of minimum values to the left
        mins[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            mins[i] = Math.Min(nums[i], mins[i - 1]);
        }

        // Create postfix array of maximum values to the right
        maxs[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            maxs[i] = Math.Max(nums[i], maxs[i + 1]);
        }

        // check if current value is between mins and maxs
        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (mins[i - 1] < nums[i] && nums[i] < maxs[i + 1])
                return true;
        }

        return false;
    }


    // 746. Min Cost Climbing Stairs
    public int MinCostClimbingStairs(int[] cost)
    {
        if (cost.Length == 2)
            return Math.Min(cost[0], cost[1]);

        var dp = new int[cost.Length];
        dp[^1] = cost[^1];
        dp[^2] = cost[^2];

        for (int i = dp.Length - 3; i >= 0; i--)
        {
            dp[i] = Math.Min(cost[i] + dp[i + 1], cost[i] + dp[i + 2]);
        }

        return Math.Min(dp[0], dp[1]);
    }
}
