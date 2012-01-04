namespace Dahlia.Commands
{
    using System;

    public class CreateParticipantCommand : Command
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateTime DateRecieved;

        public CreateParticipantCommand(string firstName, string lastName, DateTime dateRecieved)
        {
            FirstName = firstName;
            LastName = lastName;
            DateRecieved = dateRecieved;
        }
    }
}
