namespace Dahlia.Events.ParticipantAddedToRetreatEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public Guid ParticipantId { get; set; }
    }
}
