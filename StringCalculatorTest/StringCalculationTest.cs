using kata_string_calculator;
using Xunit;

namespace StringCalculatorTest
{

    public class StringCalculationTests
    {
        [Fact]
        public void Should_Return_A_Number_When_Given_A_String()
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var result = stringCalculator.Calculate("");

            // Assert
            Assert.IsType<int>(result);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_The_Same_Number_That_Was_Passed_In(int expectedNumber)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actualNumber = stringCalculator.Calculate($"{expectedNumber}");

            // Assert
            Assert.Equal(expectedNumber, actualNumber);
        }
        
        [Theory]
        [InlineData(3, "1, 2")]
        [InlineData(6, "2, 4")]
        [InlineData(8, "3, 5")]
        public void Should_Return_The_Sum_When_Two_Numbers_Are_Passed_In(int expectedSum, string stringInput)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actualSum = stringCalculator.Calculate(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}