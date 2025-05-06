namespace LeetcodeGrind.Solutions;

// 2161. Partition Array According to Given Pivot
public class P2161
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        var lesser = new Queue<int>();
        var greater = new Queue<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < pivot)
                lesser.Enqueue(nums[i]);
            else if (nums[i] > pivot)
                greater.Enqueue(nums[i]);
        }

        var numPivots = nums.Length - (lesser.Count + greater.Count);
        var index = -1;

        while (lesser.Count > 0)
        {
            index++;
            nums[index] = lesser.Dequeue();
        }

        for (int i = 0; i < numPivots; i++)
        {
            index++;
            nums[index] = pivot;
        }

        while (greater.Count > 0)
        {
            index++;
            nums[index] = greater.Dequeue();
        }

        return nums;
    }

    public int[] PivotArray2(int[] nums, int pivot)
    {
        var result = new List<int>();
        var greater = new List<int>();
        var pivots = 0;

        foreach (var num in nums)
        {
            if (num < pivot)
                result.Add(num);
            else if (num > pivot)
                greater.Add(num);
            else
                pivots++;
        }

        while (pivots > 0)
        {
            result.Add(pivot);
            pivots--;
        }

        result.AddRange(greater);
        return result.ToArray();
    }
}
