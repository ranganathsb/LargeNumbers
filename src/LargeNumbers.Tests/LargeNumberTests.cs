using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LargeNumbers.Tests
{
    public class LargeNumberTests
    {
        [Test]
        public void Should_apply_zero_rule()
        {
            Assert.That(Convert(0), Is.EqualTo("zero"));
        }

        

        [Test]
        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(4, "four")]
        [TestCase(5, "five")]
        [TestCase(6, "six")]
        [TestCase(7, "seven")]
        [TestCase(8, "eight")]
        [TestCase(9, "nine")]
        public void Should_convert_single_digits(int number, string expected)
        {
            Assert.That(Convert(number), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, "ten")]
        [TestCase(12, "twelve")]
        public void Should_convert_double_digits(int number, string expected)
        {
            Assert.That(Convert(number), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(20, "twenty")]
        [TestCase(21, "twenty one")]
        [TestCase(25, "twenty five")]
        [TestCase(35, "thirty five")]
        [TestCase(99, "ninety nine")]
        public void Should_convert_tens(int number, string expected)
        {
            Assert.That(Convert(number), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(100, "one hundred")]
        [TestCase(105, "one hundred and five")]
        [TestCase(999, "nine hundred and ninety nine")]
        public void Should_convert_hundreds(int number, string expected)
        {
            Assert.That(Convert(number), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1000, "one thousand")]
        [TestCase(100000, "one hundred thousand")]
        [TestCase(1000000, "one million")]
        [TestCase(1200000, "one million, two hundred thousand")]
        [TestCase(1200057, "one million, two hundred thousand and fifty seven")]
        [TestCase(1999, "one thousand, nine hundred and ninety nine")]
        [TestCase(56945781,"fifty six million, nine hundred and forty five thousand, seven hundred and eighty one")]
        public void Should_apply_three_digit_rule(int number, string expected)
        {
            Assert.That(Convert(number), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1200057, "one million, two hundred thousand and fifty seven")]
        public void Should_recombine_with_commas(int number, string expected)
        {
            Assert.That(Convert(number), Is.EqualTo(expected));
        }

        [Test]

        public void Should_convert_negative_numbers()
        {
            Assert.That(Convert(-1000000), Is.EqualTo("negative one million"));
        }

        private static string Convert(int number)
        {
            return new LargeNumber().Convert(number);
        }
    }
}