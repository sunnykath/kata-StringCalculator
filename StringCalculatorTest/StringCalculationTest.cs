using System;
using kata_string_calculator;
using Xunit;

namespace StringCalculatorTest
{
    public class StringCalculationTests
    {
        private readonly StringCalculator _stringCalculator;
        public StringCalculationTests()
        {
            _stringCalculator = new StringCalculator();
        }
        
        [Fact]
        public void Should_Return_A_Number_When_Given_A_String()
        {
            // Act
            var result = _stringCalculator.Add("");

            // Assert
            Assert.IsType<int>(result);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_The_Same_Number_That_Was_Passed_In(int expectedNumber)
        {
            // Act
            var actualNumber = _stringCalculator.Add($"{expectedNumber}");

            // Assert
            Assert.Equal(expectedNumber, actualNumber);
        }
        
        [Theory]
        [InlineData(3, "1,2")]
        [InlineData(6, "2,4")]
        [InlineData(8, "3,5")]
        public void Should_Return_The_Sum_When_Two_Numbers_Are_Passed_In(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
        
        [Theory]
        [InlineData(6, "1,2,3")]
        [InlineData(20, "3,5,3,9")]
        [InlineData(27, "4,6,2,8,7")]
        public void Should_Return_The_Sum_When_Multiple_Numbers_Are_Passed_In(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
        
        [Theory]
        [InlineData(6, "1,2\n3")]
        [InlineData(20, "3\n5\n3,9")]
        [InlineData(27, "4\n6,2,8\n7")]
        public void Should_Return_The_Sum_When_Multiple_Numbers_Are_Passed_In_With_Both_Comma_And_NewLineCharacter_As_Separators(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData(3, "//;\n1;2")]
        [InlineData(8, "//-\n3-5")]
        [InlineData(7, "//+\n6+1")]
        public void Should_Use_The_Delimiter_Provided_In_The_Input_To_Separate_The_Numbers(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData("-1,2,-3", "-1, -3")]
        [InlineData("4,6,-5", "-5")]
        [InlineData("-32,-45, 99", "-32, -45")]
        public void Should_Throw_Exception_When_Negative_Numbers_Are_Inputted(string stringInput, string negativeNumbers)
        {
            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _stringCalculator.Add(stringInput));
            Assert.Contains($"Negatives not allowed: {negativeNumbers}", exception.Message);
        }
        
        [Theory]
        [InlineData(2, "1000,1001,2")]
        [InlineData(227, "1111,5,3333,222")]
        public void Should_Return_The_Sum_Of_Numbers_That_Are_Less_Than_A_Thousand(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);
            
            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData(6, "//[***]\n1***2***3")]
        [InlineData(8, "//[---]\n3---5")]
        [InlineData(7, "//[+++]\n6+++1")]
        public void Should_Use_The_Delimiter_Provided_Of_Any_Length_In_The_Input_To_Separate_The_Numbers(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData(6, "//[*][%]\n1*2%3")]
        [InlineData(21, "//[-][*][^]\n3*9-5^4")]
        [InlineData(14, "//[+][#]\n6+1#7")]
        public void Should_Use_All_The_Delimiters_Provided_In_The_Input_To_Separate_The_Numbers(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData(10, "//[***][#][%]\n1***2#3%4")]
        [InlineData(21, "//[--][*][^^^]\n3*9--5^^^4")]
        [InlineData(14, "//[+][#####]\n6#####1+7")]
        public void Should_Use_All_The_Delimiters_Of_All_Lengths_Provided_In_The_Input_To_Separate_The_Numbers(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Theory]
        [InlineData(6, "//[*1*][%]\n1*1*2%3")]
        [InlineData(17, "//[^^6^][^^][%]\n6%6^^6^2%3")]
        [InlineData(11, "//[%333%][*]\n5%333%3*3")]
        public void Should_Be_Able_To_Handle_Delimiters_With_Numbers_As_Part_Of_Them_Provided_In_The_Input_To_Separate_The_Numbers(int expectedSum, string stringInput)
        {
            // Act
            var actualSum = _stringCalculator.Add(stringInput);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }
    }
}