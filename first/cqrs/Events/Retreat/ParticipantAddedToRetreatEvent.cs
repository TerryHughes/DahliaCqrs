namespace Dahlia.Events.ParticipantAddedToRetreatEvent
{
    using System;

    public class Version1 : Event
    {
        public readonly Guid ParticipantId;

        public Version1(Guid participantId)
        {
            ParticipantId = participantId;
        }
    }
}
