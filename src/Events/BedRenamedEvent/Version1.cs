namespace Dahlia.Events.BedRenamedEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public string Name { get; set; }
    }
}
