using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImperativeProgrammingTests
{
    [TestClass]
    public class ExpressionFixerTests
    {
        [TestMethod]
        public void FixExpression_WhenFirstDigitLessThanSecond_ShouldSetLessThanOperator()
        {
            string input = "1<3";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("1<3", result);
        }

        [TestMethod]
        public void FixExpression_WhenFirstDigitLessThanSecondWithWrongOperator_ShouldFixToLessThan()
        {
            string input = "1>3";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("1<3", result);
        }

        [TestMethod]
        public void FixExpression_WhenFirstDigitGreaterThanSecond_ShouldSetGreaterThanOperator()
        {
            string input = "3>1";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("3>1", result);
        }

        [TestMethod]
        public void FixExpression_WhenFirstDigitGreaterThanSecondWithWrongOperator_ShouldFixToGreaterThan()
        {
            string input = "3=1";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("3>1", result);
        }

        [TestMethod]
        public void FixExpression_WhenDigitsEqual_ShouldSetEqualOperator()
        {
            string input = "5=5";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("5=5", result);
        }

        [TestMethod]
        public void FixExpression_WhenDigitsEqualWithWrongOperator_ShouldFixToEqualOperator()
        {
            string input = "5<5";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("5=5", result);
        }

        [TestMethod]
        public void FixExpression_WithMinimumValues_ShouldHandleCorrectly()
        {
            string input = "0>9";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("0<9", result);
        }

        [TestMethod]
        public void FixExpression_WithMaximumValues_ShouldHandleCorrectly()
        {
            string input = "9<0";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("9>0", result);
        }

        [TestMethod]
        public void FixExpression_WhenBothDigitsZeroWithWrongOperator_ShouldFixToEqualOperator()
        {
            string input = "0>0";

            string result = ExpressionFixer.FixExpression(input);

            Assert.AreEqual("0=0", result);
        }

        [TestMethod]
        public void FixExpression_WhenDigitsDifferByOne_ShouldSetCorrectOperator()
        {
            string input1 = "4=5";
            string input2 = "5=4";
            string input3 = "5>4";
            string input4 = "4<5";

            Assert.AreEqual("4<5", ExpressionFixer.FixExpression(input1));
            Assert.AreEqual("5>4", ExpressionFixer.FixExpression(input2));
            Assert.AreEqual("5>4", ExpressionFixer.FixExpression(input3));
            Assert.AreEqual("4<5", ExpressionFixer.FixExpression(input4));
        }
    }
}
