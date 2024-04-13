namespace LeetcodeGrind.Solutions;

// 85. Maximal Rectangle
public class P0085
{
    public int MaximalRectangle(char[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var maxArea = 0;
        var heights = new int[cols];
        var stack = new Stack<int>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row][col] == '1')
                {
                    heights[col]++;
                }
                else
                {
                    heights[col] = 0;
                }
            }

            var area = 0;

            for (int i = 0; i <= cols; i++)
            {
                while (stack.Count > 0 && 
                      (i == cols || heights[stack.Peek()] >= heights[i]))
                {
                    int h = heights[stack.Pop()];
                    int w = stack.Count == 0 
                        ? i 
                        : i - stack.Peek() - 1;

                    area = Math.Max(area, h * w);
                }

                stack.Push(i);
            }
            
            maxArea = Math.Max(maxArea, area);
            stack.Clear();
        }

        return maxArea;
    }
}
