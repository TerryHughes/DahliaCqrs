namespace Dahlia.Commands.ScheduleRetreatCommand
{
    using System;

    public class Version1 : Command
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
