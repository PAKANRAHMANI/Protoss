using System;
using System.Text;

namespace Protoss.Domain
{
    public interface IEntity
    {
        bool IsDeleted { get; }

        void MarkAsUpdated();

        void MarkAsDeleted();
    }
}
