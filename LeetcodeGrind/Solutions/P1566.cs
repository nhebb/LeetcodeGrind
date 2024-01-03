namespace LeetcodeGrind.Solutions;

// 1566. Detect Pattern of Length M Repeated K or More Times
public class P1566
{
    public bool ContainsPattern(int[] arr, int m, int k)
    {
        var matches = 0;
        var target = m * (k - 1); // # consecutive matches needed

        for (int i = 0; i < arr.Length - m; i++)
        {
            if (arr[i] == arr[i + m])
            {
                matches++;
                if (matches == target)
                {
                    return true;
                }
            }
            else
            {
                matches = 0;
            }
        }

        return false;
    }
}
