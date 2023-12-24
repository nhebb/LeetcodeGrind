namespace LeetcodeGrind.Solutions;

// 1629. Slowest Key
public class P1629
{
    public char SlowestKey(int[] releaseTimes, string keysPressed)
    {
        var max = releaseTimes[0];
        var maxKey = keysPressed[0];

        for (int i = 1; i < releaseTimes.Length; i++)
        {
            var duration = releaseTimes[i] - releaseTimes[i - 1];
            if (duration > max)
            {
                max = duration;
                maxKey = keysPressed[i];
            }
            else if (duration == max)
            {
                if (keysPressed[i] > maxKey)
                {
                    maxKey = keysPressed[i];
                }
            }
        }

        return maxKey;
    }
}
