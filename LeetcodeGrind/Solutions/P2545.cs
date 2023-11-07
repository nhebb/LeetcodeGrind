namespace LeetcodeGrind.Solutions;

// 2545. Sort the Students by Their Kth Score
public class P2545
{
    public int[][] SortTheStudents(int[][] score, int k)
    {
        Array.Sort(score, (x, y) => y[k].CompareTo(x[k]));
        return score;
    }
}
