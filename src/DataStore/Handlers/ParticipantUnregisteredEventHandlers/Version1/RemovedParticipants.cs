/*
namespace Dahlia.DataStore.ParticipantUnregisteredEventHandlers.RemovedParticipants
{
    using Data.Common;

    public class Version1 : ParticipantUnregisteredEvent.Version1
    {
        public Version1(WriteRepository repository) : base(repository)
        {
        }

        protected override string Statement
        {
            get { return "INSERT INTO [RemovedParticipants] SELECT * FROM [Participants] WHERE [Id] = @Id;DELETE FROM [Participants] WHERE [Id] = @Id"; }
        }
    }
}
*/
