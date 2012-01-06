namespace Dahlia.Events.RetreatScheduledEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
