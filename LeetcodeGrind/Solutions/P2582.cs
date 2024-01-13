namespace LeetcodeGrind.Solutions;

// 2582. Pass the Pillow
public class P2582
{
    public int PassThePillow(int n, int time)
    {
        var increment = -1;
        var index = 1;

        while (time > 0)
        {
            time--;
            if (index == 1 || index == n)
            {
                increment *= -1;
            }
            index += increment;
        }

        return index;
    }
}
