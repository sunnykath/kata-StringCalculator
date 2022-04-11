using System;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        private char _customDelimiter;
        private readonly char[] _separators = {',', '\n'};
        private string _inputString;
        public int Calculate(string stringInput)
        {
            _inputString = stringInput;
            if (stringInput.Contains("//"))
            {
                UpdateCustomDelimiter(stringInput);
                _inputString = _inputString.Substring(4);
            }
            
            return _separators.Any(stringInput.Contains) ? CalculateSumOfMultipleNumbers() : CalculateOutputForSingleOrNoDigit();
        }

        private void UpdateCustomDelimiter(string stringInput)
        {
            _customDelimiter = stringInput[2];
        }

        private int CalculateOutputForSingleOrNoDigit()
        {
            var parseSuccess = int.TryParse(_inputString, out var number);
            return parseSuccess ? number : 0;
        }
        
        private int CalculateSumOfMultipleNumbers()
        {
            var customSeparators = _separators.Append(_customDelimiter).ToArray();
            var numbers = _inputString.Split(customSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            
            return numbers.Sum();
        }
    }
}