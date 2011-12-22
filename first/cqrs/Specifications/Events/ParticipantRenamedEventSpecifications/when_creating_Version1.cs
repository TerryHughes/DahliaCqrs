namespace Dahlia.Events.ParticipantRenamedEventSpecifications
{
    using System;
    using Dahlia.Events.ParticipantRenamedEvent;
    using Machine.Specifications;

    public class when_creating_Version1
    {
        Establish context =()=>
        {
            firstName = "firstName";
            lastName = "lastName";
        };

        Because of =()=> @event = new Version1(firstName, lastName);

        It should_not_alter_the_first_name =()=> @event.FirstName.ShouldEqual(firstName);

        It should_not_alter_the_last_name =()=> @event.LastName.ShouldEqual(lastName);

        static string firstName;
        static string lastName;
        static Version1 @event;
    }
}
