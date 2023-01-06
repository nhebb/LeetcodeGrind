using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.ArraysAndHashing;

// 303. Range Sum Query - Immutable
public class NumArray
{
    int[] arr;

    public NumArray(int[] nums)
    {
        arr = nums;
    }

    public int SumRange(int left, int right)
    {
        return arr[left..right].Sum();
    }
}
