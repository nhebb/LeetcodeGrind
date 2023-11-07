namespace LeetcodeGrind.Solutions;

// 779. K-th Symbol in Grammar
public class P0779
{
    public int KthGrammar(int n, int k)
    {
        return Convert.ToString(k - 1, 2)
                      .Count(x => x == '1')
                      % 2;
    }
}
