using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasPermissionAttribute : Attribute
    {
        public Permission Permission { get; private set; }

        public HasPermissionAttribute(Enum value)
        {
            Permission = value.GetPermission();
        }
    }
}
