namespace Dahlia.Events.ParticipantNoteUpdatedEvent
{
    public class Version1 : Event
    {
        public readonly string Note;

        public Version1(string note)
        {
            Note = note;
        }
    }
}
