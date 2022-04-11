using System;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Calculate(string s)
        {
            return s.Contains(',') ? HandleMultipleDigits(s) : HandleSingleDigit(s);
        }

        private int HandleSingleDigit(string singleDigit)
        {
            var parseSuccess = int.TryParse(singleDigit, out var number);
            return parseSuccess ? number : 0;
        }
        
        private int HandleMultipleDigits(string multipleDigits)
        {
            var numberStrings = multipleDigits.Split(',');
            var numbers = numberStrings.Select(int.Parse);
            
            return numbers.Sum();
        }
        
        
    }
}