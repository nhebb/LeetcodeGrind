using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetcodeGrind.LinkedLists;

// Note: This class is just "Node" in the Leetcode problem
public class RandomNode
{
    public int val;
    public RandomNode next;
    public RandomNode random;

    public RandomNode(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}
