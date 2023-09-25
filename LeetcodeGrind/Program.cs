using LeetcodeGrind.LinkedLists;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeetcodeGrind;

internal class Program
{
    static void Main(string[] args)
    {
        var prev = new ListNode(0);
        prev.next = new ListNode(1);
        prev.next.next = new ListNode(2);
        prev.next.next.next = new ListNode(3);
        prev.next.next.next.next = new ListNode(4);
        prev.next.next.next.next.next = new ListNode(5);

        var ll = new LinkedLists.LinkedLists();
        var res = ll.ReverseBetween(prev.next, 2, 4);

        while (res != null)
        {
            Console.WriteLine(res.val);
            res = res.next;
        }
        //Console.WriteLine(string.Join(", ", res));
    }


    private static char[] Leetcode1DCharArray(string s)
    {
        var sq = "'";
        var dq = "\"";
        s = s.Replace("[", "").Replace("]", "");
        s = s.Replace(dq, sq).Replace(" ", ""); ;
        return s.ToCharArray();
    }

    private static int[] Leetcode1DIntArray(string s)
    {
        s = s.Replace("[", "").Replace("]", "");
        var parts = s.Split(',', StringSplitOptions.RemoveEmptyEntries);

        var result = new List<int>();
        foreach (var part in parts)
            result.Add(int.Parse(part));
        return result.ToArray();
    }

    private static int[][] ConvertTo2DIntArray(string s)
    {
        s = s.Replace("[[", "");
        s = s.Replace("]]", "");
        s = s.Replace("],[", ";");

        var parts = s.Split(';');
        var res = new int[parts.Length][];
        for (int i = 0; i < parts.Length; i++)
        {
            var vals = parts[i].Split(",");
            res[i] = new int[vals.Length];
            for (int j = 0; j < vals.Length; j++)
                res[i][j] = int.Parse(vals[j]);
        }

        return res;
    }

    private static void Print2DIntArray(int[][] arr)
    {
        foreach (var row in arr)
        {           
            Console.WriteLine(string.Join(",", row));
        }
    }
}