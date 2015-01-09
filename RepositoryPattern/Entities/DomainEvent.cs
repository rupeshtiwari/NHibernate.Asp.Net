using System;
using System.Collections.Generic;
using System.Globalization;
using RepositoryPattern.Map;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public abstract class DomainEvent : ValueObject
    {
        private DateTime _occurredOn;
        private int _order;

        public virtual DateTime OccurredOn
        {
            get { return _occurredOn; }
            set { _occurredOn = value; }
        }

        public virtual int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        protected DomainEvent()
        {
            _occurredOn = DateTime.UtcNow;
            _order = 0;
        }
     

        protected override string[] GetEqualityComponents()
        {
            return new[]
            {
                OccurredOn.ToString(CultureInfo.InvariantCulture),
                Order.ToString(CultureInfo.InvariantCulture)
            };
        }
 
    }
}