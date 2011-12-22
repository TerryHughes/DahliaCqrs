namespace Dahlia.Commands.CreateRetreatCommand
{
    using System;

    public class Version2 : Command
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Version2(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }
    }
}
