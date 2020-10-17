using System.Collections.Generic;
using System.Security.Claims;
using Protoss.Core;
using Protoss.Testing.Core.Authentication;

namespace Protoss.Testing.Core.Stubs
{
    public class CurrentUserStub : ICurrentUser
    {
        public ClaimsPrincipal Get()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,"1"),
                new Claim(ClaimTypes.Email,"pakan.rahmani@gmail.com"),
                new Claim(ClaimTypes.Name,"pakan rahmani"),
            };
            var claimsIdentity = new ClaimsIdentity(claims);
            return new TestPrincipal(claimsIdentity);
        }
    }
}
