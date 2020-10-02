using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using NHibernate.Driver;
using Protoss.Core.Extensions;

namespace Protoss.DataAccess.NH
{
    public class YekeSqlClientDriver:SqlClientDriver
    {
        public override void AdjustCommand(DbCommand command)
        {
            DbCommandExtensions.ApplyYeke(command);
            base.AdjustCommand(command);
        }
    }
}
