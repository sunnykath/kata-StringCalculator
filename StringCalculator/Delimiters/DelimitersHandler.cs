using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace kata_string_calculator.Delimiters
{
    public class DelimitersHandler : IDelimiters
    {
        private string[] _delimiters = {",", "\n"};        
        private string _numbersInStringInput = null!;

        private const string OptionalArg = "//";
        private const int CustomDelimiterIndex = 2;
        private const char StartOfCustomDelimiter = '[';
        private const string CustomDelimiterRegex = "(?<=\\[).+?(?=\\])";
        
        public void HandleDelimiters(string inputString)
        {
            if (inputString.Contains(OptionalArg))
            {
                var endOfCustomDelimiter = inputString.IndexOf('\n');
                UpdateDelimitersWithCustomDelimiter(inputString[..endOfCustomDelimiter]);
                _numbersInStringInput = inputString[endOfCustomDelimiter..];
            }
            else
            {
                _numbersInStringInput = inputString;
            }
        }

        public string[] GetDelimiters()
        {
            return _delimiters;
        }

        public string GetNumbersAsString()
        {
            return _numbersInStringInput;
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
            
            customDelimiters.AddRange(_delimiters);
            _delimiters = customDelimiters.ToArray();
        }
    }
}