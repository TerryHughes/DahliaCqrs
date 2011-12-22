namespace Dahlia
{
    using Dahlia.CommandHandlers;
    using Dahlia.Commands;
    using Dahlia.EventStores;

    public class LoggingHandler<T> : Handler<T> where T : Command
    {
        private readonly Handler<T> innerHandler;

        public LoggingHandler(Handler<T> innerHandler)
        {
            this.innerHandler = innerHandler;
        }

        public void Handle(T command)
        {
            // add logging as needed around the actual handler.
            innerHandler.Handle(command);
        }
    }

    public class MergingHandler<T> : Handler<T> where T : Command
    {
        private readonly Handler<T> innerHandler;
        private readonly EventStore eventStore;

        public MergingHandler(Handler<T> innerHandler, EventStore eventStore)
        {
            this.innerHandler = innerHandler;
            this.eventStore = eventStore;
        }

        public void Handle(T command)
        {
            //var eventsSinceExpected = eventStore.RetrieveEventsSince(command.ExpectedVersion, command.AggregateId);
        }
    }

    public class RetryConcurrencyExceptionHandler<T> : Handler<T> where T : Command
    {
        private readonly Handler<T> innerHandler;

        public RetryConcurrencyExceptionHandler(Handler<T> innerHandler)
        {
            this.innerHandler = innerHandler;
        }

        public void Handle(T command)
        {
            var retry = true;

            while (retry)
            {
                try
                {
                    innerHandler.Handle(command);

                    retry = false;
                }
                catch (EventStoreConcurrencyException)
                {
                }
            }
        }
    }

    public class Foo
    {
        public Foo()
        {
            var handler = Wrapper(new CreateParticipantCommandHandler(new InMemoryEventStore()));
        }

        private static Handler<T> Wrapper<T>(Handler<T> handler) where T : Command
        {
            return new RetryConcurrencyExceptionHandler<T>(handler);
        }
    }
}
