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
        private string _numbersInStringInput = null!;
        public int Add(string stringInput)
        {
            if (stringInput.Contains(OptionalArg))
            {
                var endOfCustomDelimiter = stringInput.IndexOf('\n');
                UpdateDelimitersWithCustomDelimiter(stringInput[..endOfCustomDelimiter]);
                _numbersInStringInput = stringInput[endOfCustomDelimiter..];
            }
            return GetSumOfString();
        }

        private void UpdateDelimitersWithCustomDelimiter(string stringInput)
        {
            List<string> customDelimiters = new ();
            
            if (stringInput.Contains(StartOfCustomDelimiter))
            {
                var delimiterStrings = Regex.Matches(stringInput, CustomDelimiterRegex);
                customDelimiters.AddRange(delimiterStrings.Select(d => d.ToString()));
            }
            else
            {
                customDelimiters.Add(stringInput[CustomDelimiterIndex] + "");
            }
            
            customDelimiters.AddRange(_separators);
            _separators = customDelimiters.ToArray();
        } 
        
        private int GetSumOfString()
        {
            var initialNumbers = _numbersInStringInput.Split(_separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            CheckForNegatives(initialNumbers);

            var numbers = GetNumbersBelowAThousand(initialNumbers);
            
            return numbers.Sum();
        }
        
        private static void CheckForNegatives(int[] numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0).ToArray();

            if (negativeNumbers.Length != 0)
            {
                throw new Exception($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
        }

        private static IEnumerable<int> GetNumbersBelowAThousand(IEnumerable<int> numbers)
        {
            return numbers.Where(number => number < 1000);
        }
    }
}