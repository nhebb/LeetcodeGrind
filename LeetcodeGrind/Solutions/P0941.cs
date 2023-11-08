namespace LeetcodeGrind.Solutions;

// 941. Valid Mountain Array
public class P0941
{
    public bool ValidMountainArray(int[] arr)
    {
        if (arr.Length < 3)
            return false;

        var increasing = true;
        var i = 0;
        var j = arr.Length - 1;
        while (increasing && i < j)
        {
            increasing = false;
            if (arr[i] < arr[i + 1])
            {
                i++;
                increasing = true;
            }

            if (arr[j - 1] > arr[j])
            {
                j--;
                increasing = true;
            }

            if (i == j && i > 0 && j < arr.Length - 1)
                return true;
        }
        return false;
    }
}
