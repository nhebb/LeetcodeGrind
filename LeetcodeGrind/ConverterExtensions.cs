using LeetcodeGrind.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeGrind;

public static class ConverterExtensions
{
    public static char[] To1DCharArray(this string s)
    {
        var sq = "'";
        var dq = "\"";

        return s.Replace("[", "")
                .Replace("]", "")
                .Replace(dq, sq)
                .Replace(" ", "")
                .ToCharArray();
    }

    public static int[] To1DIntArray(this string s)
    {
        var values = s.Replace("[", "")
                      .Replace("]", "")
                      .Split(',', StringSplitOptions.RemoveEmptyEntries);

        return Array.ConvertAll<string, int>(values, int.Parse);
    }

    public static string[] To1DStringArray(this string s)
    {
        if (string.IsNullOrEmpty(s))
            return null;

        var values = s.Replace(" ","")
                      .Replace("[", "")
                      .Replace("]", "")
                      .Split(',', StringSplitOptions.RemoveEmptyEntries);

        return values;
    }

    public static int[][] To2DIntArray(this string s)
    {
        var rows = s.Replace("[[", "")
                    .Replace("]]", "")
                    .Split("],[");

        var array2D = new int[rows.Length][];

        for (int i = 0; i < rows.Length; i++)
        {
            var columnValues = rows[i].Split(",");
            array2D[i] = Array.ConvertAll<string, int>(columnValues, int.Parse);
        }

        return array2D;
    }

    // Construct BST from level-order traversal
    private static TreeNode LevelOrder(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        if (val <= root.val)
        {
            root.left = LevelOrder(root.left, val);
        }
        else
        {
            root.right = LevelOrder(root.right, val);
        }

        return root;
    }

    public static TreeNode ToBst(this string[] arr)
    {
        if (arr is null || arr.Length == 0)
        {
            return null;
        }

        TreeNode root = null;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == "null")
                continue;

            var val = int.Parse(arr[i]);
            root = LevelOrder(root, val);
        }

        return root;
    }
}
