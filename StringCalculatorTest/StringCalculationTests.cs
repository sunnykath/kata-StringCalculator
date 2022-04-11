using System.Linq;
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
        [InlineData(1, 2)]
        [InlineData(2, 4)]
        [InlineData(3, 5)]
        public void Should_Return_The_Sum_When_Two_Numbers_Are_Passed_In(int firstNumber, int secondNumber)
        {
            // Arrange
            var stringCalculator = new StringCalculator();
            var expectedSum = firstNumber + secondNumber;

            // Act
            var actualSum = stringCalculator.Calculate($"{firstNumber},{secondNumber}");

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
        
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 5, 3, 9)]
        [InlineData(4, 6, 2, 8, 7)]
        public void Should_Return_The_Sum_When_Multiple_Numbers_Are_Passed_In(params int[] numbers)
        {
            // Arrange
            var stringCalculator = new StringCalculator();
            var expectedSum = numbers.Sum();
            var stringInput = "";
            for (var i = 0; i < numbers.Length; i++)
            {
                stringInput += $"{numbers[i]}";
                
                if (i != numbers.Length - 1) stringInput += ",";
            }

            // Act
            var actualSum = stringCalculator.Calculate(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}