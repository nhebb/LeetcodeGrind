namespace LeetcodeGrind.Solutions;

// 1346. Check If N and Its Double Exist
public class P1346
{
    public bool CheckIfExist(int[] arr)
    {
        var hs = arr.ToHashSet();
        hs.Remove(0);

        foreach (var num in arr)
        {
            if (hs.Contains(num * 2))
            {
                return true;
            }
        }

        return arr.Count(x => x == 0) >= 2;
    }
}
