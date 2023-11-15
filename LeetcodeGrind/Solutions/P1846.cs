namespace LeetcodeGrind.Solutions;

// 1846. Maximum Element After Decreasing and Rearranging
public class P1846
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        Array.Sort(arr);
        arr[0] = 1;

        // This solution is a bit of a "trick" answer.
        // It is based on the idea that the max number
        // can only be 1 more than the 2nd biggest number,
        // which in turn can only be 1 more than the 3rd
        // biggest number, and so on, until the base case
        // of 1 (arr[0]).
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] > 1)
            {
                arr[i] = arr[i - 1] + 1;
            }
        }

        return arr[^1];
    }
}
