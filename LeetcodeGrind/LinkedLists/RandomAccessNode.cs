using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.LinkedLists.RandomAccessNode;

// 382. Linked List Random Node
public class Solution
{
    private List<ListNode> _list;
    private Random _random;

    public Solution(ListNode head)
    {
        _random = new Random();
        _list = new List<ListNode>();
        while (head != null)
        {
            _list.Add(head);
            head = head.next;
        }
    }

    public int GetRandom()
    {
        var index = _random.Next(0, _list.Count);
        var node = _list[index];
        return node.val;
    }
}
