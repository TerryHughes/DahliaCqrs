/*
namespace Dahlia.CommandHandlers
{
    using System;
    using Dahlia.Commands;
    using Dahlia.Framework;

    public abstract class HandlerTestFixtureWithControlledGuid<THandler, TCommand> : HandlerTestFixture<THandler, TCommand> where THandler : Handler<TCommand> where TCommand : Command
    {
        protected abstract Guid ControlGuid { get; }

        protected override void WhenThisHappens()
        {
            SystemGuid.FromNowOnReturn(ControlGuid);
            base.WhenThisHappens();
            SystemGuid.FromNowOnGenerateNew();
        }
    }
}
*/
