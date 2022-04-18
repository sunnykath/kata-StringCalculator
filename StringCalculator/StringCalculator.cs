using System.Linq;
using kata_string_calculator.Delimiters;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        private readonly IValidation _validator;
        private readonly StringsToNumbers _stringConversion;
        
        public StringCalculator(IDelimiters delimitersHandler, IValidation validator)
        {
            _stringConversion = new StringsToNumbers(delimitersHandler);
            _validator = validator;
        }

        public int Add(string stringInput)
        {
            var numbers = _stringConversion.GetNumbersFromString(stringInput);

            return GetValidSumOfNumbers(numbers);
        }

        private int GetValidSumOfNumbers(int[] allNumbers)
        {
            var validNumbers = _validator.GetValidNumbers(allNumbers);

            return validNumbers.Sum();
        }
    }
}