using Igazitas_Lib;

namespace Igazitas_Test
{
    public class Test
    {
        [Test]
        public void LeftAlignLengthIsLongerThanStringLength()
        {
            var result = new Igazitas("alma", 10, Alignment.Left);
            Assert.AreEqual("alma      ", result.ToString());
        }

        [Test]
        public void RightAlignLengthIsLongerThanStringLength()
        {
            var result = new Igazitas("alma", 10, Alignment.Right);
            Assert.AreEqual("      alma", result.ToString());
        }

        [Test]
        public void MiddleAlignLengthIsLongerThanStringLength()
        {
            var result = new Igazitas("alma", 10, Alignment.Middle);
            Assert.AreEqual("   alma   ", result.ToString());
        }

        [Test]
        public void LeftAlignLengthIsShorterThanStringLength()
        {
            var result = new Igazitas("alma", 2, Alignment.Left);
            Assert.AreEqual("al", result.ToString());
        }
        
        [Test]
        public void RightAlignLengthIsShorterThanStringLength()
        {
            var result = new Igazitas("alma", 2, Alignment.Right);
            Assert.AreEqual("ma", result.ToString());
        }
        
        [Test]
        public void MiddleAlignLengthIsShorterThanStringLength()
        {
            var result = new Igazitas("alma", 2, Alignment.Middle);
            Assert.AreEqual("lm", result.ToString());
        }
    }
}
