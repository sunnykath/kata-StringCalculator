using System;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Calculate(string s)
        {
            var parseSuccess = int.TryParse(s, out var number);
            
            return parseSuccess ? number : 0;
        }
    }
}