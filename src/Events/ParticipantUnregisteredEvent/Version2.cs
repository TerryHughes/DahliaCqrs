namespace Dahlia.Events.ParticipantUnregisteredEvent
{
    using System;

    [Serializable]
    public class Version2 : Event
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
