namespace Dahlia.Events.CreateParticipantFailedEventSpecifications
{
    using Dahlia.Events.CreateParticipantFailedEvent;
    using Machine.Specifications;

    public class when_creating_Version1
    {
        Establish context =()=> reason = "reason";

        Because of =()=> @event = new Version1(reason);

        It should_not_alter_the_reason =()=> @event.Reason.ShouldEqual(reason);

        static string reason;
        static Version1 @event;
    }
}
