namespace Dahlia.DataStore.ParticipantRegisteredEventHandlers.Participants
{
    using Data.Common;

    public class Version1 : ParticipantRegisteredEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [Participants] ([Id], [Name], [Note]) VALUES (@Id, @Name, @Note)"; }
        }
    }
}
