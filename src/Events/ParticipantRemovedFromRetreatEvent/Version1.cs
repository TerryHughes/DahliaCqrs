namespace Dahlia.Events.ParticipantRemovedFromRetreatEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public DateTime RetreatDate { get; set; }
        public Guid ParticipantId { get; set; }
        public string ParticipantName { get; set; }
    }
}
