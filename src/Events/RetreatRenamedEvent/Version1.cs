namespace Dahlia.Events.RetreatRenamedEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public string Description { get; set; }
    }
}
