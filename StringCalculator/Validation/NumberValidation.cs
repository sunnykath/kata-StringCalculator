using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_string_calculator.Validation
{
    public class NumberValidation : IValidation
    {
        private const int MaxValueToBeAdded = 1000;

        private const string NegativeNumberExceptionMessage = "Negatives not allowed: ";
        
        public int[] GetValidNumbers(int[] numbers)
        {
            CheckAllNumbersForNegatives(numbers);
            var validNumbers = GetNumbersBelowTheMaxValue(numbers);

            return validNumbers;
        }
        
        private static void CheckAllNumbersForNegatives(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0).ToArray();

            if (negativeNumbers.Length != 0)
            {
                throw new Exception($"{NegativeNumberExceptionMessage}{string.Join(", ", negativeNumbers)}");
            }
        }

        private static int[] GetNumbersBelowTheMaxValue(IEnumerable<int> numbers)
        {
            return numbers.Where(number => number < MaxValueToBeAdded).ToArray();
        }
    }
}