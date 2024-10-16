using Tordeles_Lib;

namespace Tordeles_Test
{
    public class StringHelperTests
    {
        [Test]
        public void SplitMethodReturnsCorrectArray()
        {
            string[] result = StringHelper.Split("alma körte barack", ' ');
            string[] expected = ["alma", "körte", "barack"];

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TrimMethodReturnsCorrectString()
        {
            Assert.AreEqual("alma", StringHelper.Trim("\n\t \r alma\n"));
        }

        [Test]
        public void WordCountMethodReturnsCorrectCount()
        {
            int result = StringHelper.WordCount("Reggel beugrottam a Spar-ba.");

            Assert.AreEqual(4, result);
        }
    }
}
