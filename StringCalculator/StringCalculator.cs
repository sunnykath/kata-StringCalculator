using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        private const string OptionalArg = "//";
        private const int CustomDelimiterIndex = 2;
        
        private string[] _separators = {",", "\n"};
        private string _inputString;
        public int Add(string stringInput)
        {
            _inputString = stringInput;
            
            if (_inputString.Contains(OptionalArg))
            {
                var endOfCustomDelimiter = _inputString.IndexOf('\n');
                UpdateDelimitersWithCustomDelimiter(stringInput[..endOfCustomDelimiter]);
                _inputString = _inputString[endOfCustomDelimiter..];
            }

            return CalculateSumOfString();
        }

        private void UpdateDelimitersWithCustomDelimiter(string stringInput)
        {
            var customDelimiter = stringInput[CustomDelimiterIndex] + "";
            if (stringInput.Contains('['))
            {
                var startOfDelimiter = stringInput.IndexOf('[') + 1;
                customDelimiter = stringInput.Substring(startOfDelimiter, stringInput.Length - 1 - startOfDelimiter);
            }
            _separators = _separators.Append(customDelimiter).ToArray();
        }
        
        private int CalculateSumOfString()
        {
            var initialNumbers = _inputString.Split(_separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            CheckForNegatives(initialNumbers);

            var numbers = RemoveNumbersBiggerThanThousand(initialNumbers);
            
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

        private IEnumerable<int> RemoveNumbersBiggerThanThousand(IEnumerable<int> numbers)
        {
            return numbers.Where(number => number < 1000);
        }
    }
}