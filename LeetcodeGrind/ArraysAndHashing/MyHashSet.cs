using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.ArraysAndHashing;

// 705. Design HashSet
// This uses the Multiplication Method for creating a hash
public class MyHashSet
{
    const double A = 0.473561;  // multiplcation constant
    const int M = 8192;         // 2^13 - array size
    List<int>[] nums;

    public MyHashSet()
    {
        nums = new List<int>[M];
    }

    public int Hash(int key)
    {
        return (int)Math.Floor(M * ((key * A) % 1));
    }

    public void Add(int key)
    {
        int index = Hash(key);
        if (nums[index] == null)
            nums[index] = new List<int>();

        if (!nums[index].Contains(key))
        {
            nums[index].Add(key);
        }
    }

    public void Remove(int key)
    {
        var index = Hash(key);
        if (nums[index] == null) 
            return;
        nums[index].Remove(key);
    }

    public bool Contains(int key)
    {
        var index = Hash(key);
        return nums[index] == null
            ? false
            : nums[index].Contains(key);
    }
}
