using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Specification
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly CompositeSpecification<T> _specification;

        public NotSpecification(CompositeSpecification<T> specification)
        {
            _specification = specification;
        }
        public override bool IsSatisfiedBy(T candidate)
        {
            return !_specification.IsSatisfiedBy(candidate);
        }
    }
}
