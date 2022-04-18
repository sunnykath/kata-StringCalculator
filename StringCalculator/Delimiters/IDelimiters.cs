namespace kata_string_calculator.Delimiters
{
    public interface IDelimiters
    {
        public void HandleDelimiters(string inputString);

        public string[] GetDelimiters();
        public string GetNumbersAsString();
    }
}