using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBankOCR
{
    public class Entry
    {
        protected List<string> Input { get; set; }
        private List<Digit> Digits { get; set; }

        public Entry( List<string> input )
        {
            Input = input;
            Digits = ParseDigits();
        }
        
        public bool IsValidEntry    
        {
            get
            {
                if (Input.Count() != 4)
                    return false;
                if (Input[3].Trim().Any())
                    return false;
                if (Input.Any(line => line.Length != 27))
                    return false;
                return true;
            }
        }

        public string AccountNumberAsText
        {
            get
            {
                return !IsValidEntry 
                    ? "" 
                    : Digits.Aggregate("", (current, digit) => current + digit.DigitAsChar);
            }
        }

        public bool AreDigitsInvalid
        {
            get { return Digits.Any( d => !d.IsValidDigit ); }
        }

        public List< Digit > ParseDigits()
        {
            var digits = new List<Digit>();
            if (Input != null && Input.Any() && IsValidEntry)
            {
                for (var i = 0; i < 9; i++)
                {
                    var digit = new Digit
                    {
                        Input[ 0 ].Substring( i * 3, 3 ),
                        Input[ 1 ].Substring( i * 3, 3 ),
                        Input[ 2 ].Substring( i * 3, 3 )
                    };
                    digits.Add(digit);
                }
            }
            return digits;
        }

        public override string ToString()
        {
            var accountNumber = AccountNumberAsText;
            var validator = new CheckSumValidator();
            if ( AreDigitsInvalid )
                accountNumber += " ILL";
            else if ( !validator.IsValid( accountNumber ) )
                accountNumber += " ERR";
            return accountNumber;
        }
    }
}
