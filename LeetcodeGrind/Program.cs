using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ah = new ArraysAndHashing.ArraysAndHashing();
            var res = ah.MaxSubarraySumCircular(new int[] { 5, -3, 5 });
            Console.WriteLine(res);
        }
    }
}