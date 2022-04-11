namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Calculate(string stringInput)
        {
            var parseSuccess = int.TryParse(stringInput, out var number);
            
            return parseSuccess ? number : 0;
        }
    }
}