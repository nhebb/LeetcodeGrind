namespace LeetcodeGrind.Solutions;

// 367. Valid Perfect Square
public class P0367
{
    public bool IsPerfectSquare(int num)
    {
        // Easy way:
        //var sqrt = (int)Math.Sqrt(num);
        //return num == (sqrt * sqrt);

        // Binary search method:
        if (num == 1)
            return true;

        bool BinarySearch(long idx1, long idx2)
        {
            if (idx1 > idx2) return false;

            long mid = idx1 + (idx2 - idx1) / 2;
            if (mid * mid == num)
                return true;

            if (mid * mid < num)
            {
                if ((mid + 1) * (mid + 1) > num)
                    return false;
                return BinarySearch(mid + 1, idx2);
            }
            else
            {
                if ((mid - 1) * (mid - 1) < num)
                    return false;
                return BinarySearch(idx1, mid - 1);
            }
        }

        return BinarySearch(1, num);
    }
}
