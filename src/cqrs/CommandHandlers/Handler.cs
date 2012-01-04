namespace Dahlia.CommandHandlers
{
    using System;
    using Dahlia.Commands;
    using Dahlia.Domain;
    using Dahlia.EventStores;

    public interface Handler<in T> where T : Command
    {
        void Handle(T command);
    }

    public abstract class CommandHandler<TCommand, TAggregateRoot> : Handler<TCommand> where TCommand : Command where TAggregateRoot : AggregateRoot, new()
    {
        private readonly EventStore eventStore;

        protected CommandHandler(EventStore eventStore)
        {
            this.eventStore = eventStore;
        }

        public void Handle(TCommand command)
        {
            eventStore.Perform<TAggregateRoot>(r => Action(command, r), Against(command));
        }

        protected abstract void Action(TCommand command, TAggregateRoot aggregateRoot);

        protected virtual Guid Against(TCommand command)
        {
            return command.AggregateRootId;
        }
    }

    public abstract class CommandHandlerWithEmptyGuid<TCommand, TAggregateRoot> : CommandHandler<TCommand, TAggregateRoot> where TCommand : Command where TAggregateRoot : AggregateRoot, new()
    {
        protected CommandHandlerWithEmptyGuid(EventStore eventStore) : base(eventStore)
        {
        }

        // sealing not recomended? http://stackoverflow.com/questions/4673967/is-it-possible-to-finalize-a-virtual-method-in-c
        protected override sealed Guid Against(TCommand command)
        {
            return Guid.Empty;
        }
    }
}
