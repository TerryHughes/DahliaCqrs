namespace Dahlia.RelationalStore.ParticipantSnapshottedEventHandlers.Participants
{
    using Data.Common;

    public class Version1 : ParticipantSnapshottedEventHandlers.Version1
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
