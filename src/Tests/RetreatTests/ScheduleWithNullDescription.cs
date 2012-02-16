namespace Dahlia.Domain.RetreatTests
{
    public class ScheduleWithNullDescription : ScheduleWithDescription
    {
        protected override string Description
        {
            get { return null; }
        }
    }
}
