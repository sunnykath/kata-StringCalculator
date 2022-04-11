using System;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        private const string OptionalArg = "//";
        private const int CustomDelimiterIndex = 2;
        
        private char[] _separators = {',', '\n'};
        private string _inputString;
        public int Add(string stringInput)
        {
            _inputString = stringInput;
            
            if (_inputString.Contains(OptionalArg))
            {
                UpdateDelimitersWithCustomDelimiter(stringInput);
                _inputString = _inputString.Substring(4);
            }

            return CalculateSumOfString();
        }

        private void UpdateDelimitersWithCustomDelimiter(string stringInput)
        {
            _separators = _separators.Append(stringInput[CustomDelimiterIndex]).ToArray();
        }
        
        private int CalculateSumOfString()
        {
            var numbers = _inputString.Split(_separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            CheckForNegatives(numbers);
            
            return numbers.Sum();
        }

        private void CheckForNegatives(int[] numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0).ToArray();

            if (negativeNumbers.Length != 0)
            {
                throw new Exception($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
        }
    }
}