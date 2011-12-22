namespace Dahlia.Events.RetreatCreatedEventSpecifications
{
    using System;
    using Dahlia.Events.RetreatCreatedEvent;
    using Machine.Specifications;

    public class when_creating_Version1
    {
        Establish context =()=>
        {
            name = "name";
            date = new DateTime(2011, 04, 04);
        };

        Because of =()=> @event = new Version1(name, date);

        It should_not_alter_the_name =()=> @event.Name.ShouldEqual(name);

        It should_not_alter_the_date =()=> @event.Date.ShouldEqual(date);

        static string name;
        static DateTime date;
        static Version1 @event;
    }
}
