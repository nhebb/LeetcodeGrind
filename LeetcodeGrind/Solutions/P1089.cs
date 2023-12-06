namespace LeetcodeGrind.Solutions;

// 1089. Duplicate Zeros
public class P1089
{
    public void DuplicateZeros(int[] arr)
    {
        var q = new Queue<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            q.Enqueue(arr[i]);
            if (arr[i] == 0)
            {
                q.Enqueue(0);
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = q.Dequeue();
        }
    }
}
