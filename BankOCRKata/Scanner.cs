using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBankOCR
{
    public class Scanner
    {
        private readonly string _input;
        private CheckSumValidator _validator;

        public Scanner(string input)
        {
            _input = input;
            _validator = new CheckSumValidator();
        }

        public string Scan()
        {
            var accountNumber = string.Empty;
            using ( var reader = new StringReader( _input ) )
            {
                while ( reader.Peek() != -1 )
                {
                    var entry = BuildEntry( reader );
                    if ( !entry.IsValidEntry ) continue;
                    accountNumber = entry.ToString();
                }
            }
            return accountNumber;
        }

        private Entry BuildEntry(StringReader reader)
        {
            var line0 = reader.ReadLine();
            var line1 = reader.ReadLine();
            var line2 = reader.ReadLine();
            var line3 = new string(' ', 27);
            var lines = new List<string> { line0, line1, line2, line3 };
            return new Entry(lines);
        }
    }
}
