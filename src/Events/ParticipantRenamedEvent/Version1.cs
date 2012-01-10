namespace Dahlia.Events.ParticipantRenamedEvent
{
    using System;

    [Serializable]
    public class Version1 : Event
    {
        public string Name { get; set; }
    }
}
