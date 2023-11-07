namespace LeetcodeGrind.Solutions;

// 728. Self Dividing Numbers
public class P0728
{
    public IList<int> SelfDividingNumbers(int left, int right)
    {
        bool IsSelfDividing(int n)
        {
            var val = n;
            while (n > 0)
            {
                var digit = n % 10;
                if (digit == 0)
                    return false;

                if (val % digit != 0)
                    return false;

                n /= 10;
            }
            return true;
        }

        var res = new List<int>();
        while (left <= right)
        {
            if (IsSelfDividing(left))
                res.Add(left);
            left++;
        }

        return res;
    }
}
