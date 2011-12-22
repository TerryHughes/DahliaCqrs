namespace Dahlia.Events.CreateParticipantFailedEvent
{
    public class Version1 : Event
    {
        public readonly string Reason;

        public Version1(string reason)
        {
            Reason = reason;
        }
    }
}
