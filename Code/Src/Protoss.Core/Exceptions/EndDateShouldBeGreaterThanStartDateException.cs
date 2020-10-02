using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Core.Exceptions
{
    public class EndDateShouldBeGreaterThanStartDateException : ProtossException
    {
        public EndDateShouldBeGreaterThanStartDateException():base(-1, "EndDate should be greater than StartDate")
        {
            
        }
    }
}
