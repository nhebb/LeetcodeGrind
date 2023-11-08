namespace LeetcodeGrind.Solutions;

// 977. Squares of a Sorted Array
public class P0977
{
    public int[] SortedSquares(int[] nums)
    {
        var arr = new int[nums.Length];
        var idx1 = 0;
        var idx2 = nums.Length - 1;
        var i = arr.Length - 1;
        while (idx1 <= idx2)
        {
            var val1 = (int)Math.Pow(nums[idx1], 2);
            var val2 = (int)Math.Pow(nums[idx2], 2);
            if (val1 > val2)
            {
                arr[i] = val1;
                idx1++;
            }
            else
            {
                arr[i] = val2;
                idx2--;
            }
            i--;
        }
        return arr;
    }
}
