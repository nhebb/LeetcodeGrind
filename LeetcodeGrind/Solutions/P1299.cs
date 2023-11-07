using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1299. Replace Elements with Greatest Element on Right Side
public class P1299
{
    public int[] ReplaceElements(int[] arr)
    {
        var lastMax = -1;

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            var curMax = Math.Max(lastMax, arr[i]);
            arr[i] = lastMax;
            lastMax = curMax;
        }

        return arr;
    }

    /* I also did this one in Python3
    def replaceElements(self, arr: List[int]) -> List[int]:
        lastMax = -1
        for i in range(len(arr) -1, -1, -1):
            curMax = max(lastMax, arr[i])
            arr[i] = lastMax
            lastMax = curMax
            
        return arr
     */
}

