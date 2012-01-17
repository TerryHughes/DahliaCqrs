namespace Dahlia.DataStore.ParticipantUnregisteredEventHandlers.RemovedParticipants
{
    using Data.Common;

    public class Version2 : ParticipantUnregisteredEventHandlers.Version2
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RemovedParticipants] ([Id], [Name], [Note]) VALUES (@Id, @Name, @Note)"; }
        }
    }
}
