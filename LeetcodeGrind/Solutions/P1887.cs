namespace LeetcodeGrind.Solutions;

// 1887. Reduction Operations to Make the Array Elements Equal
public class P1887
{
    public int ReductionOperations(int[] nums)
    {
        Array.Sort(nums);
        var min = nums[0];

        var totalCount = 0;
        var totalSpan = 0;
        var i = nums.Length - 1;
        while (nums[i] > min)
        {
            var curSpan = 0;
            var val = nums[i];
            while (nums[i] == val)
            {
                curSpan++;
                i--;
            }
            totalSpan += curSpan;
            totalCount += totalSpan;
        }

        return totalCount;
    }
}
