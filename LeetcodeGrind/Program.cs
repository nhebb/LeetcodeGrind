namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 3 , 5};
            var target = 4;
            var bs = new BinarySearch.BinarySearch();
            Console.WriteLine("Expected: 2");
            Console.WriteLine("Result: " + bs.SearchInsert(nums, target).ToString());
        }
    }
}