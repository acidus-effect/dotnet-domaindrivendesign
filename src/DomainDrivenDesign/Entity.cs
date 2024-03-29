﻿using System;

namespace Acidic.DomainDrivenDesign
{
    /// <summary>
    /// The base type for classes that represent an entity.
    /// 
    /// An entity is identified solely by its identity.
    /// 
    /// If two entities of the same type has the same identifier value, they are considered equal. This is true
    /// even if they otherwise contain different data.
    /// </summary>
    /// <typeparam name="TIdentifier">The type used to uniquely identify the entity.</typeparam>
    public abstract class Entity<TIdentifier> : IEquatable<Entity<TIdentifier>>
    {
        /// <summary>
        /// The unique identifier of the entity.
        /// </summary>
        protected TIdentifier Identifier { get; }

        /// <summary>
        /// Creates a new instance of <see cref="Entity{TIdentifier}"/>.
        /// </summary>
        /// <param name="identifier">The unique identity of the entity.</param>
        /// <exception cref="ArgumentNullException">The argument <paramref name="identifier"/></exception>
        protected Entity(TIdentifier identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));

            Identifier = identifier;
        }

        /// <inheritdoc />
        public sealed override bool Equals(object obj)
        {
            return Equals(obj as Entity<TIdentifier>);
        }

        /// <inheritdoc />
        public sealed override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">The object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Entity<TIdentifier> other)
        {
            if (other is null)
                return false;

            return Identifier.Equals(other.Identifier);
        }

        /// <summary>
        /// Compares two object to check if they are equal.
        /// </summary>
        /// <param name="lhs">The first object to compare with.</param>
        /// <param name="rhs">The second object to compare with.</param>
        /// <returns>true if the two object are equal; otherwise, false.</returns>
        public static bool operator ==(Entity<TIdentifier> lhs, Entity<TIdentifier> rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two object to check if they are not equal.
        /// </summary>
        /// <param name="lhs">The first object to compare with.</param>
        /// <param name="rhs">The second object to compare with.</param>
        /// <returns>false if the two object are equal; otherwise, true.</returns>
        public static bool operator !=(Entity<TIdentifier> lhs, Entity<TIdentifier> rhs) => !(lhs == rhs);

        /// <inheritdoc />
        public override string ToString() => Identifier.ToString();
    }
}