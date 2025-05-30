namespace ImperativeProgrammingTests
{
    [TestClass]
    public sealed class Tests
    {
        [TestMethod]
        public void Test1_OnlyBuses_NoPeople()
        {
            string input = "3\nB 2\nB 1\nB 3";
            string expected = "YES YES YES";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test2_OnlyPeople_NoBuses()
        {
            string input = "2\nP 5\nP 3";
            string expected = "";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test3_SimpleCase_MonocarpCanBoard()
        {
            string input = "4\nP 2\nB 3\nP 1\nB 2";
            string expected = "YES YES";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test4_AllPeopleFitExactly()
        {
            string input = "3\nP 5\nB 5\nB 1";
            string expected = "NO YES";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test5_MorePeopleThanBusCapacity()
        {
            string input = "3\nP 10\nB 4\nB 6";
            string expected = "NO NO";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test6_MultipleBusesWithRemainingPeople()
        {
            string input = "5\nP 3\nB 2\nP 4\nB 3\nB 2";
            string expected = "NO NO NO";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test7_EdgeCase_MaxPeopleAndBusCapacity()
        {
            string input = "2\nP 1000000\nB 1000000";
            string expected = "NO";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test8_EdgeCase_OnePersonOneBus()
        {
            string input = "2\nP 1\nB 1";
            string expected = "NO";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test9_AlternatingPeopleAndBuses()
        {
            string input = "6\nP 2\nB 1\nP 1\nB 2\nP 3\nB 3";
            string expected = "NO NO NO";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test10_ComplexScenario()
        {
            string input = "7\nP 5\nB 3\nP 2\nB 4\nP 1\nB 2\nB 1";
            string expected = "NO NO YES YES";
            string result = BusStopSimulator.ProcessEvents(input);
            Assert.AreEqual(expected, result);
        }
    }
}
