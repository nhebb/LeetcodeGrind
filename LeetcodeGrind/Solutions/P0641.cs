namespace LeetcodeGrind.Solutions;

// TODO: 641. Design Circular Deque
public class MyCircularDeque
{
    int[] arr;
    int capacity;
    int count;
    int first;
    int last;

    public MyCircularDeque(int k)
    {
        arr = new int[k];
        capacity = k;
        count = 0;
        first = 0;
        last = 0;
    }

    //public bool InsertFront(int value)
    //{

    //}

    //public bool InsertLast(int value)
    //{

    //}

    //public bool DeleteFront()
    //{
    //    count--;
    //    first = (first + 1) % capacity;
    //}

    //public bool DeleteLast()
    //{
    //    count--;
    //    if (count == 0)
    //    {
    //        first = 0;
    //        last = 0;
    //    }
    //    else
    //    {
    //        last--;
    //        if (last < 0)
    //        {
    //            last = capacity - 1;
    //        }
    //    }
    //}

    public int GetFront()
    {
        return arr[first];
    }

    public int GetRear()
    {
        return arr[last];
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == capacity;
    }
}