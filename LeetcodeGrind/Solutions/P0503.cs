namespace LeetcodeGrind.Solutions;

// 503. Next Greater Element II
/* Given a circular integer array nums (i.e., the next element of 
 * nums[nums.length - 1] is nums[0]), return the next greater number
 * for every element in nums.
 * 
 * The next greater number of a number x is the first greater number 
 * to its traversing-order next in the array, which means you could 
 * search circularly to find its next greater number. If it doesn't exist,
 * return -1 for this number.
 * */
public class P0503
{
    public int[] NextGreaterElements(int[] nums)
    {
        var ans = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            var found = false;
            var j = (i + 1) % nums.Length;
            while (true)
            {
                if (i == j) break;

                if (nums[j] > nums[i])
                {
                    ans[i] = nums[j];
                    found = true;
                    break;
                }
                j = (j + 1) % nums.Length;
            }
            if (!found)
                ans[i] = -1;
        }
        return ans;
    }
}
