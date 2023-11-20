namespace LeetcodeGrind.Solutions;

// 1343. Number of Sub-arrays of Size K and Average Greater than or Equal to Threshold
public class P1343
{
    public int NumOfSubarrays(int[] arr, int k, int threshold)
    {
        // Get first sum before while loop
        var i = 0;
        var sum = 0;
        while (i < k)
        {
            sum += arr[i];
            i++;
        }

        // Use sliding window of length k
        var count = 0;
        i = 0;
        var j = k - 1;
        while (j < arr.Length - 1)
        {
            if (sum / k >= threshold)
                count++;

            i++;
            j++;

            sum -= arr[i - 1];
            sum += arr[j];
        }

        // Handle sum for last values of i, j
        if (sum / k >= threshold)
            count++;

        return count;
    }
}

