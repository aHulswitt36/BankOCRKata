using System;
using System.Collections.Generic;
using System.Diagnostics;
using KataBankOCR;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataBankTests
{
    [TestClass]
    public class EntryTests
    {
        private List<string> _validInput;

        private Entry _entry;

        [TestInitialize]
        public void TestSetup()
        {
            _validInput = new List<string>()
                {
                    new string(' ',27),
                    new string(' ',27),
                    new string(' ',27),
                    new string(' ',27)
                };
        }
            
        [TestMethod]
        public void ValidEntryHasFourLinesTest()
        {
            _entry = new Entry(_validInput);

            Assert.AreEqual(_entry.IsValidEntry, true);
        }

        [TestMethod]
        public void InvalidEntryWithOtherThanFourLinesTest()
        {
            var invalidInput = new List<string>()
                {
                    "",
                    "",
                    ""
                };
            _entry = new Entry( invalidInput ); ;

            Assert.AreEqual( _entry.IsValidEntry, false );
        }

        [TestMethod]
        public void ValidEntryHasBlankFourthLineTest()
        {
            _entry = new Entry( _validInput );
            Assert.AreEqual( _entry.IsValidEntry, true );
        }

        [TestMethod]
        public void InvalidEntryWithNonBlankFourthLineTest()
        {
            var invalidInput = new List<string>
                {
                    "_",
                    " |",
                    " |",
                    " |"
                };
            _entry = new Entry( invalidInput );
            Assert.AreEqual( _entry.IsValidEntry, false );
        }

        [TestMethod]
        public void ValidEntryLinesAllHave27CharsTest()
        {
            _entry = new Entry( _validInput );
            Assert.AreEqual( _entry.IsValidEntry, true );
        }

        [TestMethod]
        public void InvalidEntryLinesAllHaveCharCountOtherThan27Test()
        {
            var invalidInput = new List<string>
                {
                    new string(' ',5),
                    new string(' ',18),
                    new string(' ',22),
                    new string(' ',23)
                };
            _entry = new Entry( invalidInput );
            Assert.AreEqual( _entry.IsValidEntry, false );
        }

        [TestMethod]
        public void ValidEntryHasNineAccountNumbersTest()
        {
            var entry = new Entry(_validInput);
            var accountNumber = entry.AccountNumberAsText;

            Assert.IsNotNull( accountNumber );
            Assert.AreEqual( accountNumber.Length, 9 );
        }

        [TestMethod]
        public void InvalidEntryReturnsEmptyAccountNumberListTest()
        {
            var entry = new Entry(new List<string>());
            var accountNumber = entry.AccountNumberAsText;

            Assert.IsFalse( entry.IsValidEntry );
            Assert.IsNotNull( accountNumber );
            Assert.AreEqual( accountNumber.Length, 0 );
        }
        
        [TestMethod]
        public void ValidParseResultsInListOfNineDigitsTest()
        {
            var entry = new Entry(new List<string>{
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                new string( ' ', 27 )
            });
            var digits = entry.ParseDigits();
            Assert.AreEqual( digits.Count, 9 );
        }

        [TestMethod]
        public void InvalidEntryContainsListOfDigitsNotNineInLengthTest()
        {
        var entry = new Entry(new List<string>{
                "    _  _     _  _  _  _ ",
                "  | _| _||_||_ |_   ||_|",
                "  ||_  _|  | _||_|  ||_|",
                new string( ' ', 27 )
            });
 
            Assert.IsFalse( entry.IsValidEntry );
        }

        [TestMethod]
        public void ValidDigitsReturnsFalseTest()
        {
            var entry = new Entry(new List<string>{
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                new string( ' ', 27 )
            });
            var digits = entry.ParseDigits();
            Assert.IsFalse( entry.AreDigitsInvalid );
        }

        [TestMethod]
        public void InvalidDigitsReturnTrueTest()
        {
            var entry = new Entry(new List<string>
                {
                    " _  _  _     _  _     _  _ ",
                    " _| _||_||_||_  _   ||_ |_ ",
                    "|_ |_ |_|  | _||_|  ||_| _|" ,
                    new string( ' ', 27 )
                });
            var digits = entry.ParseDigits();
            Assert.IsTrue( entry.AreDigitsInvalid );
        }
        
    }
}
