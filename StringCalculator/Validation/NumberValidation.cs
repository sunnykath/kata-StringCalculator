using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_string_calculator
{
    public class NumberValidation : IValidation
    {
        private const int MaxValueToBeAdded = 1000;
        
        public int[] GetValidNumbers(int[] numbers)
        {
            CheckForNegatives(numbers);
            var validNumbers = GetNumbersBelowTheMaxValue(numbers);

            return validNumbers;
        }
        
        private static void CheckForNegatives(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0).ToArray();

            if (negativeNumbers.Length != 0)
            {
                throw new Exception($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
        }

        private static int[] GetNumbersBelowTheMaxValue(IEnumerable<int> numbers)
        {
            return numbers.Where(number => number < MaxValueToBeAdded).ToArray();
        }
    }
}