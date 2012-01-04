namespace Dahlia.Events.ParticipantCreatedEventSpecifications
{
    using System;
    using Dahlia.Events.ParticipantCreatedEvent;
    using Machine.Specifications;

    public class when_creating_Version1
    {
        Establish context =()=>
        {
            firstName = "firstName";
            lastName = "lastName";
            dateRecieved = new DateTime(2011, 03, 23);
        };

        Because of =()=> @event = new Version1(firstName, lastName, dateRecieved);

        It should_not_alter_the_first_name =()=> @event.FirstName.ShouldEqual(firstName);

        It should_not_alter_the_last_name =()=> @event.LastName.ShouldEqual(lastName);

        It should_not_alter_the_date_recieved =()=> @event.DateRecieved.ShouldEqual(dateRecieved);

        static string firstName;
        static string lastName;
        static DateTime dateRecieved;
        static Version1 @event;
    }
}
