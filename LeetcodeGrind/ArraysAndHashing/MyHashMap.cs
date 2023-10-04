using LeetcodeGrind.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.ArraysAndHashing;

// 706. Design HashMap
public class MyHashMap
{
    private class HashNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public HashNode? Next { get; set; }

        public HashNode(int key, int value, HashNode next = null)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }

    const int mapSize = 8192;   // 2^13 - array size
    HashNode[] map;

    public MyHashMap()
    {
        map = new HashNode[mapSize];
    }

    public void Put(int key, int value)
    {
        var index = GetHashIndex(key);
        var node = map[index];

        while (node != null)
        {
            if (node.Key == key)
            {
                node.Value = value;
                return;
            }
            node = node.Next;
        }

        map[index] = new HashNode(key, value, map[index]);
    }

    public int Get(int key)
    {
        int index = GetHashIndex(key);
        var node = map[index];

        while (node != null)
        {
            if (node.Key == key)
            {
                return node.Value;
            }
            node = node.Next;
        }

        return -1;
    }

    public void Remove(int key)
    {
        var index = GetHashIndex(key);
        var node = map[index];
        HashNode prev = null!;

        while (node != null)
        {
            if (node.Key == key)
            {
                if (prev != null)
                {
                    prev.Next = node.Next;
                }
                else
                {
                    map[index] = node.Next!;
                }
                return;
            }
            prev = node;
            node = node.Next;
        }
    }

    private int GetHashIndex(int key)
    {
        return key % mapSize;
    }
}
