namespace LeetcodeGrind.Solutions;

// 456. 132 Pattern
// Credit goes to:
// https://leetcode.com/problems/132-pattern/solutions/4107421/99-35-stack-left-approach-binary-search/
public class P0456
{
    public bool Find132pattern(int[] nums)
    {
        if (nums.Length < 3)
            return false;


        var third = int.MinValue;
        var stack = new Stack<int>();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] < third)
                return true;

            while (stack.Count > 0 && stack.Peek() < nums[i])
                third = stack.Pop();

            stack.Push(nums[i]);
        }

        return false;
    }
}
