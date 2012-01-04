namespace Dahlia.Events.ParticipantRenamedEvent
{
    public class Version1 : Event
    {
        public readonly string FirstName;
        public readonly string LastName;

        public Version1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
