namespace LeetcodeGrind.Solutions;

// 189. Rotate Array
// This solution is slow / barely passed
public class P0189
{
    public void Rotate(int[] nums, int k)
    {
        if (k % nums.Length == 0 || nums.Length == 1)
            return;

        k %= nums.Length;

        // save last k elements
        var arr = new int[k];
        int j = 0;
        for (int i = nums.Length - k; i < nums.Length; i++)
        {
            arr[j] = nums[i];
            j++;
        }

        // rotate 0 to len - k elements
        for (int i = nums.Length - 1; i > k - 1; i--)
            nums[i] = nums[i - k];

        // set first k elements
        for (int i = 0; i < k; i++)
            nums[i] = arr[i];
    }
}
