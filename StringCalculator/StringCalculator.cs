using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        private const string OptionalArg = "//";
        private const int CustomDelimiterIndex = 2;
        private const char StartOfCustomDelimiter = '[';
        private const string CustomDelimiterRegex = "(?<=\\[).+?(?=\\])";

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
            return GetSumOfString();
        }

        private void UpdateDelimitersWithCustomDelimiter(string stringInput)
        {
            List<string> customDelimiters = new ();
            
            if (stringInput.Contains(StartOfCustomDelimiter))
            {
                var delimiterStrings = Regex.Matches(stringInput, CustomDelimiterRegex);
                foreach (var delimiter in delimiterStrings)
                {
                    customDelimiters = customDelimiters.Append(delimiter.ToString()!).ToList();
                }
            }
            else
            {
                customDelimiters = customDelimiters.Append(stringInput[CustomDelimiterIndex] + "").ToList();
            }
            customDelimiters.ForEach(delimiter => _separators = _separators.Append(delimiter).ToArray());
        }
        
        private int GetSumOfString()
        {
            var initialNumbers = _inputString.Split(_separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            CheckForNegatives(initialNumbers);

            var numbers = GetNumbersBelowAThousand(initialNumbers);
            
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

        private IEnumerable<int> GetNumbersBelowAThousand(IEnumerable<int> numbers)
        {
            return numbers.Where(number => number < 1000);
        }
    }
}