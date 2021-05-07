﻿using System;
using System.Linq;

namespace Acidic.DomainDrivenDesign
{
    /// <summary>
    /// Represents a value object.
    /// 
    /// A value object is defined by its value(s) and not by a unique identifier.
    /// Two value object are considered equal, if their value properties contains
    /// the same values.
    /// </summary>
    /// <typeparam name="T">The type of the concrete value object class.</typeparam>
    public abstract class Value<T> : IEquatable<T> where T : Value<T>
    {
        /// <summary>
        /// An object array, containing references to all of the value object properties that should be used
        /// when comparing one value object with another.
        /// </summary>
        protected abstract object[] PropertiesForEqualityCheck { get; }

        /// <inheritdoc />
        public sealed override bool Equals(object other)
        {
            return Equals(other as T);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">The object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(T other)
        {
            if (other == null)
                return false;

            return PropertiesForEqualityCheck.SequenceEqual(other.PropertiesForEqualityCheck);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = 352033288;
            
            foreach (var propertyForEqualityCheck in PropertiesForEqualityCheck)
            {
                hashCode = hashCode * -1521134295 + propertyForEqualityCheck.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// Compares two object to check if they are equal.
        /// </summary>
        /// <param name="lhs">The first object to compare with.</param>
        /// <param name="rhs">The second object to compare with.</param>
        /// <returns>true if the two object are equal; otherwise, false.</returns>
        public static bool operator ==(Value<T> lhs, Value<T> rhs)
        {

            if (ReferenceEquals(lhs, null))
            {
                if (ReferenceEquals(rhs, null))
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
        public static bool operator !=(Value<T> lhs, Value<T> rhs) => !(lhs == rhs);
    }
}