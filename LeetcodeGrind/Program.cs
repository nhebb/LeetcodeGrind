using System.ComponentModel.Design;

namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var math = new MathAndGeometry.MathAndGeometry();
            var res = math.SumOfNumberAndReverse(63);
            Console.WriteLine(res);
        }
    }
}