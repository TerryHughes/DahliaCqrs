namespace Dahlia.Events.RetreatCreatedEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
