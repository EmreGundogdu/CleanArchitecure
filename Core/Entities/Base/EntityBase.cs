﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public TId Id { get; protected set; }
        int? _requestHashCode;
        public bool IsTransient()
        {
            return Id.Equals(default(TId));
        }
        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is EntityBase<TId>))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType())
                return false;
            var item = (EntityBase<TId>)obj;
            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item == this;

        }
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestHashCode.HasValue)
                    _requestHashCode = Id.GetHashCode() ^ 31;
                return _requestHashCode.Value;
            }
            else
                return base.GetHashCode();
        }
        public static bool operator == (EntityBase<TId> left, EntityBase<TId> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }
        public static bool operator != (EntityBase<TId> left,EntityBase<TId> right)
        {
            return !(left == right);
        }
    }
}
