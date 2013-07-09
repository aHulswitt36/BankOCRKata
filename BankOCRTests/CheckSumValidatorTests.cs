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
    public class CheckSumValidatorTests
    {
        [TestMethod]
        public void ChecksumForEmptyAccountNumberIsZeroTest()
        {
            var validator = new CheckSumValidator();
            var isValid = validator.IsValid("457508000");

            Assert.IsTrue( isValid );
        }

        [TestMethod]
        public void InvalidAccountNumberHasFalseCheckSumValidationTest()
        {
            var validator = new CheckSumValidator();
            var isValid = validator.IsValid("664371495");
            Assert.IsFalse( isValid );
        }

    }
}
