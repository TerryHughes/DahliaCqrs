namespace Dahlia.Events.ParticipantAddedToRetreatEvent
{
    using System;

    [Serializable]
    public class Version2 : Event
    {
        public DateTime RetreatDate { get; set; }
        public Guid ParticipantId { get; set; }
        public string ParticipantName { get; set; }
    }
}
