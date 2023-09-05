using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Stacks;

// 225. Implement Stack using Queues
public class MyStack
{
    private Queue<int> _queue;

    public MyStack() => _queue = new();

    public void Push(int x) => _queue.Enqueue(x);

    public int Pop()
    {
        int count = _queue.Count;
        if (count == 0) { return 0; }

        while (count > 1)
        {
            _queue.Enqueue(_queue.Dequeue());
            count--;
        }
        return _queue.Dequeue();
    }

    public int Top()
    {
        int count = _queue.Count;
        if (count == 0) { return 0; }

        while (count > 1)
        {
            _queue.Enqueue(_queue.Dequeue());
            count--;
        }

        int top = _queue.Dequeue();
        _queue.Enqueue(top);

        return top;
    }

    public bool Empty() => _queue.Count == 0;
}

