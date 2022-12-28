using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.Stacks;

// 1381. Design a Stack With Increment Operation
public class CustomStack
{
    private int[] arr;
    private int idx;

    public CustomStack(int maxSize)
    {
        arr = new int[maxSize];
        idx = -1;
    }

    public void Push(int x)
    {
        if (idx < arr.Length - 1)
        {
            idx++;
            arr[idx] = x;
        }
    }

    public int Pop()
    {
        var result = -1;
        if (idx >= 0)
        {
            result = arr[idx];
            idx--;
        }
        return result;
    }

    public void Increment(int k, int val)
    {
        for (int i = 0; i < k && i <= idx; i++)
        {
            arr[i] += val;
        }
    }
}