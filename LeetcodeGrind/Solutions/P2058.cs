using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 2058. Find the Minimum and Maximum Number of Nodes Between Critical Points
public class P2058
{
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        var index = 0;
        var firstIndex = -1;
        var prevIndex = -1;
        var minLen = int.MaxValue;
        var maxLen = int.MinValue;

        var prevVal = head.val;
        head = head.next;
        while (head.next != null)
        {
            index++;
            if (head.val > prevVal && head.val > head.next.val ||
                head.val < prevVal && head.val < head.next.val)
            {
                if (firstIndex == -1)
                {
                    firstIndex = index;
                }
                else
                {
                    minLen = Math.Min(minLen, index - prevIndex);
                    maxLen = Math.Max(maxLen, index - firstIndex);
                }
                prevIndex = index;
            }

            prevVal = head.val;
            head = head.next;
        }

        if (firstIndex == -1 ||
            minLen == int.MaxValue ||
            maxLen == int.MinValue)
        {
            return [-1, -1];
        }

        return [minLen, maxLen];
    }
}