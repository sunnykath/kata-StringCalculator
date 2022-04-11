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
            var numbers = numberString.Split(',').Select(int.Parse);
            
            return numbers.Sum();
        }
    }
}