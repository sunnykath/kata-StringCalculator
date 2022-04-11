using System;
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
            var result = stringCalculator.Add("");

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
            var actualNumber = stringCalculator.Add($"{expectedNumber}");

            // Assert
            Assert.Equal(expectedNumber, actualNumber);
        }
        
        [Theory]
        [InlineData(3, "1,2")]
        [InlineData(6, "2,4")]
        [InlineData(8, "3,5")]
        public void Should_Return_The_Sum_When_Two_Numbers_Are_Passed_In(int expectedSum, string stringInput)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actualSum = stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
        
        [Theory]
        [InlineData(6, "1,2,3")]
        [InlineData(20, "3,5,3,9")]
        [InlineData(27, "4,6,2,8,7")]
        public void Should_Return_The_Sum_When_Multiple_Numbers_Are_Passed_In(int expectedSum, string stringInput)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actualSum = stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
        
        [Theory]
        [InlineData(6, "1,2\n3")]
        [InlineData(20, "3\n5\n3,9")]
        [InlineData(27, "4\n6,2,8\n7")]
        public void Should_Return_The_Sum_When_Multiple_Numbers_Are_Passed_In_With_Both_Comma_And_NewLineCharacter_As_Separators(int expectedSum, string stringInput)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actualSum = stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData(3, "//;\n1;2")]
        [InlineData(8, "//-\n3-5")]
        [InlineData(7, "//+\n6+1")]
        public void Should_Use_The_Delimiter_Provided_In_The_Input_To_Separate_The_Numbers(int expectedSum, string stringInput)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actualSum = stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData("-1,2,-3", "-1, -3")]
        [InlineData("4,6,-5", "-5")]
        [InlineData("-32,-45, 99", "-32, -45")]
        public void Should_Throw_Exception_When_Negative_Numbers_Are_Inputted(string stringInput, string negativeNumbers)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act

            // Assert
            var exception = Assert.Throws<Exception>(() => stringCalculator.Add(stringInput));
            Assert.Contains($"Negatives not allowed: {negativeNumbers}", exception.Message);
            
        }
    }
}