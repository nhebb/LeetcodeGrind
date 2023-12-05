namespace LeetcodeGrind.Solutions;

// 836. Rectangle Overlap
public class P0836
{
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        // rec[4] = [x1, y1, x2, y2];

        if (rec1[0] <= rec2[0])
        {
            if (rec1[2] <= rec2[0])
                return false;
        }
        else
        {
            if (rec2[2] <= rec1[0])
                return false;
        }

        if (rec1[1] <= rec2[1])
        {
            if (rec1[3] <= rec2[1])
                return false;
        }
        else
        {
            if (rec2[3] <= rec1[1])
                return false;
        }

        return true;
    }
}
