namespace LeetcodeGrind.Solutions;

// 989. Add to Array-Form of Integer
public class P0989
{
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        // 2,1,5 806
        var res = new List<int>();

        var carry = 0;
        var i = num.Length - 1;
        while (k > 0 && i >= 0)
        {
            var val = carry + num[i] + k % 10;
            res.Add(val % 10);
            carry = val / 10;
            k /= 10;
            i--;
        }

        while (k > 0)
        {
            var val = carry + k % 10;
            res.Add(val % 10);
            carry = val / 10;
            k /= 10;
        }

        while (i >= 0)
        {
            var val = carry + num[i];
            res.Add(val % 10);
            carry = val / 10;
            i--;
        }

        if (carry > 0)
            res.Add(carry);

        res.Reverse();
        return res;
    }
}
