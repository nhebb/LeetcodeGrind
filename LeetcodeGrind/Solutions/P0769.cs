namespace LeetcodeGrind.Solutions;

// 769. Max Chunks To Make Sorted
public class P0769
{
    public int MaxChunksToSorted(int[] arr)
    {
        // This based of the observation that the sum of
        // 0 to i is a pre-known value for every given
        // index i of the array. Every time the running
        // sum equals the calculated sum of 0 to i, we
        // can increment the chunk count.

        var sum = 0;
        var count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (sum == i * (i + 1) / 2)
            {
                count++;
            }
        }

        return count;
    }
}
