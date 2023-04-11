﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Matrices;

// TODO Use this for jagged array decalartion:
// var array2D = Enumerable.Range(0, m).Select(x => new int[n]).ToArray();
public class Matrices
{
    // 48. Rotate Image
    public void Rotate(int[][] matrix)
    {
        if (matrix.Length == 1) { return; }

        var offset = 0;
        var first = 0;
        var last = matrix.Length - 1;

        while (first < last)
        {
            while (first + offset < last)
            {
                var temp = matrix[first][first + offset];
                matrix[first][first + offset] = matrix[last - offset][first];
                matrix[last - offset][first] = matrix[last][last - offset];
                matrix[last][last - offset] = matrix[first + offset][last];
                matrix[first + offset][last] = temp;

                offset++;
            }
            offset = 0;
            first++;
            last--;
        }
    }


    // 54. Spiral Matrix
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var spiral = new List<int>();
        var firstRow = 0;
        var firstCol = 0;
        var lastRow = matrix.Length - 1;
        var lastCol = matrix[0].Length - 1;

        while (firstRow < lastRow && firstCol < lastCol)
        {
            // top row
            for (int c = firstCol; c <= lastCol; c++)
            {
                spiral.Add(matrix[firstRow][c]);
            }

            // right column
            for (int r = firstRow + 1; r < lastRow; r++)
            {
                spiral.Add(matrix[r][lastCol]);
            }

            // bottom row
            for (int c = lastCol; c >= firstCol; c--)
            {
                spiral.Add(matrix[lastRow][c]);
            }

            // left column
            for (int r = lastRow - 1; r > firstRow; r--)
            {
                spiral.Add(matrix[r][firstCol]);
            }

            firstRow++;
            lastRow--;
            firstCol++;
            lastCol--;

            if (firstRow == lastRow || firstCol == lastCol) { break; }
        }

        if (firstRow == lastRow && firstCol == lastCol)
        {
            spiral.Add(matrix[firstRow][firstCol]);
        }
        else if (firstRow == lastRow)
        {
            for (int c = firstCol; c <= lastCol; c++)
                spiral.Add(matrix[firstRow][c]);
        }
        else if (firstCol == lastCol)
        {
            for (int r = firstRow; r <= lastRow; r++)
                spiral.Add(matrix[r][firstCol]);
        }

