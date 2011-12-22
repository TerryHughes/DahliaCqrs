namespace Dahlia.Events.ParticipantCreatedEvent
{
    using System;

    public class Version1 : Event
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateTime DateRecieved;

        public Version1(string firstName, string lastName, DateTime dateRecieved)
        {
            FirstName = firstName;
            LastName = lastName;
            DateRecieved = dateRecieved;
        }
    }
}
