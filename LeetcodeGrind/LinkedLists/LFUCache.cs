using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetcodeGrind.LinkedLists;

// 460. LFU Cache
public class LFUCache
{
    private class Node
    {
        public int Key { get; set; }
        public int Val { get; set; }
        public int Count { get; set; }
    }

    Dictionary<int, LinkedListNode<Node>> _nodes;
    Dictionary<int, LinkedList<Node>> _counts;
    int _capacity;
    int _count;
    int _minFreq;

    public LFUCache(int capacity)
    {
        _nodes = new();
        _counts = new();
        _capacity = capacity;
        _count = 0;
        _minFreq = 1;
    }

    public int Get(int key)
    {
        if (!_nodes.ContainsKey(key))
            return -1;

        var node = _nodes[key];
        UpdateCountAndFrequency(node);
        return node.Value.Val;
    }

    public void Put(int key, int value)
    {
        if (_capacity == 0)
            return;

        if (_nodes.ContainsKey(key))
        {
            var currentNode = _nodes[key];
            currentNode.Value.Val = value;
            UpdateCountAndFrequency(currentNode);
            return;
        }

        if (_count == _capacity)
        {
            var minCountList = _counts[_minFreq];
            _nodes.Remove(minCountList.Last.Value.Key);
            minCountList.RemoveLast();
            _count--;
        }

        _minFreq = 1;
        LinkedList<Node> countList;
        if (_counts.ContainsKey(_minFreq))
        {
            countList = _counts[_minFreq];
        }
        else
        {
            countList = new LinkedList<Node>();
            _counts.Add(_minFreq, countList);
        }
        countList.AddFirst(new Node { Key = key, Val = value, Count = 1 });

        _nodes.Add(key, countList.First);
        _count++;
    }

    private void UpdateCountAndFrequency(LinkedListNode<Node> currNode)
    {
        var currCountList = _counts[currNode.Value.Count];

        currCountList.Remove(currNode);

        if (currCountList.Count == 0 && currNode.Value.Count == _minFreq)
            _minFreq++;

        currNode.Value.Count++;

        LinkedList<Node> countList;
        if (_counts.ContainsKey(currNode.Value.Count))
        {
            countList = _counts[currNode.Value.Count];
        }
        else
        {
            countList = new LinkedList<Node>();
            _counts.Add(currNode.Value.Count, countList);
        }
        countList.AddFirst(currNode.Value);

        _nodes[currNode.Value.Key] = countList.First;
    }
}
