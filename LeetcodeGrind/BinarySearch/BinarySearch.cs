using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind.BinarySearch;

public class BinarySearch
{
    // 4. Median of Two Sorted Arrays
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var idx1 = 0;
        var idx2 = 0;
        var len1 = nums1.Length;
        var len2 = nums2.Length;
        var totalLen = len1 + len2;
        var isEven = (totalLen % 2 == 0);
        var lastIndex = totalLen / 2;

        var allNums = new List<int>(totalLen);

        while (idx1 < len1 && idx2 < len2 && (idx1 + idx2 <= lastIndex))
        {
            if (nums1[idx1] <= nums2[idx2])
            {
                allNums.Add(nums1[idx1]);
                idx1++;
            }
            else
            {
                allNums.Add(nums2[idx2]);
                idx2++;
            }
        }
        while (idx1 < len1 && (idx1 + idx2 <= lastIndex))
        {
            allNums.Add(nums1[idx1]);
            idx1++;
        }
        while (idx2 < len2 && (idx1 + idx2 <= lastIndex))
        {
            allNums.Add(nums2[idx2]);
            idx2++;
        }

        double medium = isEven
            ? (allNums[lastIndex - 1] / 2.0) + (allNums[lastIndex] / 2.0)
            : allNums[lastIndex];

        return medium;
    }


    // 33. Search in Rotated Sorted Array
    public int Search(int[] nums, int target)
    {
        if (nums == null)
            return -1;

        if (nums.Length == 1)
            return nums[0] == target ? 0 : -1;

        int i = 0;
        int j = nums.Length - 1;
        int mid = (i + j) / 2;
        while (i < j)
        {
            if (nums[mid] == target)
                return mid;

            if (
                   (nums[i] > nums[mid] && (nums[i] <= target || target <= nums[mid]))
                || (nums[i] < nums[mid] && (nums[i] <= target && target <= nums[mid]))
               )
                j = mid - 1;
            else if (mid < nums.Length - 1)
                i = mid + 1;
            else
                break;

            mid = (i + j) / 2;
            if (nums[mid] == target)
                return mid;
        }
        return -1;
    }


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


    // 162. Find Peak Element
    public int FindPeakElement(int[] nums)
    {
        if (nums.Length == 1) return 0; 
        if(nums[0] > nums[1]) return 0;
        if (nums[^1] > nums[^2]) return nums.Length - 1;

        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1])
                return mid;
            else if (nums[mid] < nums[mid + 1])
                left = mid + 1;
            else
                right = mid;
        }
        return left;
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
            var val1 = (int)Math.Pow(nums[idx1], 2);
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


    // 34. Find First and Last Position of Element in Sorted Array
    public int[] SearchRange(int[] nums, int target)
    {
        var first = nums.Length;
        var last = -1;

        void FindMinMax(int idx1, int idx2)
        {
            if (idx2 < idx1) return;

            var searchMin = false;
            var searchMax = false;
            var mid = idx1 + (idx2 - idx1) / 2;
            if (nums[mid] == target)
            {
                first = Math.Min(first, mid);
                last = Math.Max(last, mid);

                searchMin = mid > 0 && nums[mid - 1] == target;
                searchMax = mid < nums.Length - 1 && nums[mid + 1] == target;
            }

            if (searchMin || nums[mid] > target)
            {
                FindMinMax(idx1, mid - 1);
            }

            if (searchMax || nums[mid] < target)
            {
                FindMinMax(mid + 1, idx2);
            }
        }

        FindMinMax(0, nums.Length - 1);

        if (last == -1 || first == nums.Length)
            return new int[] { -1, -1 };

        return new int[] { first, last };
    }


    // 74. Search a 2D Matrix
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        bool MatrixBinarySearch(int idx1, int idx2)
        {
            if (idx1 > idx2) return false;

            var mid = idx1 + (idx2 - idx1) / 2;
            var row = mid / cols;
            var col = mid % cols;

            if (idx1 == idx2)
                return matrix[row][col] == target;
            else if (matrix[row][col] == target)
                return true;
            else if (matrix[row][col] > target)
                return MatrixBinarySearch(idx1, mid - 1);
            else
                return MatrixBinarySearch(mid + 1, idx2);
        }

        return MatrixBinarySearch(0, rows * cols - 1);
    }
}
