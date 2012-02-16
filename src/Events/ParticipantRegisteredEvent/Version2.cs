namespace Dahlia.Events.ParticipantRegisteredEvent
{
    using System;

    [Serializable]
    public class Version2 : Event
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime DateRecieved { get; set; }
    }
}
