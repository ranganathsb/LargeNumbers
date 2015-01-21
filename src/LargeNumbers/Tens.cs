using System.Collections.Generic;
using System.Text;

namespace LargeNumbers
{
    public class Tens : INumberConverter
    {
        private readonly INumberConverter _units;
        private readonly Dictionary<int, string> _tens;

        public Tens(INumberConverter units)
        {
            _units = units;
            _tens = new Dictionary<int, string>
            {
                {2, "twenty"},
                {3, "thirty"},
                {4, "forty"},
                {5, "fifty"},
                {6, "sixty"},
                {7, "seventy"},
                {8, "eighty"},
                {9, "ninety"},
            };
        }


        public string Convert(int number)
        {
            var numberInEnglish = new StringBuilder();

            int units = number / 10;
            int remainder = number % 10;
            if (_tens.ContainsKey(units))
            {
                numberInEnglish.Append(_tens[units]);
                if (remainder >= 1)
                {
                    numberInEnglish.Append(" " + _units.Convert(remainder));
                }

                return numberInEnglish.ToString();
            }

            return _units.Convert(number);
        }

        public  bool CanConvert(int digit)
        {
            var num = digit/10;
            return num > 0 && num < 10;
        }
    }
}