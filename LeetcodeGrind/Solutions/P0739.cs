namespace LeetcodeGrind.Solutions;

// 739. Daily Temperatures
public class P0739
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var days = new int[temperatures.Length];
        var stack = new Stack<int>();

        for (int cur = 0; cur < temperatures.Length; cur++)
        {
            while (stack.Count > 0 &&
                   temperatures[cur] > temperatures[stack.Peek()])
            {
                var prev = stack.Pop();
                days[prev] = cur - prev;
            }

            stack.Push(cur);
        }

        return days;
    }
}
