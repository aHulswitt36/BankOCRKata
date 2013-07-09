using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBankOCR
{
    public class Digit : List< string >
    {
        private readonly Dictionary< string, char > _textToIntegerConversion;
        
        public Digit()
        {
            _textToIntegerConversion = new Dictionary<string, char>
                {
                    {
                        " _ " +
                        "| |" +
                        "|_|",
                        '0'
                    },
                    {
                        "   " +
                        "  |" +
                        "  |",
                       '1'
                    },
                    {
                        " _ " +
                        " _|" +
                        "|_ ",
                        '2'
                    },
                    {
                        " _ " +
                        " _|" +
                        " _|",
                        '3'
                    },
                    {
                        "   " +
                        "|_|" +
                        "  |",
                        '4'
                    },
                    {
                        " _ " +
                        "|_ " +
                        " _|",
                        '5'
                    },
                    {
                        " _ " +
                        "|_ " +
                        "|_|",
                        '6'
                    },
                    {
                        " _ " +
                        "  |" +
                        "  |",
                        '7'
                    },
                    {
                        " _ " +
                        "|_|" +
                        "|_|",
                        '8'
                    },
                    {
                        " _ " +
                        "|_|" +
                        " _|",
                        '9'
                    }
                };
        }
        public bool IsValidDigit
        {
            get
            {
                return Count == 3 
                    && this[0].Length == 3 
                    && this[1].Length == 3 
                    && this[2].Length == 3 
                    && DigitAsChar != '?';
            }
        }

        public char DigitAsChar
        {
            get
            {
                var key = this[0] + this[1] + this[2];
                return _textToIntegerConversion.ContainsKey( key ) ? _textToIntegerConversion[key] : '?';
            }
        }
    }
}
