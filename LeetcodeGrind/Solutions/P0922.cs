namespace LeetcodeGrind.Solutions;

// 922. Sort Array By Parity II
public class P0922
{
    public int[] SortArrayByParityII(int[] nums)
    {
        var odds = new List<int>();
        var evens = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i % 2 == 0 && nums[i] % 2 == 1)
                evens.Add(i);
            if (i % 2 == 1 && nums[i] % 2 == 0)
                odds.Add(i);
        }

        for (int i = 0; i < odds.Count; i++)
        {
            (nums[odds[i]], nums[evens[i]]) = (nums[evens[i]], nums[odds[i]]);
        }

        return nums;
    }
}
