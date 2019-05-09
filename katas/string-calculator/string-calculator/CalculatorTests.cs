using StringCalculator;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class CalculatorTests
    {
        [Test]
        [TestCase("")]
        public void Add_Empty_String(string numbers)
        {
            // Assign
            var calculator = new Calculator();

            // Arrange
            calculator.Add(numbers);

            // Assert
            Assert.AreEqual(0, calculator.answer);
        }

        [Test]
        [TestCase("1")]
        public void Add_Single_Number_String(string numbers)
        {
            // Assign
            var calculator = new Calculator();

            // Arrange
            calculator.Add(numbers);

            // Assert
            Assert.AreEqual(int.Parse(numbers), calculator.answer);
        }

        [Test]
        [TestCase("1,2")]
        public void Add_Comma_Separated_Numbers(string numbers)
        {
            // Assign
            var calculator = new Calculator();

            // Arrange
            calculator.Add(numbers);

            // Assert
            var expected = numbers.Split(',').Sum((a) => int.Parse(a));
            Assert.AreEqual(expected, calculator.answer);
        }

        [Test]
        [TestCase("1,2,3,4")]
        [TestCase("0,1,2,3,4")]
        [TestCase("1,1,2,3,5,8,13")]
        public void Add_Pseudo_Unknown_Number_Of_Numbers(string numbers)
        {
            // Assign
            var calculator = new Calculator();

            // Arrange
            calculator.Add(numbers);

            // Assert
            var expected = numbers.Split(',').Sum((a) => int.Parse(a));
            Assert.AreEqual(expected, calculator.answer);
        }

        [Test]
        [TestCase("1\n2\n3")]
        public void Add_Newline_Between_Numbers(string numbers)
        {
            // Assign
            var calculator = new Calculator();

            // Arrange
            calculator.Add(numbers);

            // Assert
            var expected = numbers.Replace('\n',',').Split(',').Sum((a) => int.Parse(a));
            Assert.AreEqual(expected, calculator.answer);
        }

        [Test]
        [TestCase("//;\n1;2")]
        public void Add_With_Delimiter_Between_Numbers(string numbers)
        {
            // Assign
            var calculator = new Calculator();

            // Arrange
            calculator.Add(numbers);

            // Assert
            var expected = 3;
            Assert.AreEqual(expected, calculator.answer);
        }
    }
}