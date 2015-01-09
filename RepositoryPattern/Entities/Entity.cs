using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public abstract class Entity
    {
        /// <summary>
        /// When overriden in a derived class, gets all components of the identity of the entity.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetIdentityComponents();

        protected Entity()
        {
        }

        protected virtual int Id { get; set; }
      

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            if (object.ReferenceEquals(null, obj)) return false;
            if (GetType() != obj.GetType()) return false;
            var other = obj as Entity;
            return other != null && GetIdentityComponents().SequenceEqual(other.GetIdentityComponents());
        }

        
    }
}