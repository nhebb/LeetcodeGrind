namespace LeetcodeGrind.Solutions;

// 220. Contains Duplicate III
public class P0220
{
    private class DiffNum
    {
        public int Index { get; private set; }
        public int Value { get; private set; }
        public DiffNum(int index, int value)
        {
            Index = index;
            Value = value;
        }
    }

    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        var nums2 = new List<DiffNum>();
        for (int i = 0; i < nums.Length; i++)
        {
            nums2.Add(new DiffNum(i, nums[i]));
        }

        var sorted = nums2.OrderBy(x => x.Value)
                          .ThenBy(x => x.Index)
                          .ToList();

        for (int i = 0; i < sorted.Count - 1; i++)
        {
            var j = i + 1;
            while (j < sorted.Count &&
                   Math.Abs(sorted[j].Value - sorted[i].Value) <= valueDiff)
            {
                if (Math.Abs(sorted[j].Index - sorted[i].Index) <= indexDiff)
                    return true;
                j++;
            }
        }

        return false;
    }
}
