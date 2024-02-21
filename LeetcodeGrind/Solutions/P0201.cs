namespace LeetcodeGrind.Solutions;

// 201. Bitwise AND of Numbers Range
public class P0201
{
    public int RangeBitwiseAnd(int left, int right)
    {
        while (right > left)
        {
            right &= right - 1;
        }
        return right;
    }
}
