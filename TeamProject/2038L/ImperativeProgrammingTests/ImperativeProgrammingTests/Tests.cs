namespace ImperativeProgrammingTests
{
    [TestClass]
    public sealed class Tests
    {
        [TestMethod]
        public void CalculateBoards_n1()
        {
            Assert.AreEqual(2, BoardCalculator.CalculateBoards(1));
        }

        [TestMethod]
        public void CalculateBoards_n2()
        {
            Assert.AreEqual(3, BoardCalculator.CalculateBoards(2));
        }

        [TestMethod]
        public void CalculateBoards_n3()
        {
            Assert.AreEqual(4, BoardCalculator.CalculateBoards(3));
        }

        [TestMethod]
        public void CalculateBoards_n4()
        {
            Assert.AreEqual(5, BoardCalculator.CalculateBoards(4));
        }

        [TestMethod]
        public void CalculateBoards_n5()
        {
            Assert.AreEqual(6, BoardCalculator.CalculateBoards(5));
        }

        [TestMethod]
        public void CalculateBoards_n6()
        {
            Assert.AreEqual(7, BoardCalculator.CalculateBoards(6));
        }

        [TestMethod]
        public void CalculateBoards_n7()
        {
            Assert.AreEqual(9, BoardCalculator.CalculateBoards(7));
        }

        [TestMethod]
        public void CalculateBoards_n8()
        {
            Assert.AreEqual(10, BoardCalculator.CalculateBoards(8));
        }

        [TestMethod]
        public void CalculateBoards_n9()
        {
            Assert.AreEqual(11, BoardCalculator.CalculateBoards(9));
        }

        [TestMethod]
        public void CalculateBoards_n10()
        {
            Assert.AreEqual(12, BoardCalculator.CalculateBoards(10));
        }

        [TestMethod]
        public void CalculateBoards_n20_Returns24()
        {
            Assert.AreEqual(24, BoardCalculator.CalculateBoards(20));
        }

        [TestMethod]
        public void CalculateBoards_n100_Returns117()
        {
            Assert.AreEqual(117, BoardCalculator.CalculateBoards(100));
        }

        [TestMethod]
        public void CalculateBoards_n1000_Returns1167()
        {
            Assert.AreEqual(1167, BoardCalculator.CalculateBoards(1000));
        }
    }
}
