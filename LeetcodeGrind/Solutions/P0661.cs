namespace LeetcodeGrind.Solutions;

// 661. Image Smoother
public class P0661
{
    public int[][] ImageSmoother(int[][] img)
    {
        var img2 = new int[img.Length][];
        for (int i = 0; i < img2.Length; i++)
        {
            img2[i] = new int[img[i].Length];
        }

        for (int r = 0; r < img.Length; r++)
        {
            for (int c = 0; c < img[r].Length; c++)
            {
                var count = 1;
                var sum = img[r][c];

                // left column
                if (r - 1 >= 0 && c - 1 >= 0)
                {
                    count++;
                    sum += img[r - 1][c - 1];
                }
                if (c - 1 >= 0)
                {
                    count++;
                    sum += img[r][c - 1];
                }
                if (r + 1 < img.Length && c - 1 >= 0)
                {
                    count++;
                    sum += img[r + 1][c - 1];
                }

                // top / bottom
                if (r - 1 >= 0)
                {
                    count++;
                    sum += img[r - 1][c];
                }
                if (r + 1 < img.Length)
                {
                    count++;
                    sum += img[r + 1][c];
                }

                // right column
                if (r - 1 >= 0 && c + 1 < img[r].Length)
                {
                    count++;
                    sum += img[r - 1][c + 1];
                }
                if (c + 1 < img[r].Length)
                {
                    count++;
                    sum += img[r][c + 1];
                }
                if (r + 1 < img.Length && c + 1 < img[r].Length)
                {
                    count++;
                    sum += img[r + 1][c + 1];
                }

                img2[r][c] = sum / count;
            }
        }

        return img2;
    }
}
