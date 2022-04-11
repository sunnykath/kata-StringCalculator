using System;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Calculate(string s)
        {
            if (s.Contains(','))
            {
                var numbers = s.Split(',');
                var sum = int.Parse(numbers[0]) + int.Parse(numbers[1]);
                return sum;
            }
            else
            {
                var parseSuccess = int.TryParse(s, out var number);
                return parseSuccess ? number : 0;
            }
        }
    }
}