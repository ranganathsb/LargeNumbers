using System.Text;

namespace LargeNumbers
{
    public class Hundreds : INumberConverter
    {
        private const int OneHundred = 100;
        private readonly INumberConverter _numberConverter;

        public Hundreds(INumberConverter numberConverter)
        {
            _numberConverter = numberConverter;
        }

        public string Convert(int number)
        {
            var numberInEnglish = new StringBuilder();

            
            var units = number / OneHundred;
            var remainder = number % OneHundred;
            
            if (units >= 1)
            {
                numberInEnglish.Append(_numberConverter.Convert(units));
                if (units > 0)
                {
                    numberInEnglish.Append(" hundred");

                }
                if (remainder >= 1)
                {
                    if (remainder > 0)
                    {
                        numberInEnglish.Append(" and ");
                    }
                    numberInEnglish.Append(_numberConverter.Convert(remainder));
                }

                return numberInEnglish.ToString();
            }

            return _numberConverter.Convert(number);
        }

        public bool CanConvert(int digit)
        {
            var num = digit/100;
            return num > 0  && num < 10;
        }
    }
}