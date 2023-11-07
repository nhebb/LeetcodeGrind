using LeetcodeGrind.Common;

namespace LeetcodeGrind.Solutions;

// 341. Flatten Nested List Iterator

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */

// This is the interface that allows for creating nested lists.
// You should not implement it, or speculate about its implementation
public interface NestedInteger
{

    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList();
}

public class NestedIterator
{
    Queue<int> _queue;

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        _queue = new Queue<int>();
        BuildList(nestedList);
    }

    public bool HasNext()
    {
        return _queue.Count > 0;
    }

    public int Next()
    {
        return _queue.Dequeue();
    }

    private void BuildList(IList<NestedInteger> nestedList)
    {
        foreach (var item in nestedList)
        {
            if (item.IsInteger())
                _queue.Enqueue(item.GetInteger());
            else
                BuildList(item.GetList());
        }
    }
}
