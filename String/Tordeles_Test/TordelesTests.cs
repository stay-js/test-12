using Tordeles_Lib;

namespace Tordeles_Test
{
    public class TordelesTests
    {
        [Test]
        public void TordelMethodReturnsCorrectArray()
        {
            string[] result = Tordeles.Tordel("Lorem, ipsum dolor sit amet consectetur adipisicing elit.", 25);
            string[] expected = ["Lorem, ipsum dolor sit", "amet consectetur", "adipisicing elit."];

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TordelMethodReturnsCorrectArrayWhenAWordIsLongerThanSpecifiedLength()
        {
            string[] result = Tordeles.Tordel("Lorem, ipsum dolor sit Loremipsumdolorsitametconsecteturadipisicingelit. amet consectetur adipisicing elit.", 25);
            string[] expected = [
                "Lorem, ipsum dolor sit",
                "Loremipsumdolorsitametcon",
                "secteturadipisicingelit.",
                "amet consectetur",
                "adipisicing elit."
            ];

            Assert.AreEqual(expected, result);
        }
    }
}
