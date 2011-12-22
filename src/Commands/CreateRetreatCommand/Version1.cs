namespace Dahlia.Commands.CreateRetreatCommand
{
    using System;

    public class Version1 : Command
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Version1(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }
    }
}
