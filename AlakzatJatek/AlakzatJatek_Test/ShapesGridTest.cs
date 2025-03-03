using AlakzatJatek_Lib;

namespace AlakzatJatek_Test
{
    public class ShapesGridTest
    {
        [Test]
        public void CountSameShapeOrColorReturnsWithZeroIfThereAreNoMatchingShapes()
        {
            string input =
                "3\nsárga-kör;piros-négyzet1;kék-háromszög1\nkék-négyzet1;sárga-háromszög1;piros-kör\npiros-háromszög1;kék-kör;sárga-négyzet1";
            var grid = new ShapesGrid(input);
        
            Assert.AreEqual(0, grid.CountSameShapeOrColor(0, 0));
        }

        [Test]
        public void CountSameShapeOrColorReturnsWithOneIfThereIsOneMatchingShape()
        {
            string input =
                "3\nsárga-kör;piros-négyzet1;kék-háromszög1\nkék-négyzet2;sárga-háromszög1;piros-ellipszis\npiros-háromszög2;kék-kör;sárga-ellipszis";
            var grid = new ShapesGrid(input);
        
            Assert.AreEqual(1, grid.CountSameShapeOrColor(1, 2));
        }

        [Test]
        public void CountSameShapeOrColorReturnsWithTwoIfThereAreTwoMatchingShapes()
        {
            string input =
                "3\nsárga-kör;piros-négyzet1;kék-ellipszis\nkék-négyzet2;sárga-háromszög1;piros-ellipszis\npiros-háromszög2;kék-kör;sárga-ellipszis";
            var grid = new ShapesGrid(input);
        
            Assert.AreEqual(2, grid.CountSameShapeOrColor(1, 2));
        }

        [Test]
        public void CountSameShapeOrColorReturnsWithThreeIfThereAreThreeMatchingShapesBothHorizontallyAndVertically()
        {
            string input =
                "3\nsárga-ellipszis;piros-négyzet1;lila-ellipszis\nkék-négyzet2;sárga-háromszög1;piros-ellipszis\npiros-háromszög2;kék-kör;sárga-ellipszis";
            var grid = new ShapesGrid(input);
        
            Assert.AreEqual(3, grid.CountSameShapeOrColor(0, 2));
        }
    }
}
