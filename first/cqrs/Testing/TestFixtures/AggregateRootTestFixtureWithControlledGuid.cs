namespace Dahlia.Domain
{
    using System;
    using Dahlia.Framework;

    public abstract class AggregateRootTestFixtureWithControlledGuid<T> : AggregateRootTestFixture<T> where T : AggregateRoot, new()
    {
        protected abstract Guid ControlGuid { get; }

        protected override void WhenThisHappens()
        {
            SystemGuid.FromNowOnReturn(ControlGuid);
            WhenThisHappensWithControlledGuid();
            SystemGuid.FromNowOnGenerateNew();
        }

        protected abstract void WhenThisHappensWithControlledGuid();
    }
}
