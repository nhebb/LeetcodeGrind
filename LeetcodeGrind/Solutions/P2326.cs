using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2326. Spiral Matrix IV
public class P2326
{
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        var minR = 1;
        var maxR = m - 1;
        var minC = 0;
        var maxC = n - 1;

        int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];

        var grid = new int[m][];
        for (int i = 0; i < m; i++)
        {
            grid[i] = new int[n];
            Array.Fill(grid[i], -1);
        }

        var index = 0;
        var dir = directions[index];

        var r = 0;
        var c = 0;

        while (head != null)
        {
            grid[r][c] = head.val;

            if (index == 0 && c == maxC)
            {
                index = 1;
                maxC--;
            }
            else if (index == 1 && r == maxR)
            {
                index = 2;
                maxR--;
            }
            else if (index == 2 && c == minC)
            {
                index = 3;
                minC++;
            }
            else if (index == 3 && r == minR)
            {
                index = 0;
                minR++;
            }

            dir = directions[index];
            r += dir[0];
            c += dir[1];

            head = head.next;
        }

        return grid;
    }
}
