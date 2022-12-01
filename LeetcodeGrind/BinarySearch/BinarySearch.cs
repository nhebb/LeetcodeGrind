using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.BinarySearch;

public class BinarySearch
{
    // 35. Search Insert Position
    public int SearchInsert(int[] nums, int target)
    {
        if (target < nums[0])
            return 0;
        if (target > nums[^1])
            return nums.Length;

        int BinSearch(int idx1, int idx2)
        {
            var mid = idx1 + (idx2 - idx1) / 2;

            if (nums[mid] == target)
                return mid;

            // edge cases at each end of array
            if (mid == 0)
                return target < nums[0] ? 0 : 1;

            if (mid == nums.Length - 1)
                return target < nums[^1] ? nums.Length - 1 : nums.Length;

            // check left neighbor
            if (mid > 0 && target > nums[mid - 1] && target < nums[mid])
                return mid;

            // check right neighbor
            if (mid < nums.Length - 1 && target > nums[mid] && target < nums[mid + 1])
                return mid + 1;

            // continue search
            if (target < nums[mid])
                return BinSearch(idx1, mid - 1);
            else
                return BinSearch(mid + 1, idx2);
        }
        return BinSearch(0, nums.Length - 1);
    }


    // 374. Guess Number Higher or Lower
    private int guess(int num)
    {
        return -1;
    }

    public int GuessNumber(int n)
    {
        var min = 0;
        var max = n;
        var mid = n / 2;
        var result = guess(mid);
        while (true)
        {
            if (result == 0)
                break;

            if (result < 0)
                max = mid - 1;
            else
                min = mid + 1;

            mid = min + (max - min) / 2;
            result = guess(mid);
        }

        return mid;
    }


    // 441. Arranging Coins
    public int ArrangeCoins(int n)
    {
        // O(n) solution:
        if (n <= 1) return n;
        var stairs = 0;
        while (n > stairs)
        {
            stairs++;
            n -= stairs;
        }
        return stairs;

        // binary solution relies on sum(1 .. r) = r(r+1)/2
        // search mid points until you find a result <= n

        // O(1): quadratic formula for r^2 + r - 2n = 0
        // => n = (int)
    }


    // 977. Squares of a Sorted Array
    public int[] SortedSquares(int[] nums)
    {
        var arr = new int[nums.Length];
        var idx1 = 0;
        var idx2 = nums.Length - 1;
        var i = arr.Length - 1;
        while (idx1 <= idx2)
        {
            var val1 =(int) Math.Pow(nums[idx1], 2);
            var val2 = (int)Math.Pow(nums[idx2], 2);
            if (val1 > val2)
            {
                arr[i] = val1;
                idx1++;
            }
            else
            {
                arr[i] = val2;
                idx2--;
            }
            i--;
        }
        return arr;
    }


    // 367. Valid Perfect Square
    public bool IsPerfectSquare(int num)
    {
        // Easy way:
        //var sqrt = (int)Math.Sqrt(num);
        //return num == (sqrt * sqrt);

        // Binary search method:
        if (num == 1) return true;

        bool BinarySearch(long idx1, long idx2)
        {
            if (idx1 > idx2) return false;

            long mid = idx1 + (idx2 - idx1) / 2;
            if (mid * mid == num)
                return true;

            if (mid * mid < num)
            {
                if ((mid + 1) * (mid + 1) > num)
                    return false;
                return BinarySearch(mid + 1, idx2);
            }
            else
            {
                if ((mid - 1) * (mid - 1) < num)
                    return false;
                return BinarySearch(idx1, mid - 1);
            }
        }

        return BinarySearch(1, num);
    }


}
