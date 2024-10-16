using Tordeles_Lib;

namespace Tordeles_Test
{
    public class StringHelperTests
    {
        [Test]
        public void SplitMethodReturnsCorrectArray()
        {
            string[] result = StringHelper.Split("alma körte barack", ' ');
            string[] expected = { "alma", "körte", "barack" };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TrimMethodReturnsCorrectString()
        {
            string result = StringHelper.Trim("\n\t \r alma\n");
            
            Assert.AreEqual("alma", result);
        }

        [Test]
        public void WordCountMethodReturnsCorrectCount()
        {
            int result = StringHelper.WordCount("Reggel beugrottam a spar-ba.");
            
            Assert.AreEqual(4, result);
        }
    }
}
