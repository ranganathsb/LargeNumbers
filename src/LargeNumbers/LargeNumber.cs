using System;
using System.Collections.Generic;
using LargeNumbers.Tests;

namespace LargeNumbers
{
    public class LargeNumber
    {
        public string Convert(int number)
        {

            if (number == 0)
                return "zero";

            var stack = new Splitter().ToHundreds(Math.Abs(number));
            INumberConverter units = new Units();
            INumberConverter tens = new Tens(units);
            INumberConverter hundreds = new Hundreds(tens);
            var converters = new List<INumberConverter> {hundreds, tens, units};

            var absoluteNumber = new NumberParts(converters).Process(stack);
            if (number < 0)
            {
                absoluteNumber = "negative " + absoluteNumber;
            }
            return absoluteNumber;
        }
    }
}