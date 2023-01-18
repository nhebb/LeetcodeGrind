using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dp = new DynamicProgramming.DynamicProgramming();

            for (int i = 0; i <= 5; i++)
            {
                var res = dp.GetRow(i);
                Console.WriteLine(string.Join(",", res));
                Console.WriteLine();
            }
        }
    }
}