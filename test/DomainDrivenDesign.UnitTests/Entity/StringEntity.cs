﻿namespace Acidic.DomainDrivenDesign.UnitTests.Entity
{
    internal sealed class StringEntity : Entity<string>
    {
        public StringEntity(string identifier) : base(identifier)
        {
        }
    }
}