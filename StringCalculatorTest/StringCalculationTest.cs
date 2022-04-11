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
            var result = stringCalculator.Calculate();

            // Assert
            Assert.IsType<int>(result);
        }
        
        [Fact]
        public void Should_Return_The_Same_Number_That_Was_Passed_In()
        {
            // Arrange
            var stringCalculator = new StringCalculator();
            var expectedNumber = 1;

            // Act
            var actualNumber = stringCalculator.Calculate($"{expectedNumber}");

            // Assert
            Assert.Equal(expectedNumber, actualNumber);
        }
    }
}