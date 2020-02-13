using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; private set; }

        public int EntityId { get; private set; }

        public EntityNotFoundException(Type entityType, int entityId)
        {
            EntityId = entityId;
            EntityType = entityType;
        }
    }
}
