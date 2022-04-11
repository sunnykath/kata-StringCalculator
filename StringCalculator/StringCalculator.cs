namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Calculate(string stringInput)
        {
            if (stringInput.Contains(','))
            {
                var numbers = stringInput.Split(',');
                var sum = int.Parse(numbers[0]) + int.Parse(numbers[1]);
                return sum;
            }
            else
            {
                var parseSuccess = int.TryParse(stringInput, out var number);
                return parseSuccess ? number : 0;
            }
        }
    }
}