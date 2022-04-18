using System;
using System.Linq;
using kata_string_calculator.Delimiters;

namespace kata_string_calculator
{
    public class StringsToNumbers
    {
        private readonly IDelimiters _delimitersHandler;
        
        public StringsToNumbers(IDelimiters delimitersHandler)
        {
            _delimitersHandler = delimitersHandler;
        }
        
        public int[] GetNumbersFromString(string inputString)
        {
            _delimitersHandler.HandleDelimiters(inputString);
            
            var delimiters = _delimitersHandler.GetDelimiters();
            var numbersAsString = _delimitersHandler.GetNumbersAsString();
            
            var numbers = numbersAsString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            return numbers;
        }
    }
}