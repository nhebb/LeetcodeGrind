namespace LeetcodeGrind.Solutions;

// 2574. Left and Right Sum Differences
public class P2574
{
    public int[] LeftRightDifference(int[] nums)
    {
        var answer = new int[nums.Length];
        var leftSum = new int[nums.Length];
        var rightSum = new int[nums.Length];

        leftSum[0] = 0;
        for (int i = 1; i < leftSum.Length; i++)
        {
            leftSum[i] = leftSum[i - 1] + nums[i - 1];
        }

        rightSum[^1] = 0;
        for (int i = rightSum.Length - 2; i >= 0; i--)
        {
            rightSum[i] = rightSum[i + 1] + nums[i + 1];
        }

        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = Math.Abs(leftSum[i] - rightSum[i]);
        }

        return answer;
    }
}
