namespace LeetcodeGrind.Solutions;

// 3274. Check if Two Chessboard Squares Have the Same Color
public class P3274
{
    public bool CheckTwoChessboards(string coordinate1, string coordinate2)
    {
        var sq1 = Math.Abs((coordinate1[0] - 'a') - (coordinate1[1] - '1')) % 2;
        var sq2 = Math.Abs((coordinate2[0] - 'a') - (coordinate2[1] - '1')) % 2;
        return sq1 == sq2;
    }
}
