namespace LeetcodeGrind.Solutions;

// 3354. Make Array Elements Equal to Zero
public class P3354
{
    public int CountValidSelections(int[] nums)
    {
        int Move(int i, int dir)
        {
            var nums2 = new int[nums.Length];
            Array.Copy(nums, nums2, nums2.Length);

            i += dir;
            while (i >= 0 && i < nums2.Length)
            {
                if (nums2[i] > 0)
                {
                    nums2[i]--;
                    dir *= -1;
                }

                i += dir;
            }

            return nums2.Where(x => x == 0).Count() == nums2.Length
                ? 1
                : 0;
        }

        var zeroIndexes = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                zeroIndexes.Add(i);
            }
        }

        var count = 0;
        foreach (var index in zeroIndexes)
        {
            count += Move(index, -1);
            count += Move(index, 1);
        }

        return count;
    }
}
