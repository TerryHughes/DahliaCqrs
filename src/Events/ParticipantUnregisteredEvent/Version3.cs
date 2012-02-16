namespace Dahlia.Events.ParticipantUnregisteredEvent
{
    using System;

    [Serializable]
    public class Version3 : Event
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime DateRecieved { get; set; }
    }
}
