namespace Dahlia.Events.ParticipantSnapshottedEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
