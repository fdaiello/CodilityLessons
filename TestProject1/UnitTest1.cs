using NUnit.Framework;
using CodilityLessons;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int[] arr = new int[500000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 1;
            }
            arr[499999] = 2;
            arr[499998] = 1;

            int t = Solution.FroggerJump(2, arr);

            Assert.AreEqual(t, 499999);

        }
    }
}