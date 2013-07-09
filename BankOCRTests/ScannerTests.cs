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
    public class ScannerTests
    {
        [TestMethod]
        public void ScannerReturnsEmptyStringForInvalidEntryTest()
        {
            var input =
                "" + Environment.NewLine +
                "" + Environment.NewLine +
                "" + Environment.NewLine;
            var scanner = new Scanner(input);
            Assert.AreEqual(scanner.Scan(), string.Empty);
        }

        [TestMethod]
        public void ScannerReturnsAccountNumber123456789Test()
        {
            var input =
                "    _  _     _  _  _  _  _ " + Environment.NewLine +
                "  | _| _||_||_ |_   ||_||_|" + Environment.NewLine +
                "  ||_  _|  | _||_|  ||_| _|" + Environment.NewLine;
            var scanner = new Scanner(input);
            Assert.AreEqual( scanner.Scan(), "123456789" );
        }

        [TestMethod]
        public void ScannerReturnsAccountNumber457508000Test()
        {
            var input =
                "    _  _  _  _  _  _  _  _ " + Environment.NewLine +
                "|_||_   ||_ | ||_|| || || |" + Environment.NewLine +
                "  | _|  | _||_||_||_||_||_|" + Environment.NewLine;
            var scanner = new Scanner(input);
            Assert.AreEqual(scanner.Scan(), "457508000");
        }

        [TestMethod]
        public void ScannerReturnsStringEntryWithMarkedErrorForAccountNumberEntryWithBadCheckSumTest()
        {
            var input =
                " _  _  _     _  _     _  _ " + Environment.NewLine +
                " _| _||_||_||_ |_   ||_ |_ " + Environment.NewLine +
                "|_ |_ |_|  | _||_|  ||_| _|" + Environment.NewLine;

            var scanner = new Scanner(input);
            Assert.AreEqual(scanner.Scan(), "228456165 ERR");
        }

        [TestMethod]
        public void ScannerReturnsStringEntryWithMarkedIllegibleDigitForEntryWithIllegibleDigitTest()
        {
            var input =
                " _  _  _     _  _     _  _ " + Environment.NewLine +
                " _| _||_||_||_  _   ||_ |_ " + Environment.NewLine +
                "|_ |_ |_|  | _||_|  ||_| _|" + Environment.NewLine;

            var scanner = new Scanner(input);
            Assert.AreEqual(scanner.Scan(), "22845?165 ILL" );
        }
    }
}
