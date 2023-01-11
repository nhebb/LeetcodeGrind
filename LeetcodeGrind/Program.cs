namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*length =
            
            width =
            
            height =
            
            mass =
            
            */

            var sw = new SlidingWindow.SlidingWindow();
            var nums = new int[] { 1, 1, 2, 1, 1 };
            var res = sw.NumberOfSubarrays(nums, 3);

            Console.WriteLine(res);
        }
    }
}