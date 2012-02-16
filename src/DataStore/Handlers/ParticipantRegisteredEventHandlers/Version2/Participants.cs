namespace Dahlia.DataStore.ParticipantRegisteredEventHandlers.Participants
{
    using Data.Common;

    public class Version2 : ParticipantRegisteredEventHandlers.Version2
    {
        public Version2(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [Participants] ([Id], [Name], [Note], [DateRecieved]) VALUES (@Id, @Name, @Note, @DateRecieved)"; }
        }
    }
}
