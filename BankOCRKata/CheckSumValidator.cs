using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataBankOCR
{
    public class CheckSumValidator 
    {
        public bool IsValid( string s )
        {
            var accountNumberChars = s.ToCharArray();
            var sum = 0;
            for (var pos = 1; pos <= 9; pos++)
            {
                var value = int.Parse(accountNumberChars[9 - pos].ToString());
                sum += value * pos;
            }
            return ( sum % 11 ) == 0;
        }
    }
}
