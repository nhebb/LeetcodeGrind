namespace LeetcodeGrind.Solutions;

// 27. Remove Element
public class P0027
{
    public int RemoveElement(int[] nums, int val)
    {
        int validLength = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[validLength] = nums[i];
                validLength++;
            }
        }
        return validLength;
    }
}

/* Python3 version:
def removeElement(self, nums: List[int], val: int) -> int:
    validLength = 0
    for i in range(len(nums)):
        if nums[i] != val:
            nums[validLength] = nums[i]
            validLength += 1

    return validLength
 */
