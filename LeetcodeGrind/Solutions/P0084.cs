namespace LeetcodeGrind.Solutions;

// 84. Largest Rectangle in Histogram
public class P0084
{
    public int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int[]>();
        var maxArea = 0;

        for (int i = 0; i < heights.Length; i++)
        {
            var startIndex = i;
            while (stack.Count > 0 && stack.Peek()[1] > heights[i])
            {
                var rect = stack.Pop();
                var index = rect[0];
                var height = rect[1];
                maxArea = Math.Max(maxArea, height * (i - index));
                startIndex = index;
            }
            stack.Push(new int[] { startIndex, heights[i] });
        }

        while (stack.Count > 0)
        {
            var rect = stack.Pop();
            var index = rect[0];
            var height = rect[1];
            maxArea = Math.Max(maxArea, height * (heights.Length - index));
        }

        return maxArea;
    }
}
