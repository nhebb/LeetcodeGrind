namespace LeetcodeGrind.Solutions;

// 1823. Find the Winner of the Circular Game
public class P1823
{
    public int FindTheWinner(int n, int k)
    {
        var q = new Queue<int>(Enumerable.Range(1, n));
        //for (int i = 1; i <= n; i++)
        //    q.Enqueue(i);

        while (q.Count > 1)
        {
            var count = k;
            while (count > 0)
            {
                q.Enqueue(q.Dequeue());
                count--;
            }
            _ = q.Dequeue();
        }
        return q.Dequeue();
    }
}
