namespace Dahlia.Events.BedRemovedEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public string Name { get; set; }
    }
}
