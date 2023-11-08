namespace LeetcodeGrind.Solutions;

// 605. Can Place Flowers
public class P0605
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        // edge cases
        if (n == 0) return true;
        if (n > flowerbed.Length / 2 + 1) return false;
        if (flowerbed.Length == 1)
            return flowerbed[0] == 0; // n must be 1 based on prior 'if'

        if (flowerbed[0] == 0 && flowerbed[1] == 0)
        {
            flowerbed[0] = 1;
            n--;
        }
        if (flowerbed[^1] == 0 && flowerbed[^2] == 0)
        {
            flowerbed[^1] = 1;
            n--;
        }

        for (int i = 1; i < flowerbed.Length - 1; i++)
        {
            if (flowerbed[i] == 0 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0)
            {
                flowerbed[i] = 1;
                n--;
            }
        }

        return n <= 0;
    }
}
