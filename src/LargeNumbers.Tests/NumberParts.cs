using System.Collections.Generic;
using System.Text;

namespace LargeNumbers.Tests
{
    public class NumberParts
    {
        

        private readonly Dictionary<int, string> _scales = new Dictionary<int, string>
        {
            {1, ""},
            {2, "thousand"},
            {3, "million"}
        };

        private readonly IList<INumberConverter> _converters;

        public NumberParts(IList<INumberConverter> numberConverters)
        {
            _converters = numberConverters;
        }

        public string ProcessThreeDigitParts(Stack<int> stack)
        {
            var numberInEnglish = new StringBuilder();
            while (stack.Count > 0)
            {
                var scale = stack.Count;
                var scaleLabel = _scales[scale];

                var part = stack.Pop();

                foreach (var converter in _converters)
                {
                    if (converter.CanConvert(part))
                    {
                        numberInEnglish.AppendFormat("{0} {1}", converter.Convert(part), scaleLabel);
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