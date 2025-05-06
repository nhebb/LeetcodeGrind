using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2140. Solving Questions With Brainpower
public class P2140
{
    public long MostPoints(int[][] questions)
    {
        var points = new int[questions.Length];

        int GetMax(int index, int offset)
        {
            if (index + offset >= questions.Length)
                return questions[index][0];
            else
                return Math.Max(questions[index][0], points[index + offset]);
        }

        points[^1] = questions[^1][0];
        for (int i = questions.Length - 2; i >= 0; i--)
        {
            var brainpower = questions[i][1];
            points[i] = GetMax(i, brainpower);
        }

        return points[0];
    }
}
