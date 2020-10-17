using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Protoss.Testing.Core.Authentication
{
    public class TestIdentity  : ClaimsIdentity
    {
        public override bool IsAuthenticated => true;
    }
}
