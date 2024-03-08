namespace LeetcodeGrind.Solutions;

// 3069. Distribute Elements Into Two Arrays I
public class P3069
{
    public int[] ResultArray(int[] nums)
    {
        var arr1 = new List<int>(nums.Length) { nums[0] };
        var arr2 = new List<int>() { nums[1] };

        for (int i = 2; i < nums.Length; i++)
        {
            if (arr1[^1] > arr2[^1])
                arr1.Add(nums[i]);
            else
                arr2.Add(nums[i]);
        }

        arr1.AddRange(arr2);
        return arr1.ToArray();
    }
}
