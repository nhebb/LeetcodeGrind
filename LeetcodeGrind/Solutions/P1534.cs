namespace LeetcodeGrind.Solutions;

// 1534. Count Good Triplets
public class P1534
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        var count = 0;
        for (int i = 0; i < arr.Length - 2; i++)
        {
            for (int j = i + 1; j < arr.Length - 1; j++)
            {
                for (int k = j + 1; k < arr.Length; k++)
                {
                    /* |arr[i] - arr[j]| <= a
                     * |arr[j] - arr[k]| <= b
                     * |arr[i] - arr[k]| <= c
                     */

                    if (Math.Abs(arr[i] - arr[j]) <= a &&
                        Math.Abs(arr[j] - arr[k]) <= b &&
                        Math.Abs(arr[i] - arr[k]) <= c)
                        count++;
                }
            }
        }
        return count;
    }
}
