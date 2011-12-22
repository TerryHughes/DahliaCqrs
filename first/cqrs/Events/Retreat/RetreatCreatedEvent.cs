namespace Dahlia.Events.RetreatCreatedEvent
{
    using System;

    public class Version1 : Event
    {
        public readonly string Name;
        public readonly DateTime Date;

        public Version1(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }
}
