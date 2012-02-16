namespace Dahlia.Domain.RetreatTests
{
    using System;

    public class ScheduleWithEmptyDescription : ScheduleWithDescription
    {
        protected override string Description
        {
            get { return String.Empty; }
        }
    }
}
