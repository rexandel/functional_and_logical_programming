using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImperativeProgrammingTests
{
    [TestClass]
    public class ExpressionFixerTests
    {
        // (1) Тест на корректное исправление выражения с оператором '<'
        [TestMethod]
        public void FixExpression_WhenFirstDigitLessThanSecond_ShouldSetLessThanOperator()
        {
            // Arrange
            string input = "1<3"; // Здесь оператор правильный

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("1<3", result);
        }

        // (2) Тест на исправление выражения с неправильным оператором '<'
        [TestMethod]
        public void FixExpression_WhenFirstDigitLessThanSecondWithWrongOperator_ShouldFixToLessThan()
        {
            // Arrange
            string input = "1>3"; // Здесь оператор неправильный

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("1<3", result);
        }

        // (3) Тест на корректное исправление выражения с оператором '>'
        [TestMethod]
        public void FixExpression_WhenFirstDigitGreaterThanSecond_ShouldSetGreaterThanOperator()
        {
            // Arrange
            string input = "3>1"; // Здесь оператор правильный

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("3>1", result);
        }

        // (4) Тест на исправление выражения с неправильным оператором '>'
        [TestMethod]
        public void FixExpression_WhenFirstDigitGreaterThanSecondWithWrongOperator_ShouldFixToGreaterThan()
        {
            // Arrange
            string input = "3=1"; // Здесь оператор неправильный

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("3>1", result);
        }

        // (5) Тест на корректное исправление выражения с оператором '='
        [TestMethod]
        public void FixExpression_WhenDigitsEqual_ShouldSetEqualOperator()
        {
            // Arrange
            string input = "5=5"; // Здесь оператор правильный

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("5=5", result);
        }

        // (6) Тест на исправление выражения с неправильным оператором '='
        [TestMethod]
        public void FixExpression_WhenDigitsEqualWithWrongOperator_ShouldFixToEqualOperator()
        {
            // Arrange
            string input = "5<5"; // Здесь оператор неправильный

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("5=5", result);
        }

        // (7) Тест на обработку минимальных значений
        [TestMethod]
        public void FixExpression_WithMinimumValues_ShouldHandleCorrectly()
        {
            // Arrange
            string input = "0>9"; // 0 сильно меньше 9

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("0<9", result);
        }

        // (8) Тест на обработку максимальных значений
        [TestMethod]
        public void FixExpression_WithMaximumValues_ShouldHandleCorrectly()
        {
            // Arrange
            string input = "9<0"; // 9 сильно больше 0

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("9>0", result);
        }

        // (9) Тест на корректное исправление выражения с нулями и разными операторами
        [TestMethod]
        public void FixExpression_WhenBothDigitsZeroWithWrongOperator_ShouldFixToEqualOperator()
        {
            // Arrange
            string input = "0>0"; // Оба нуля, оператор неправильный

            // Act
            string result = ExpressionFixer.FixExpression(input);

            // Assert
            Assert.AreEqual("0=0", result);
        }

        // (10) Тест на обработку цифр с разницей в 1
        [TestMethod]
        public void FixExpression_WhenDigitsDifferByOne_ShouldSetCorrectOperator()
        {
            // Arrange
            string input1 = "4=5"; // 4 < 5
            string input2 = "5=4"; // 5 > 4
            string input3 = "5>4"; // Уже правильно
            string input4 = "4<5"; // Уже правильно

            // Act & Assert
            Assert.AreEqual("4<5", ExpressionFixer.FixExpression(input1));
            Assert.AreEqual("5>4", ExpressionFixer.FixExpression(input2));
            Assert.AreEqual("5>4", ExpressionFixer.FixExpression(input3));
            Assert.AreEqual("4<5", ExpressionFixer.FixExpression(input4));
        }
    }
}
