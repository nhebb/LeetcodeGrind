namespace LeetcodeGrind.Solutions;

// 907. Sum of Subarray Minimums
public class P0907
{
    public int SumSubarrayMins(int[] arr)
    {
        const int mod = 1_000_000_007;
        long sum = 0;
        var stack = new Stack<int>();

        for (int i = 0; i <= arr.Length; i++)
        {
            // check if stack is > 0
            // if so, check if current value is smaller than top of stack
            var curVal = i == arr.Length
                ? int.MinValue
                : arr[i];

            while (stack.Count > 0 && arr[stack.Peek()] > curVal)
            {
                // if arr[i] < arr[stack.Peek()], we need to pop 
                // until we find an index where the value was smaller
                // each time we pop, recalc the min for the subarray
                var mid = stack.Pop();

                // left bound is previous stack entry (or beginning of array)
                var left = stack.Count == 0
                    ? -1
                    : stack.Peek();

                // right bound is our current index (or end of array)
                var right = i;

                // multiple the min value by number of subarrays that include it
                sum += (long)(arr[mid]) * (mid - left) * (right - mid);
            }
            stack.Push(i);
        }

        return (int)(sum % mod);
    }
}
