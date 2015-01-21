using System.Collections.Generic;
using System.Text;

namespace LargeNumbers
{
    public class NumberParts
    {
        

        private readonly Dictionary<int, string> _scales = new Dictionary<int, string>
        {
            {1, ""},
            {2, "thousand"},
            {3, "million"},
            {4, "billion"}
        };

        private readonly List<INumberConverter> _converters;

        public NumberParts()
        {
            INumberConverter units = new Units();
            INumberConverter tens = new Tens(units);
            INumberConverter hundreds = new Hundreds(tens);

            _converters = new List<INumberConverter> {units, tens, hundreds};
        }

        public string ProcessThreeDigitParts(Stack<int> stack)
        {
            var numberInEnglish = new StringBuilder();
            while (stack.Count > 0)
            {
                var scale = stack.Count;
                var scaleLabel = _scales[scale];

                var digit = stack.Pop();

                foreach (var converter in _converters)
                {
                    if (converter.CanConvert(digit))
                    {
                        numberInEnglish.AppendFormat("{0} {1}", converter.Convert(digit), scaleLabel);
                    }
                }

                Combine(stack, scale, numberInEnglish);
            }

            return numberInEnglish.ToString().TrimEnd(new[]{',',' '});
        }

        private static void Combine(Stack<int> stack, int threeDigitPart, StringBuilder numberInEnglish)
        {
            if (IsTheNextTheLast(threeDigitPart) && IsTheNextLessThan100(stack.Peek()))
            {
                numberInEnglish.Append(" and ");
            }
            else
            {
                numberInEnglish.Append(", ");
            }
        }

        private static bool IsTheNextLessThan100(int nextPart)
        {
            return (nextPart < 100 && nextPart > 0);
        }

        private static bool IsTheNextTheLast(int scale)
        {
            return scale == 2 && scale > 0;
        }
    }
}