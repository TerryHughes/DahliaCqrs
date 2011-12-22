namespace Dahlia.Events.ParticipantAddedToRetreatEventSpecifications
{
    using System;
    using Dahlia.Events.ParticipantAddedToRetreatEvent;
    using Machine.Specifications;

    public class when_creating_Version1
    {
        Establish context =()=>
        {
            participantId = Guid.NewGuid();
        };

        Because of =()=> @event = new Version1(participantId);

        It should_not_alter_the_participant_id =()=> @event.ParticipantId.ShouldEqual(participantId);

        static Guid participantId;
        static Version1 @event;
    }
}
