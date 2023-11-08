namespace LeetcodeGrind.Solutions;

// 31. Next Permutation - two solutions
public class P0031
{
    public void NextPermutation(int[] nums)
    {
        // 45123 -> 45132 -> 45213 -> 45231 -> 45312 -> 45321 -> 54321 -> 12345
        // 53421 -> 54123
        if (nums.Length == 1) return;

        // if the last 2 are reversed, just swap and return
        if (nums[^2] < nums[^1])
        {
            (nums[^2], nums[^1]) = (nums[^1], nums[^2]);
            return;
        }

        // Moving right to left, find num less than previous 
        int i = nums.Length - 3;
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;

        // If we reach i == -1, then nums is reverse order
        if (i == -1)
        {
            Array.Sort(nums);
            return;
        }

        // Find the next element >= nums[i].
        var greaterVal = int.MaxValue;
        var greaterIndex = -1;
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[j] >= nums[i] && nums[j] < greaterVal)
            {
                greaterIndex = j;
                greaterVal = nums[j];
            }
        }

        // Add values from i to end of nums - except greaterVal - to a list.
        // Assign greaterVal to nums[i], then copy the sorted list to the
        // end of nums, after i
        var tailNums = new List<int>();
        tailNums.Add(nums[i]);
        nums[i] = greaterVal;
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (j == greaterIndex) continue;
            tailNums.Add(nums[j]);
        }

        tailNums.OrderBy(x => x)
                .ToArray()
                .CopyTo(nums, i + 1);
    }

    public void NextPermutation2(int[] nums)
    {
        if (nums.Length == 1)
            return;

        // O(n) reverse instead of sort
        void Reverse(int i, int j)
        {
            while (i < j)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
                j--;
            }
        }

        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;

        // Existing array is monotonically decreasing, so next permutation
        // is just a sorted version of original
        if (i == -1)
        {
            Array.Sort(nums);
            return;
        }

        int j = nums.Length - 1;
        while (j > i && nums[i] >= nums[j])
            j--;

        (nums[i], nums[j]) = (nums[j], nums[i]);

        Reverse(i + 1, nums.Length - 1);
    }
}
