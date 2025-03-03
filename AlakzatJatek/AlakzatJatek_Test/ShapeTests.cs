using System.Drawing;
using AlakzatJatek_Lib;

namespace AlakzatJatek_Test
{
    public class ShapeTests
    {
        [Test]
        public void IsDifferentReturnsTrueIfTheTwoShapesAreTheSameObject()
        {
            var testShape = new Shape(Shape.ShapeType.Circle, Color.Aqua, 1, 1);
            Assert.AreEqual(false, testShape.IsDifferent(testShape));
        }

        [Test]
        public void IsDifferentReturnsFalseIfTheTwoShapesAreTheSame()
        {
            var a = new Shape(Shape.ShapeType.Ellipse, Color.Red, 3, 4);
            var b = new Shape(Shape.ShapeType.Ellipse, Color.Red, 23, 5);
            
            Assert.AreEqual(false, a.IsDifferent(b));
        }
        
        [Test]
        public void IsDifferentReturnsFalseIfTheTwoShapesAreTheSameColor()
        {
            var a = new Shape(Shape.ShapeType.Square1, Color.Yellow, 5, 9);
            var b = new Shape(Shape.ShapeType.Square1, Color.Blue, 62, 43);
            
            Assert.AreEqual(false, a.IsDifferent(b));
        }
        
        [Test]
        public void IsDifferentReturnsFalseIfTheTwoShapesAreTheSameShape()
        {
            var a = new Shape(Shape.ShapeType.Triangle1, Color.Bisque, 2, 8);
            var b = new Shape(Shape.ShapeType.Triangle2, Color.Bisque, 2, 45);
            
            Assert.AreEqual(false, a.IsDifferent(b));
        }

        [Test]
        public void IsDifferentReturnsTrueIfTheTwoShapesAreDifferent()
        {
            var a = new Shape(Shape.ShapeType.Triangle1, Color.Purple, 6, 7);
            var b = new Shape(Shape.ShapeType.Square2, Color.Maroon, 23, 13);
            
            Assert.AreEqual(true, a.IsDifferent(b));
        }
    }
}