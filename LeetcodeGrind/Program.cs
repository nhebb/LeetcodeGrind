namespace LeetcodeGrind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = new SlidingWindow.SlidingWindow();
            var res = sw.SubStrHash2("leetcode", 7, 20, 2, 0);
            var res2 = sw.SubStrHash2("xmmhdakfursinye", 96, 45, 15, 21);
            var res3 = sw.SubStrHash2("xqgfatvtlwnnkxipmipcpqwbxihxblaplpfckvxtihonijhtezdnkjmmk",22, 51, 41, 9);
            // xqgfatvtlwnnkxipmipcpqwbxihxblaplpfckvxti
            Console.WriteLine(res);
            Console.WriteLine(res2);
            Console.WriteLine(res3);
            //Console.WriteLine("xqgfatvtlwnnkxipmipcpqwbxihxblaplpfckvxti (Expected");
        }
    }
}