        return spiral;
    }


    // 289. Game of Life
    public void GameOfLife(int[][] board)
    {
        var state = new int[board.Length][];
        for (int i = 0; i < board.Length; i++)
        {
            state[i] = new int[board[i].Length];
        }
        var lastRow = board.Length - 1;
        var lastCol = board[0].Length - 1;

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                var upLeft = r > 0 && c > 0 ? board[r - 1][c - 1] : 0;
                var up = r > 0 ? board[r - 1][c] : 0;
                var upRight = r > 0 && c < lastCol ? board[r - 1][c + 1] : 0;
                var left = c > 0 ? board[r][c - 1] : 0;
                var right = c < lastCol ? board[r][c + 1] : 0;
                var downLeft = r < lastRow && c > 0 ? board[r + 1][c - 1] : 0;
                var down = r < lastRow ? board[r + 1][c] : 0;
                var downRight = r < lastRow && c < lastCol ? board[r + 1][c + 1] : 0;

                var neighbors = upLeft + up + upRight
                              + left + right
                              + downLeft + down + downRight;

                if (neighbors < 2)
                    state[r][c] = 0;
                else if (neighbors == 2)
                    state[r][c] = board[r][c] & 1;
                else if (neighbors == 3)
                    state[r][c] = 1;
                else // neighbors >= 4
                    state[r][c] = 0;
            }
        }

        for (int i = 0; i < state.Length; i++)
        {
            state[i].CopyTo(board[i], 0);
        }
    }


    // 2373. Largest Local Values in a Matrix
    public int[][] LargestLocal(int[][] grid)
    {
        var ans = new int[grid.Length - 2][];
        for (int i = 0; i < ans.Length; i++)
            ans[i] = new int[ans.Length];

        for (int r = 1; r < grid.Length - 1; r++)
        {
            for (int c = 1; c < grid[r].Length - 1; c++)
            {
                var max = int.MinValue;
                for (int i = r - 1; i <= r + 1; i++)
                {
                    for (int j = c - 1; j <= c + 1; j++)
                    {
                        if (grid[i][j] > max)
                            max = grid[i][j];
                    }
                }
                ans[r - 1][c - 1] = max;
            }
        }

        return ans;
    }


    // 2482. Difference Between Ones and Zeros in Row and Column
    public int[][] OnesMinusZeros(int[][] grid)
    {
        var diff = new int[grid.Length][];
        for (int r = 0; r < grid.Length; r++)
        {
            diff[r] = new int[grid[r].Length];
        }

        var rowVals = new int[grid.Length];
        for (int i = 0; i < grid.Length; i++)
        {
            rowVals[i] = grid[i].Count(x => x == 1) -
                         grid[i].Count(x => x == 0);
        }

        var colVals = new int[grid[0].Length];
        for (int c = 0; c < grid[0].Length; c++)
        {
            for (int r = 0; r < grid.Length; r++)
            {
                if (grid[r][c] == 1)
                    colVals[c]++;
                else if (grid[r][c] == 0)
                    colVals[c]--;
            }
        }

        for (int r = 0; r < diff.Length; r++)
        {
            for (int c = 0; c < diff[r].Length; c++)
            {
                diff[r][c] = rowVals[r] + colVals[c];
            }
        }

        return diff;
    }


    // 59. Spiral Matrix II
    public int[][] GenerateMatrix(int n)
    {
        var matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        var count = 1;
        var offset = 0;
        var total = n * n;
        var r = 0;
        var c = 0;

        while (count <= total)
        {
            // special case for last cell in odd-length matrix
            if (count == total && n % 2 == 1)
            {
                matrix[n / 2][n / 2] = total;
                break;
            }

            r = offset;
            c = offset;

            // top row
            while (count <= total && c < n - 1 - offset)
            {
                matrix[r][c] = count;
                count++;
                c++;
            }

            // right column
            while (count <= total && r < n - 1 - offset)
            {
                matrix[r][c] = count;
                count++;
                r++;
            }

            // bottom row
            while (count <= total && c > offset)
            {
                matrix[r][c] = count;
                count++;
                c--;
            }

            // left column
            while (count <= total && r > offset)
            {
                matrix[r][c] = count;
                count++;
                r--;
            }

            offset++;
        }
        //PrintMatrix(matrix);
        return matrix;
    }


    // 1041. Robot Bounded In Circle
    public bool IsRobotBounded(string instructions)
    {
        var d = 'N';
        var x = 0;
        var y = 0;

        var DR = new Dictionary<char, char>();
        DR['N'] = 'E';
        DR['E'] = 'S';
        DR['S'] = 'W';
        DR['W'] = 'N';

        var DL = new Dictionary<char, char>();
        DL['N'] = 'W';
        DL['E'] = 'N';
        DL['S'] = 'E';
        DL['W'] = 'S';

        var radii = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            foreach (char c in instructions)
            {
                if (c == 'G')
                {
                    if (d == 'N')
                        y++;
                    else if (d == 'S')
                        y--;
                    else if (d == 'E')
                        x++;
                    else
                        x--;
                }
                else if (c == 'L')
                    d = DL[d];
                else //if (c == 'R')
                    d = DR[d];
            }
            if (x == 0 && y == 0)
                return true;

            radii.Add(x * x + y * y);
        }

        if (radii[^1] > radii[0])
            return false;

        return true;
    }


    // 657. Robot Return to Origin
    public bool JudgeCircle(string moves)
    {
        var x = 0;
        var y = 0;

        for (int i = 0; i < moves.Length; i++)
        {
            var m = moves[i];
            if (m == 'U')
                y++;
            else if (m == 'D')
                y--;
            else if (m == 'L')
                x--;
            else if (m == 'R')
                x++;
        }
        return x == 0 && y == 0;
    }
    public bool JudgeCircleLINQ(string moves)
    {
        return moves.Count(x => x == 'L') == moves.Count(x => x == 'R')
            && moves.Count(x => x == 'U') == moves.Count(x => x == 'D');
    }


    // 1252. Cells with Odd Values in a Matrix
    public int OddCells(int m, int n, int[][] indices)
    {
        var rows = new int[m];
        var cols = new int[n];

        foreach (var index in indices)
        {
            rows[index[0]]++;
            cols[index[1]]++;
        }

        var count = 0;

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if ((rows[r] + cols[c]) % 2 == 1)
                    count++;
            }
        }

        return count;
    }


    // 2536. Increment Submatrices by One
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        var ans = new int[n][];
        for (int i = 0; i < n; i++)
            ans[i] = new int[n];

        foreach (var query in queries)
        {
            for (int r = query[0]; r <= query[2]; r++)
            {
                for (int c = query[1]; c <= query[3]; c++)
                {
                    ans[r][c] += 1;
                }
            }
        }

        return ans;
    }


    // 2022. Convert 1D Array Into 2D Array
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        var ans = new int[m][];
        if (m * n != original.Length)
        {
            ans[0] = Array.Empty<int>();
            return ans;
        }

        for (int i = 0; i < m; i++)
            ans[i] = new int[n];

        for (int i = 0; i < original.Length; i++)
            ans[i / n][i % n] = original[i];

        return ans;
    }


    // 2545. Sort the Students by Their Kth Score
    public int[][] SortTheStudents(int[][] score, int k)
    {
        Array.Sort(score, (x, y) => y[k].CompareTo(x[k]));
        return score;
    }


    // 2428. Maximum Sum of an Hourglass
    public int MaxSum(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var max = 0;

        for (int r = 0; r <= rows - 3; r++)
        {
            for (int c = 0; c <= cols - 3; c++)
            {
                var sum = grid[r][c] + grid[r][c + 1] + grid[r][c + 2] +
                                       grid[r + 1][c + 1] +
                          grid[r + 2][c] + grid[r + 2][c + 1] + grid[r + 2][c + 2];

                max = Math.Max(max, sum);
            }
        }

        return max;
    }


    //909. Snakes and Ladders
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length;
        Array.Reverse(board);

        var visited = new bool[n * n + 1];
        var queue = new Queue<(int position, int moves)>();
        queue.Enqueue((1, 0));

        // local expression body members to map position to
        // 0-based row and column indices
        int GetRow(int pos) => (pos - 1) / n;

        int GetCol(int pos, bool even) => even
            ? (pos - 1) % n             // left to right index
            : n - 1 - ((pos - 1) % n);  // right to left index

        while (queue.Any())
        {
            var curr = queue.Dequeue();
            for (int i = 1; i <= 6; i++)
            {
                int next = curr.position + i;
                var r = GetRow(next);
                var c = GetCol(next, r % 2 == 0);

                if (board[r][c] != -1)
                    next = board[r][c];

                if (next == n * n)
                    return curr.moves + 1;

                if (!visited[next])
                {
                    visited[next] = true;
                    queue.Enqueue((next, curr.moves + 1));
                }
            }
        }
        return -1;
    }


    // 498. Diagonal Traverse
    public int[] FindDiagonalOrder(int[][] mat)
    {
        var ans = new List<int>(mat.Length * mat[0].Length);
        var bottom = mat.Length - 1;
        var right = mat[0].Length - 1;
        var startPos = new int[bottom + right + 1, 2];

        for (int i = 0; i < startPos.GetLength(0); i++)
        {
            startPos[i, 0] = i % 2 == 0
                ? Math.Min(i, bottom)
                : Math.Max(0, i - right);
            startPos[i, 1] = i % 2 == 0
                ? Math.Max(0, i - bottom)
                : Math.Min(i, right);
        }

        for (int i = 0; i < startPos.GetLength(0); i++)
        {
            var r = startPos[i, 0];
            var c = startPos[i, 1];
            if (i % 2 == 0)
                while (r >= 0 && c <= right)
                    ans.Add(mat[r--][c++]);
            else
                while (r <= bottom && c >= 0)
                    ans.Add(mat[r++][c--]);

        }
        return ans.ToArray();
    }


    // 130. Surrounded Regions
    public void Solve(char[][] board)
    {
        var rows = board.Length;
        var cols = board[0].Length;

        var connected = new bool[rows][];
        for (int r = 0; r < board.Length; r++)
            connected[r] = new bool[cols];

        void Dfs(int r, int c)
        {
            if (r < 0 || r >= rows) return;
            if (c < 0 || c >= cols) return;
            if (connected[r][c]) return;
            if (board[r][c] == 'X') return;

            connected[r][c] = true;

            Dfs(r - 1, c);
            Dfs(r + 1, c);
            Dfs(r, c - 1);
            Dfs(r, c + 1);
        }

        // Iterate over the edges and Dfs inward to mark squares
        // as connected to an outside (unsurrounded) edge square
        // top row
        for (int c = 0; c < cols; c++)
            if (board[0][c] == 'O')
                Dfs(0, c);

        // bottom row
        for (int c = 0; c < cols; c++)
            if (board[rows - 1][c] == 'O')
                Dfs(rows - 1, c);

        // left edge
        for (int r = 0; r < rows; r++)
            if (board[r][0] == 'O')
                Dfs(r, 0);

        // right edge
        for (int r = 0; r < rows; r++)
            if (board[r][cols - 1] == 'O')
                Dfs(r, cols - 1);

        // Flip any non-connected 'O' squares to 'X'
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                if (board[r][c] == 'O' && !connected[r][c])
                    board[r][c] = 'X';
    }


    // 1162. As Far from Land as Possible
    public int MaxDistance(int[][] grid)
    {
        var searchVal = 1;
        var markVal = 2;
        var maxDist = 0;
        var hasZeroes = true;
        var lastRow = grid.Length - 1;
        var lastCol = grid[0].Length - 1;

        while (hasZeroes)
        {
            hasZeroes = false;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] != searchVal) continue;

                    var updated = false;
                    if (r > 0 && grid[r - 1][c] == 0)
                    {
                        grid[r - 1][c] = markVal;
                        updated = true;
                    }
                    if (r < lastRow && grid[r + 1][c] == 0)
                    {
                        grid[r + 1][c] = markVal;
                        updated = true;
                    }
                    if (c > 0 && grid[r][c - 1] == 0)
                    {
                        grid[r][c - 1] = markVal;
                        updated = true;
                    }
                    if (c < lastCol && grid[r][c + 1] == 0)
                    {
                        grid[r][c + 1] = markVal;
                        updated = true;
                    }
                    if (updated)
                    {
                        hasZeroes = true;
                        if (markVal > maxDist)
                            maxDist = markVal;
                    }
                }
            }
            searchVal++;
            markVal++;
        }

        // markVal is always 1 greater than the distance, so
        // decrement by 1 when returning
        return maxDist - 1;
    }


    // 1314. Matrix Block Sum
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        int GetSum(int i, int j)
        {
            var firstRow = Math.Max(i - k, 0);
            var firstCol = Math.Max(j - k, 0);
            var lastRow = Math.Min(i + k, mat.Length - 1);
            var lastCol = Math.Min(j + k, mat[0].Length - 1);

            var sum = 0;
            for (int r = firstRow; r <= lastRow; r++)
                for (int c = firstCol; c <= lastCol; c++)
                    sum += mat[r][c];

            return sum;
        }

        var ans = new int[mat.Length][];
        for (int r = 0; r < mat.Length; r++)
        {
            ans[r] = new int[mat[r].Length];
            for (int c = 0; c < mat[r].Length; c++)
                ans[r][c] = GetSum(r, c);
        }

        return ans;
    }


    // 2017. Grid Game
    public long GridGame(int[][] grid)
    {
        var pre = new long[grid[0].Length];
        pre[0] = grid[0][0];
        for (int c = 1; c < grid[0].Length; c++)
            pre[c] = pre[c - 1] + grid[0][c];

        var post = new long[grid[0].Length];
        post[^1] = grid[1][^1];
        for (int c = grid[1].Length - 2; c >= 0; c--)
            post[c] = post[c + 1] + grid[1][c];

        long min = long.MaxValue;
        var i = 0;
        while (i < grid[0].Length)
        {
            min = Math.Min(min,
                Math.Max(pre[^1] - pre[i], post[0] - post[i]));
            i++;
        }

        return min;
    }


    // 566. Reshape the Matrix
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        var r0 = mat.Length;
        var c0 = mat[0].Length;

        if (r * c != r0 * c0)
            return mat;

        var ans = new int[r][];
        ans[0] = new int[c];
        int r1 = 0;
        int c1 = 0;

        for (int i = 0; i < r0; i++)
        {
            for (int j = 0; j < c0; j++)
            {
                ans[r1][c1] = mat[i][j];
                c1++;
                if (c1 == c)
                {
                    r1++;
                    c1 = 0;
                    ans[r1] = new int[c];
                }
            }
        }

        return ans;
    }


    // 2352. Equal Row and Column Pairs
    public int EqualPairs(int[][] grid)
    {
        var dictRows = new Dictionary<string, int>();
        for (int r = 0; r < grid.Length; r++)
        {
            var s = string.Join(',', grid[r]);
            if (dictRows.TryGetValue(s, out int value))
                dictRows[s] = value + 1;
            else
                dictRows[s] = 1;
        }

        var dictCols = new Dictionary<string, int>();
        var nums = new List<int>(grid.Length);
        for (int c = 0; c < grid.Length; c++)
        {
            for (int r = 0; r < grid.Length; r++)
            {
                nums.Add(grid[r][c]);
            }

            var s = string.Join(',', nums);
            if (dictCols.TryGetValue(s, out int value))
                dictCols[s] = value + 1;
            else
                dictCols[s] = 1;

            nums.Clear();
        }

        var count = 0;
        foreach (var kvp in dictRows)
        {
            if (dictCols.ContainsKey(kvp.Key))
                count += kvp.Value * dictCols[kvp.Key];
        }

        return count;
    }


    // 733. Flood Fill
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        if (image == null || image.Length == 0 || image[sr][sc] == newColor)
            return image;

        var oldColor = image[sr][sc];

        void FillCell(int sr, int sc)
        {
            if (sr < 0 || sc < 0 || sr >= image.Length || sc >= image[0].Length)
                return;

            if (image[sr][sc] == oldColor)
            {
                image[sr][sc] = newColor;

                FillCell(sr - 1, sc);
                FillCell(sr + 1, sc);
                FillCell(sr, sc - 1);
                FillCell(sr, sc + 1);
            }
        }

        FillCell(sr, sc);
        return image;
    }


    // 695. Max Area of Island
    public int MaxAreaOfIsland(int[][] grid)
    {
        if (grid == null)
            return 0;

        int maxArea = 0;

        int IslandDFS(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[i].Length ||
                grid[i][j] == 0)
                return 0;

            grid[i][j] = 0;

            return 1 + IslandDFS(grid, i + 1, j)
                     + IslandDFS(grid, i - 1, j)
                     + IslandDFS(grid, i, j + 1)
                     + IslandDFS(grid, i, j - 1);
        }

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    var area = IslandDFS(grid, i, j);
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        return maxArea;
    }


    // 542. 01 Matrix
    public int[][] UpdateMatrix(int[][] mat)
    {
        var rows = mat.Length;
        var cols = mat[0].Length;

        var ans = new int[rows][];
        for (int r = 0; r < rows; r++)
        {
            ans[r] = new int[cols];
            Array.Fill(ans[r], int.MaxValue);
        }

        // initialize ans with 0's
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (mat[r][c] == 0)
                    ans[r][c] = 0;
            }
        }

        var target = 0;
        var updated = true;
        var visited = new HashSet<(int, int)>();

        bool UpdateCell(int r, int c, int dist)
        {
            if (r < 0 || r == rows) return false;
            if (c < 0 || c == cols) return false;
            if (ans[r][c] <= dist) return false;
            if (visited.Contains((r, c))) return false;

            ans[r][c] = Math.Min(ans[r][c], dist + 1);
            visited.Add((r, c));

            return true;
        }

        while (updated)
        {
            updated = false;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (mat[r][c] != target)
                        continue;

                    updated |= UpdateCell(r - 1, c, target);
                    updated |= UpdateCell(r + 1, c, target);
                    updated |= UpdateCell(r, c - 1, target);
                    updated |= UpdateCell(r, c + 1, target);
                }
            }
            target++;
            visited.Clear();
        }

        return ans;
    }
}
