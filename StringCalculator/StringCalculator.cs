using System;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        private const string OptionalArg = "//";
        
        private char _customDelimiter;
        private readonly char[] _separators = {',', '\n'};
        private string _inputString;
        public int Add(string stringInput)
        {
            _inputString = stringInput;
            
            if (_inputString.Contains(OptionalArg))
            {
                UpdateCustomDelimiter(stringInput);
                _inputString = _inputString.Substring(4);
            }

            return CalculateSumOfMultipleNumbers();
        }

        private void UpdateCustomDelimiter(string stringInput)
        {
            _customDelimiter = stringInput[2];
        }
        
        private int CalculateSumOfMultipleNumbers()
        {
            var customSeparators = _separators;
            if (_customDelimiter != 0)
            {
                customSeparators = customSeparators.Append(_customDelimiter).ToArray();
            }

            var numbers = _inputString.Split(customSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            
            return numbers.Sum();
        }
    }
}