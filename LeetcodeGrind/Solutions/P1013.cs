namespace LeetcodeGrind.Solutions;

// 1013. Partition Array Into Three Parts With Equal Sum
public class P1013
{
    public bool CanThreePartsEqualSum(int[] arr)
    {
        var sum = arr.Sum();
        if (sum % 3 != 0)
        {
            return false;
        }

        var target = sum / 3;
        var currentSum = 0;
        var count = 0;
        var nextIndex = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            currentSum += arr[i];
            if (currentSum == target)
            {
                currentSum = 0;
                count++;
                if (count == 3)
                {
                    nextIndex = i + 1;
                    break;
                }
            }
        }

        if (nextIndex < arr.Length)
        {
            currentSum = 0;
            for (int i = nextIndex; i < arr.Length; i++)
            {
                currentSum += arr[i];
            }
        }

        return count == 3 && currentSum == 0;
    }
}
