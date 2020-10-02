using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Core.Clock
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
