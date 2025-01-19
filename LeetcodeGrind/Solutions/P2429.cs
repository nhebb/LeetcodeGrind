namespace LeetcodeGrind.Solutions;

// 2429. Minimize XOR
public class P2429
{
    public int MinimizeXor(int num1, int num2)
    {
        var count = int.PopCount(num2);
        if (count == 0)
            return 0;

        var snum1 = Convert.ToString(num1, 2);

        // 1. Build new char array x where, from left to right,
        //    all 1's in snum1 are matched in x while count > 0.
        var arrX = new char[snum1.Length];
        for (int i = 0; i < snum1.Length; i++)
        {
            if (snum1[i] == '1' && count > 0)
            {
                arrX[i] = '1';
                count--;
            }
            else
            {
                // If count == 0, the else still must be
                // done to fill arrX properly.
                arrX[i] = '0';
            }
        }

        // 2. Remaining 1's with replace 0's in x from right
        //    to left.
        if (count > 0)
        {
            for (int i = arrX.Length - 1; i >= 0; i--)
            {
                if (arrX[i] == '0')
                {
                    arrX[i] = '1';
                    count--;
                    if (count == 0)
                        break;
                }
            }
        }

        // 3. If x is all 1's prefix any remaining count to x.
        var prefix = count > 0
            ? new string('1', count)
            : "";

        // Return x converted to int.
        var x = prefix + string.Join("", arrX);
        return Convert.ToInt32(x, 2);
    }
}
