using System;
using System.Collections.Generic;

namespace Protoss.Domain
{
    public abstract class Entity<TKey> : IEntity
    {
        public byte[] RowVersion { get; private set; }
        public DateTime CreationDateTime { get;  }
        public TKey Id { get; protected set; }

        protected Entity()
        {
            this.CreationDateTime = DateTime.Now;
        }
        protected bool Equals(Entity<TKey> other)
        {
            return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity<TKey>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TKey>.Default.GetHashCode(Id);
        }
    }
}