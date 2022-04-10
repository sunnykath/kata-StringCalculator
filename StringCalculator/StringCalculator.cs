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
            var numbers = multipleDigits.Split(',');
            var sum = int.Parse(numbers[0]) + int.Parse(numbers[1]);
            return sum;
        }
        
        
    }
}