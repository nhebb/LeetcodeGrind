namespace LeetcodeGrind.Solutions;

// 1792. Maximum Average Pass Ratio
public class P1792
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        var pq = new PriorityQueue<(int pass, int total), double>(classes.Length);

        foreach (var c in classes)
        {
            double delta = ((c[0] + 1) / (double)(c[1] + 1)) - c[0] / (double)c[1];
            pq.Enqueue((c[0], c[1]), -delta);
        }

        while (extraStudents > 0)
        {
            var item = pq.Dequeue();
            var pass = item.pass;
            var total = item.total;
            pass++;
            total++;
            double newDelta = ((pass + 1) / (double)(total + 1)) - (pass / (double)total);
            pq.Enqueue((pass, total), -newDelta);
            extraStudents--;
        }

        var sum = 0.0;
        while (pq.Count > 0)
        {
            var item = pq.Dequeue();
            sum += item.pass / (double)item.total;
        }

        return sum / classes.Length;
    }
}