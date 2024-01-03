namespace LeetcodeGrind.Solutions;

// 1863. Sum of All Subset XOR Totals
public class P1863
{
    public int SubsetXORSum(int[] nums)
    {
        int SubsetXORSumHelper(int i, int sum)
        {
            return i == nums.Length
            ? sum 
            : SubsetXORSumHelper(i + 1, sum ^ nums[i]) +
              SubsetXORSumHelper(i + 1, sum);
        }

        return SubsetXORSumHelper(0, 0);
    }
}
