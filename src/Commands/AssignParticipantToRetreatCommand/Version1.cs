namespace Dahlia.Commands.AssignParticipantToRetreatCommand
{
    using System;

    public class Version1 : Command
    {
        public Guid ParticipantId { get; set; }
        public Guid BedId { get; set; }
    }
}
