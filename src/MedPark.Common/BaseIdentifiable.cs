using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common
{
    public class BaseIdentifiable : IIdentifiable
    {
        public DateTime Created { get; protected set; }
        public DateTime Modified { get; protected set; }
        public Guid Id { get; protected set; }

        public BaseIdentifiable(Guid id)
        {
            Id = id;
            Created = DateTime.UtcNow;
            UpdatedModified();
        }

        protected virtual void UpdatedModified()
            => Modified = DateTime.UtcNow;

        public virtual void Use() { }
    }
}
