using System;
using System.Collections.Generic;

namespace SwiftBookingTest.Core.Common
{
    public abstract class EntityBase
    {
        private readonly IList<ValidationError> _validationErrors = new List<ValidationError>();

        public Guid Id { get; set; }

        public override bool Equals(object entity)
        {
            return entity != null
                && entity is EntityBase
                && this == (EntityBase)entity;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public IEnumerable<ValidationError> GetValidationErrors()
        {
            _validationErrors.Clear();

            Validate();

            return _validationErrors;
        }

        public T Copy<T>() where T : EntityBase
        {
            return (T)MemberwiseClone();
        }

        public static bool operator ==(EntityBase entity1, EntityBase entity2)
        {
            return entity1?.Id == entity2?.Id;
        }

        public static bool operator !=(EntityBase entity1, EntityBase entity2)
        {
            return !(entity1 == entity2);
        }

        protected abstract void Validate();

        protected void AddValidationError(ValidationError error)
        {
            _validationErrors.Add(error);
        }
    }
}
