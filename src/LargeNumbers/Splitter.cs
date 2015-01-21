using System;
using System.Collections.Generic;

namespace LargeNumbers
{
    public class Splitter
    {
        public Stack<int> ToHundreds(int number)
        {
            double remainder;
            double factor = number;
            var stack = new Stack<int>();

            while (factor >= 1)
            {
                remainder = factor%(1000);
                factor = factor/1000;
                stack.Push((int) Math.Truncate(remainder));
            }
            return stack;
        }
    }
}