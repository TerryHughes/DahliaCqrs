namespace Dahlia.Events.ParticipantUnassignedFromRetreatEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public Guid ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public Guid BedId { get; set; }
        public string BedName { get; set; }
    }
}
