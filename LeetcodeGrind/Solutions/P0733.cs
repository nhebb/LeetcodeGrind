namespace LeetcodeGrind.Solutions;

// 733. Flood Fill
public class P0733
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        if (image == null || image.Length == 0 || image[sr][sc] == newColor)
            return image;

        var oldColor = image[sr][sc];

        void FillCell(int sr, int sc)
        {
            if (sr < 0 || sc < 0 || sr >= image.Length || sc >= image[0].Length)
                return;

            if (image[sr][sc] == oldColor)
            {
                image[sr][sc] = newColor;

                FillCell(sr - 1, sc);
                FillCell(sr + 1, sc);
                FillCell(sr, sc - 1);
                FillCell(sr, sc + 1);
            }
        }

        FillCell(sr, sc);

        return image;
    }
}

