using System;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Calculate(string stringInput)
        {
            return stringInput.Contains(',') ? CalculateSumOfMultipleNumbers(stringInput) : CalculateOutputForSingleOrNoDigit(stringInput);
        }

        private int CalculateOutputForSingleOrNoDigit(string singleDigit)
        {
            var parseSuccess = int.TryParse(singleDigit, out var number);
            return parseSuccess ? number : 0;
        }
        
        private int CalculateSumOfMultipleNumbers(string numberString)
        {
            var separators = new [] {',', '\n'};
            var numbers = numberString.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            
            return numbers.Sum();
        }
    }
}