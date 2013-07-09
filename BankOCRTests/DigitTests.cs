using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataBankOCR;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataBankTests
{
    [TestClass]
    public class DigitTests
    {
        [TestMethod]
        public void ValidDigitHasThreeTextLinesTest()
        {
            var digit = new Digit {"   ", "  |", "  |"};

            Assert.IsTrue( digit.IsValidDigit );
        }

        [TestMethod]
        public void InvalidDigitWithMoreThanThreeLinesTest()
        {
            var digit = new Digit() { "", "", "", "" };

            Assert.IsFalse( digit.IsValidDigit );
        }

        [TestMethod]
        public void ValidDigitHasLengthEqualToThreeTest()
        {
            var digit = new Digit
                {
                    "   ",
                    "  |",
                    "  |"
                };
            Assert.IsTrue( digit.IsValidDigit );
        }

        [TestMethod]
        public void InvalidDigitHasLengthNotEqualToThreeTest()
        {
            var digit = new Digit
                {
                    " ",
                    "|",
                    "|"
                };
            Assert.IsFalse( digit.IsValidDigit );
        }

        [TestMethod]
        public void IsTextNumberZeroTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    "| |",
                    "|_|"
                };
            Assert.IsTrue(digit.IsValidDigit);
            Assert.AreEqual(digit.DigitAsChar, '0');
        }

        [TestMethod]
        public void IsTextNumberOneTest()
        {
            var digit = new Digit
                {
                    "   ",
                    "  |",
                    "  |"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual(digit.DigitAsChar, '1');
        }

        [TestMethod]
        public void IsTextNumberTwoTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    " _|",
                    "|_ "
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual(digit.DigitAsChar, '2');
        }

        [TestMethod]
        public void IsTextNumberThreeTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    " _|",
                    " _|"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual( digit.DigitAsChar, '3' );
        }

        [TestMethod]
        public void IsTextNumberFourTest()
        {
            var digit = new Digit
                {
                    "   ",
                    "|_|",
                    "  |"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual( digit.DigitAsChar, '4' );
        }

        [TestMethod]
        public void IsTextNumberFiveTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    "|_ ",
                    " _|"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual( digit.DigitAsChar, '5' );
        }

        [TestMethod]
        public void IsTextNumberSixTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    "|_ ",
                    "|_|"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual( digit.DigitAsChar, '6' );
        }

        [TestMethod]
        public void IsTextNumberSevenTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    "  |",
                    "  |"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual( digit.DigitAsChar, '7' );
        }

        [TestMethod]
        public void IsTextNumberEightTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    "|_|",
                    "|_|"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual( digit.DigitAsChar, '8' );
        }

        [TestMethod]
        public void IsTextNumberNineTest()
        {
            var digit = new Digit
                {
                    " _ ",
                    "|_|",
                    " _|"
                };
            Assert.IsTrue( digit.IsValidDigit );
            Assert.AreEqual( digit.DigitAsChar, '9' );
        }
    }
}
