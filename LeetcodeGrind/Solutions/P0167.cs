namespace LeetcodeGrind.Solutions;

// 167. Two Sum II - Input Array Is Sorted
public class P0167
{
    public int[] TwoSumII(int[] numbers, int target)
    {
        int i = 0;
        int j = numbers.Length - 1;
        while (true)
        {
            var sum = numbers[i] + numbers[j];
            if (sum == target)
                return new int[] { i + 1, j + 1 };
            else if (sum < target)
                i++;
            else
                j--;
        }
    }
}
