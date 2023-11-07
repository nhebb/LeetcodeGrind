using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 1535. Find the Winner of an Array Game
public class P1535
{    
    public int GetWinner(int[] arr, int k)
    {
        // Note: This solution works, but it's slow and overly complicated.

        if (k > arr.Length)
            return arr.Max();

        var list = new LinkedList<(int, int)>();

        foreach (var val in arr)
        {
            var node = new LinkedListNode<(int, int)>((val, 0));
            list.AddLast(node);
        }

        var done = false;
        var result = 0;

        while (!done)
        {
            var node1 = list.First;
            list.RemoveFirst();

            var node2 = list.First;
            list.RemoveFirst();

            var (val1, count1) = node1.Value;
            var (val2, count2) = node2.Value;

            if (val1 > val2)
            {
                count1++;
                if (count1 == k)
                {
                    result = val1;
                    done = true;
                }
                node1.Value = (val1, count1);
                list.AddFirst(node1);
                list.AddLast(node2);
            }
            else
            {
                count2++;
                if (count2 == k)
                {
                    result = val2;
                    done = true;
                }
                node2.Value = (val2, count2);
                list.AddFirst(node2);
                list.AddLast(node1);
            }
        }

        return result;
    }
}
