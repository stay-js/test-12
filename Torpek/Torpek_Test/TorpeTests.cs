using Torpek_Lib;

namespace Torpek_Test
{
    public class Tests
    {
        [Test]
        public void GnomeCountReturnZeroWhenThereAreNoGnomes()
        {
            var torpek = new Torpe();
            Assert.AreEqual(0, torpek.GnomeCount());
        }

        [Test]
        public void GnomeCountReturnsOneWhenThereIsOnlyOneGnome()
        {
            var torpek = new Torpe();
            torpek.AddGnome();
            Assert.AreEqual(1, torpek.GnomeCount());
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(100)]
        public void GnomeCountReturnsCorrectValueWhenAddingMultipleGnomes(int amount)
        {
            var torpek = new Torpe();
            torpek.AddGnomes(amount);
            Assert.AreEqual(amount, torpek.GnomeCount());
            
            torpek.AddGnomes(5);
            Assert.AreEqual(amount + 5, torpek.GnomeCount());
        }

        [Test]
        public void HoleCountReturnsZeroWhenThereAreNoHoles()
        {
            var torpek = new Torpe();
            Assert.AreEqual(0, torpek.HoleCount());
        }

        [Test]
        public void HoleCountReturnsOneWhenThereIsOnlyOneHole()
        {
            var torpek = new Torpe();
            torpek.AddHole(5);
            Assert.AreEqual(1, torpek.HoleCount());
        }

        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3 }, 3)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 6)]
        public void HoleCountReturnsCorrectValueWhenAddingMultipleHoles(int[] depths, int expectedAmount)
        {
            var torpek = new Torpe();
            
            foreach (var depth in depths)
            {
                torpek.AddHole(depth);
            }
            
            Assert.AreEqual(expectedAmount, torpek.HoleCount());
        }

        [Test]
        public void FinalOrderThrowsAnExceptionWhenGnomeCountIsNotBetweenOneAndAThousand()
        {
            var torpek = new Torpe();
            Assert.Throws<GnomeCountException>(() => torpek.FinalOrder());
            
            torpek.AddGnomes(1001);
            Assert.Throws<GnomeCountException>(() => torpek.FinalOrder());
        }
        
        [Test]
        public void FinalOrderThrowsAnExceptionWhenHoleCountIsNotBetweenOneAndAThousand()
        {
            var torpek = new Torpe();
            torpek.AddGnomes(10);

            Assert.Throws<HoleCountException>(() => torpek.FinalOrder());

            for (int i = 0; i < 1001; i++)
            {
                torpek.AddHole(1);
            }
            Assert.Throws<HoleCountException>(() => torpek.FinalOrder());
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(9)]
        public void AddHoleThrowsAnExceptionWhenDepthIsNotBetweenOneAndEight(int depth)
        {
            var torpek = new Torpe();
            Assert.Throws<HoleDepthException>(() => torpek.AddHole(depth));
        }

        [Test]
        public void FinalOrderReturnsOneWhenThereIsOnlyOneGnome()
        {
            var torpek = new Torpe();
            torpek.AddGnome();
            torpek.AddHole(5);

            List<int> expected = [1];
            Assert.AreEqual(expected, torpek.FinalOrder());
        }

        [Test]
        public void FinalOrderReturnsCorrectlyWhenThereAreTwoGnomes()
        {
            var torpek = new Torpe();
            torpek.AddGnomes(2);
            torpek.AddHole(5);

            List<int> expected = [2, 1];
            Assert.AreEqual(expected, torpek.FinalOrder());
        }

        [Test]
        public void FinalOrderIsCorrectAccordingToTemplate()
        {
            var torpek = new Torpe();
            torpek.AddGnomes(5);
            torpek.AddHole(3);
            
            List<int> expected = [4, 5, 3, 2, 1];
            Assert.AreEqual(expected, torpek.FinalOrder());
        }
    }
}
