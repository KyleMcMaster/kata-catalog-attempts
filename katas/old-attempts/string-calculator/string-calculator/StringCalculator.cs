using System.Linq;

namespace Tests
{
    public class StringCalculator
    {
        public int answer { get; set; }
        private char delimiter { get; set; }

        public void Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                answer = 0;
                return;
            }

            if (numbers.Length > 2 && numbers.Substring(0, 2) == "//")
            {
                delimiter = numbers[2];

                int index = numbers.IndexOf('\n');

                numbers = numbers.Substring(index + 1);

                numbers = numbers.Replace(delimiter, ',');
            }

            answer = numbers.Replace('\n',',').Split(',').Sum((a) => int.Parse(a));
        }
    }
}
