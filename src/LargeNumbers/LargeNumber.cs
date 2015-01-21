using System;

namespace LargeNumbers
{
    public class LargeNumber
    {
        public string Convert(int number)
        {

            if (number == 0)
                return "zero";

            var stack = new Splitter().ToHundreds(Math.Abs(number));

            var absoluteNumber = new NumberParts().ProcessThreeDigitParts(stack);
            if (number < 0)
            {
                absoluteNumber = "negative " + absoluteNumber;
            }
            return absoluteNumber;
        }
    }
}