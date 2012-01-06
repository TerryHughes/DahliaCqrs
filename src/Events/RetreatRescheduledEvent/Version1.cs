namespace Dahlia.Events.RetreatRescheduledEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public DateTime Date { get; set; }
    }
}
