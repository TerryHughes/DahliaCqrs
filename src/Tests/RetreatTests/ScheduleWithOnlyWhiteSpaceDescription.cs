namespace Dahlia.Domain.RetreatTests
{
    public class ScheduleWithOnlyWhiteSpaceDescription : ScheduleWithDescription
    {
        protected override string Description
        {
            get { return "   "; }
        }
    }
}
