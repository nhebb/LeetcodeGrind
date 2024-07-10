namespace LeetcodeGrind.Solutions;

// 3200. Maximum Height of a Triangle
public class P3200
{
    public int MaxHeightOfTriangle(int red, int blue)
    {
        return Math.Max(GetHeight(red, blue), GetHeight(blue, red));
    }

    private int GetHeight(int first, int second)
    {
        var isFirst = true;
        var height = 0;
        var row = 1;

        while (first >= 0 && second >= 0)
        {
            if (isFirst)
            {
                first -= row;
                if (first >= 0)
                {
                    height++;
                    row++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                second -= row;
                if (second >= 0)
                {
                    height++;
                    row++;
                }
                else
                {
                    break;
                }
            }

            isFirst = !isFirst;
            if (isFirst && first == 0 || !isFirst && second == 0)
            {
                break;
            }
        }

        return height;
    }
}
