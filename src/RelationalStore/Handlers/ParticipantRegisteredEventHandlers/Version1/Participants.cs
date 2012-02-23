namespace Dahlia.RelationalStore.ParticipantRegisteredEventHandlers.Participants
{
    using Data.Common;

    public class Version1 : ParticipantRegisteredEventHandlers.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [Participants] ([Id], [Name], [Note], [DateRecieved]) VALUES (@Id, @Name, @Note, '01/01/1950')"; }
        }
    }
}
