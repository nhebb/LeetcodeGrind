namespace LeetcodeGrind.Solutions;

// 1769. Minimum Number of Operations to Move All Balls to Each Box
public class P1769
{
    public int[] MinOperations(string boxes)
    {
        var moves = new int[boxes.Length];

        var leftCount = 0;
        var leftMoves = 0;
        var rightCount = 0;
        var rightMoves = 0;

        for (int i = 1; i < boxes.Length; i++)
        {
            if (boxes[i] == '1')
            {
                rightCount++;
                rightMoves += i;
            }
        }

        moves[0] = rightMoves;
        for (int i = 1; i < boxes.Length; i++)
        {
            if (boxes[i - 1] == '1')
                leftCount++;
            leftMoves += leftCount;

            rightMoves -= rightCount;
            if (boxes[i] == '1')
                rightCount--;

            moves[i] = leftMoves + rightMoves;
        }

        return moves;
    }
}
