namespace LeetcodeGrind.Solutions;

// 279. Perfect Squares
// TODO: Finish this
public class P0279
{
    public int NumSquares(int n)
    {
        var squares = new List<int>();
        var i = 1;

        while (i * i <= n)
        {
            squares.Add(i * i);
            i++;
        }

        var ans = new List<int>();

        return ans.Count;
    }
}
