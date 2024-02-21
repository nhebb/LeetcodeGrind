namespace LeetcodeGrind.Solutions;

// 1642. Furthest Building You Can Reach
public class P1642
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        var diffs = new PriorityQueue<int, int>();

        for (int i = 0; i < heights.Length - 1; i++)
        {
            var diff = heights[i + 1] - heights[i];

            if (diff > 0)
            {
                diffs.Enqueue(diff, diff);
            }

            if (diffs.Count > ladders)
            {
                bricks -= diffs.Dequeue();
            }

            if (bricks < 0)
            {
                return i;
            }
        }

        return heights.Length - 1;
    }
}
