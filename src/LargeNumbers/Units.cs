using System.Collections.Generic;
using System.Text;

namespace LargeNumbers
{
    public class Units : INumberConverter
    {
        private readonly Dictionary<int, string> _digits;

        public Units()
        {
            _digits = new Dictionary<int, string>
            {
                {0, "zero"},
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"},
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eightteen"},
                {19, "nineteen"}
            };
        }

        public string Convert(int number)
        {
            var numberInEnglish = new StringBuilder();


            if (_digits.ContainsKey(number))
            {
                numberInEnglish.Append(_digits[number]);
            }

            return numberInEnglish.ToString();
        }

        public  bool CanConvert(int digit)
        {
            return digit > 0 && digit < 10;
        }
    }
}