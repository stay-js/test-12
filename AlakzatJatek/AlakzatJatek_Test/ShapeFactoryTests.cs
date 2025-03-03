using System.Drawing;
using AlakzatJatek_Lib;

namespace AlakzatJatek_Test
{
    public class ShapeFactoryTests
    {
        [TestCase("kör", Shape.ShapeType.Circle)]
        [TestCase("négyzet1", Shape.ShapeType.Square1)]
        [TestCase("háromszög1", Shape.ShapeType.Triangle1)]
        [TestCase("ellipszis", Shape.ShapeType.Ellipse)]
        [TestCase("négyzet2", Shape.ShapeType.Square2)]
        [TestCase("háromszög2", Shape.ShapeType.Triangle2)]
        public void ParseAlakReturnsCorrectAlak(string input, Shape.ShapeType expected)
        {
            var actual = ShapeFactory.ParseShape(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseAlakThrowsExceptionIfInputIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.ParseShape("bármi más"));
        }

        [TestCase("piros", "Red")]
        [TestCase("zöld", "Green")]
        [TestCase("sárga", "Yellow")]
        [TestCase("kék", "Blue")]
        [TestCase("lila", "Purple")]
        [TestCase("narancs", "Orange")]
        public void ParseColorReturnsCorrectColor(string input, string expectedColorName)
        {
            var actual = ShapeFactory.ParseColor(input);
            var expected = Color.FromName(expectedColorName);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseColorThrowsExceptionIfInputIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.ParseColor("bármi más"));
        }
    }
}
