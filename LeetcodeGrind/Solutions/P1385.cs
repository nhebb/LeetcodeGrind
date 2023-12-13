namespace LeetcodeGrind.Solutions;

// 1385. Find the Distance Value Between Two Arrays
public class P1385
{
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        var distance = arr1.Length;

        for (int i = 0; i < arr1.Length; i++)
        {
            for (int j = 0; j < arr2.Length; j++)
            {
                if (Math.Abs(arr1[i] - arr2[j]) <= d || Math.Abs(arr1[i] - arr2[j]) <= d)
                {
                    distance--;
                    break;
                }
            }
        }

        return distance;
    }
}
